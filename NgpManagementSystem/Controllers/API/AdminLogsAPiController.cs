using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var accountactivity = Db.NgpLogsUserAccounts.ToList().Select(Mapper.Map<NgpLogsUserAccount, LogsAccountDTO>);
            return Ok(accountactivity.OrderByDescending(x => x.Id).Take(5));
        }

        [HttpGet]
        [Route("api/adminlogscontractor/get")]
        public IHttpActionResult AdminLogsforContractor()


        {
            var contractoractivity = Db.NgpLogsContractors.ToList().Select(Mapper.Map<NgpLogsContractor, LogsContractorDTO>);
            return Ok(contractoractivity.OrderByDescending(x => x.Id).Take(5));
        }



        [HttpGet]
        [Route("api/adminlogsforcontract/get")]
        public IHttpActionResult AdminLogsforContract()


        {
            var contractactivity = Db.NgpLogsContracts.ToList().Select(Mapper.Map<NgpLogsContract, LogsContractDTO>);
            return Ok(contractactivity.OrderByDescending(x => x.Id).Take(5));
        }



        [HttpGet]
        [Route("api/adminlogsforpayment/get")]
        public IHttpActionResult AdminLogsforPayment()


        {
            var payment = Db.NgpLogsPayments.ToList().Select(Mapper.Map<NgpLogsPayment, LogsPaymentDTO>);
            return Ok(payment.OrderByDescending(x => x.Id).Take(5));
        }


        [HttpGet]
        [Route("api/adminlogsprojects/get")]
        public IHttpActionResult AdminLogsforProject()


        {
            var project = Db.NgpLogsProjects.ToList().Select(Mapper.Map<NgpLogsProject, LogsProjectDTO>);
            return Ok(project.OrderByDescending(x => x.Id).Take(5));
        }

        [HttpGet]
        [Route("api/adminlogssched/get")]
        public IHttpActionResult AdminLogsforSched()


        {
            var sched = Db.NgpLogsScheds.ToList().Select(Mapper.Map<NgpLogsSched, LogsSchedDTO>);
            return Ok(sched.OrderByDescending(x => x.Id).Take(5));
        }
    }
}
