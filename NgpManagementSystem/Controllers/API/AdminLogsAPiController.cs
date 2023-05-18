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
    public class AdminLogsAPiController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        [HttpGet]
        [Route("api/adminlogsaccount/get")]
        public IHttpActionResult AdminLogsforAccount()


        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var accountactivity = Db.NgpLogsUserAccounts.ToList().Select(Mapper.Map<NgpLogsUserAccount, LogsAccountDTO>);
                return Ok(accountactivity.OrderByDescending(x => x.Id).Take(5));
            }
            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsUserAccounts.Where(s => s.UserId == userID);

                var accountactivity = Db.NgpLogsUserAccounts.ToList().Select(Mapper.Map<NgpLogsUserAccount, LogsAccountDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/adminlogscontractor/get")]
        public IHttpActionResult AdminLogsforContractor()


        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var contractoractivity = Db.NgpLogsContractors.ToList().Select(Mapper.Map<NgpLogsContractor, LogsContractorDTO>);
                return Ok(contractoractivity.OrderByDescending(x => x.Id).Take(5));
            }
            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsContractors.Where(s => s.UserId == userID);

                var contractoractivity = Db.NgpLogsContractors.ToList().Select(Mapper.Map<NgpLogsContractor, LogsContractorDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }

            return Ok();

        }



        [HttpGet]
        [Route("api/adminlogsforcontract/get")]
        public IHttpActionResult AdminLogsforContract()
        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var contractactivity = Db.NgpLogsContracts.ToList().Select(Mapper.Map<NgpLogsContract, LogsContractDTO>);
                return Ok(contractactivity.OrderByDescending(x => x.Id).Take(5));
            }
            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsContracts.Where(s => s.UserId == userID);

                var contractactivity = Db.NgpLogsContracts.ToList().Select(Mapper.Map<NgpLogsContract, LogsContractDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }
            return Ok();
        }



        [HttpGet]
        [Route("api/adminlogsforpayment/get")]
        public IHttpActionResult AdminLogsforPayment()
        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];

            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var payment = Db.NgpLogsPayments.ToList().Select(Mapper.Map<NgpLogsPayment, LogsPaymentDTO>);
                return Ok(payment.OrderByDescending(x => x.Id).Take(5));
            }
            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsPayments.Where(s => s.UserId == userID);

                var payment = Db.NgpLogsPayments.ToList().Select(Mapper.Map<NgpLogsPayment, LogsPaymentDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }
            return Ok();
        }


        [HttpGet]
        [Route("api/adminlogsprojects/get")]
        public IHttpActionResult AdminLogsforProject()
        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];

            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var project = Db.NgpLogsProjects.ToList().Select(Mapper.Map<NgpLogsProject, LogsProjectDTO>);
                return Ok(project.OrderByDescending(x => x.Id).Take(5));
            }
            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsProjects.Where(s => s.UserId == userID);

                var project = Db.NgpLogsProjects.ToList().Select(Mapper.Map<NgpLogsProject, LogsProjectDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }
            return Ok();
        }


        [HttpGet]
        [Route("api/adminlogssched/get")]
        public IHttpActionResult AdminLogsforSched()
        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];

            if ((int)HttpContext.Current.Session["Role_Id"] == 1)
            {
                var sched = Db.NgpLogsScheds.ToList().Select(Mapper.Map<NgpLogsSched, LogsSchedDTO>);
                return Ok(sched.OrderByDescending(x => x.Id).Take(5));
            }

            else if ((int)HttpContext.Current.Session["Role_Id"] != 1)
            {
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                var message = Db.NgpLogsScheds.Where(s => s.UserId == userID);

                var sched = Db.NgpLogsScheds.ToList().Select(Mapper.Map<NgpLogsSched, LogsSchedDTO>);
                return Ok(message.OrderByDescending(x => x.Id).Take(5));
            }
            return Ok();
        }
    }
}
