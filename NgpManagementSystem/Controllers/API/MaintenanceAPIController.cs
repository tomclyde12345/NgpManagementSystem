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
    public class MaintenanceAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }



        [HttpPost]
        [Route("api/maintenancemode/getmaintenancemode/{id}")]
        public IHttpActionResult UpdateMaintenanceMode(MaintenanceModeDto maintenance)
        {


            if (ModelState.IsValid)
            {
                var usersInDb = Db.NgpMaintenanceModes.Single(c => c.Id == maintenance.Id);
                usersInDb.Id = 1;
                usersInDb.isActive = Convert.ToBoolean(maintenance.isActive);
                usersInDb.Message = maintenance.Message;


            }
            Db.SaveChanges();



            return Ok();

        }

    }
}
