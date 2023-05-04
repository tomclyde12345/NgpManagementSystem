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

    public class AccountAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        //get data for user
        [HttpGet]
        [Route("api/accountdata/get")]
        public IHttpActionResult GetAccountdata()
        {
            var usergetdata = Db.NgpUsers.ToList().Select(Mapper.Map<NgpUser, AccountDTO>);
            return Ok(usergetdata);
        }
    }
}
