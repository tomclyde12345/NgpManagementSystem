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
    }
}
