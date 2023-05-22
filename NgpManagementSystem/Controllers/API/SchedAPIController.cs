using AutoMapper;
using Microsoft.Ajax.Utilities;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using NgpManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class SchedAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }


        //CREATE/ PROJECT SAVING SHEDULE
        [HttpPost]
        [Route("api/sched/post")]
        public IHttpActionResult Save(SchedDTO schedDTO)

        {
            if (ModelState.IsValid)
            {
                var sched = Mapper.Map<SchedDTO, ngp_sched>(schedDTO);

                var sess_id = (int)HttpContext.Current.Session["LoginID"];
                if (sched.schedID == 0)
                {
                    sched.ContractId = Db.ngp_contract.SingleOrDefault(x => x.contractID == schedDTO.ContractId).contractID;

                    sched.contractor_name = Db.ngp_contract.SingleOrDefault(x => x.contractID == schedDTO.ContractId).contractorName;


                    sched.ors_no = schedDTO.ors_no;
                    sched.ors_date = schedDTO.ors_date;
                    sched.dv_no = schedDTO.dv_no;
                    sched.dv_date = schedDTO.dv_date;
                    sched.lddap_no = schedDTO.lddap_no;
                    sched.lddap_date = schedDTO.lddap_date;
                    sched.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                    sched.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving userId depend in UserId of user login
                    sched.UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName; //saving username depend in username of user login
                    sched.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in name of user login



                    Db.ngp_sched.Add(sched);

                }

                Db.NgpLogsScheds.Add(new NgpLogsSched()
                {

                    Date = DateTime.Now,
                    Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                    UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                    LogMessage = "Added a Sched " + "Contractor Name: " + sched.contractor_name,
                    UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                    RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.NgpRole.RoleName,

                });

                Db.SaveChanges();
                return Ok("200");
            }
            return Ok();

        }

        //get data for contract
        [HttpGet]
        [Route("api/contractdataforsched/get")]
        public IHttpActionResult Getcontract()
        {
            var contract = Db.ngp_contract.ToList().Select(Mapper.Map<ngp_contract, ContractDTO>);
            return Ok(contract.OrderByDescending(x => x.contractID));
        }




        //GET in form sched
        [Route("api/schedget/get/{id}")]
        [HttpGet]
        public IHttpActionResult GetSched(int id)
        {
            var sched = Db.ngp_sched.SingleOrDefault(d => d.schedID == id);
            if (sched == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ngp_sched, SchedDTO>(sched));
        }


        //Put
        [HttpPut]
        [Route("api/schedput/updatesched/{id}")]
        public IHttpActionResult UpdateSched(int id, SchedDTO schedDTO)
        {

            var sess_id = (int)HttpContext.Current.Session["LoginID"]; //need this for session  login
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schedinDb = Db.ngp_sched.SingleOrDefault(d => d.schedID == id);
            if (schedinDb == null)
            {
                return NotFound();
            }
            Mapper.Map(schedDTO, schedinDb);
            schedinDb.schedID = id;
            schedinDb.ors_no = schedDTO.ors_no;
            schedinDb.ors_date = schedDTO.ors_date;
            schedinDb.dv_no = schedDTO.dv_no;
            schedinDb.dv_date = schedDTO.dv_date;
            schedinDb.lddap_no = schedDTO.lddap_no;
            schedinDb.lddap_date = schedDTO.lddap_date;
            schedinDb.ContractId = Db.ngp_contract.SingleOrDefault(x => x.contractID == schedDTO.ContractId).contractID; // need contractorId match in contractor
            schedinDb.contractor_name = Db.ngp_contract.SingleOrDefault(x => x.contractID == schedDTO.ContractId).contractorName; // need contractorname == match in contractorname in contractor
            schedinDb.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
            schedinDb.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving userId depend in UserId of user login
            schedinDb.UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName; //saving username depend in username of user login
            schedinDb.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in name of user login

            Db.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        [Route("api/scheddelete/delete/{id}")]
        public IHttpActionResult DeleteSched(int id)
        {
            var schedinDb = Db.ngp_sched.SingleOrDefault(d => d.schedID == id);
            if (schedinDb == null)
            {
                return NotFound();
            }
            Db.ngp_sched.Remove(schedinDb);
            //_db.LoginActivity.Add(new LoginActivity()
            //{
            //    UserName = User.Identity.GetFullName(),
            //    ActivityMessage = "Deleted A Department",
            //    ActivityDate = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
            //    Email = User.Identity.GetUserName(),

            //});
            Db.SaveChanges();
            return Ok();
        }
    }
}
