using AutoMapper;
using Microsoft.Ajax.Utilities;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class PaymentAPIController : ApiController
    {
       

        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        //get data for contract
        [HttpGet]
        [Route("api/contractdataforpayment/get")]
        public IHttpActionResult Getcontract()
        {
            var contract = Db.ngp_contract.ToList().Select(Mapper.Map<ngp_contract, ContractDTO>);
            return Ok(contract.OrderByDescending(x => x.contractID));
        }




        [HttpPost]
        [Route("api/payment/post")]
        public IHttpActionResult Save(PaymentDTO paymentDTO)

        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if (ModelState.IsValid)
            {
                var payment = Mapper.Map<PaymentDTO, ngp_payment>(paymentDTO);


                if (payment.paymentID == 0)
                {
                    payment.contract_no = Db.ngp_contract.SingleOrDefault(x => x.contractID == paymentDTO.contract_no).contractID;
                    payment.contractorName = Db.ngp_contract.SingleOrDefault(x => x.contractID == paymentDTO.contract_no).contractorName;

                    payment.num_release = paymentDTO.num_release;
                    payment.yearestablishedId = paymentDTO.yearestablishedId;

                    payment.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                    payment.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving role depend in UserId login
                    payment.UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName; //saving username depend in login
                    payment.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in login



                    Db.ngp_payment.Add(payment);
                  
                }
                Db.NgpLogsPayments.Add(new NgpLogsPayment()
                {

                    Date = DateTime.Now,
                    Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                    UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                    LogMessage = "Added a Payment " + "Contractor Name: " + payment.contractorName,
                    UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                    RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID,

                });

                Db.SaveChanges();
                return Ok("200");
            }
            return Ok();

        }






        //CREATE/SAVING METHODS CONTRACT
        //[HttpPost]
        //[Route("api/payment/post")]
        //public IHttpActionResult SaveContract(PaymentDTO paymentDTO)
        //{
          
        //        var payment = Mapper.Map<PaymentDTO, ngp_payment>(paymentDTO);

        //        if (paymentDTO.paymentID == 0)
        //        {

                 

        //        payment.contract_no = Db.ngp_contract.SingleOrDefault(x => x.contractID == paymentDTO.paymentID).contractID;


        //        Db.ngp_payment.Add(payment);
        //            Db.SaveChanges();
        //        }

          

        //    Db.SaveChanges();

        //    return Ok();

        //}

    }
}
