using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
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

    }
}
