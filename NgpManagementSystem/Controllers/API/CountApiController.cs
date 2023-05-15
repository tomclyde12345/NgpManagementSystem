using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class CountApiController : ApiController
    {

        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        [Route("api/totalusercount/count")]
        public IHttpActionResult GetTotalUserAccount()
        {
            var usercount = Db.NgpUsers.ToList();
            return Ok(usercount.Count);
        }

        [Route("api/totalcontractor/count")]
        public IHttpActionResult GetTotalContractor()
        {
            var contractor = Db.ngp_contractor.ToList();
            return Ok(contractor.Count);
        }

        [Route("api/totalprojects/count")]
        public IHttpActionResult GetTotalProjects()
        {
            var projects = Db.ngp_projects.ToList();
            return Ok(projects.Count);
        }

        [Route("api/totalcontract/count")]
        public IHttpActionResult GetContracts()
        {
            var contract = Db.ngp_contract.ToList();
            return Ok(contract.Count);
        }

    }
}
