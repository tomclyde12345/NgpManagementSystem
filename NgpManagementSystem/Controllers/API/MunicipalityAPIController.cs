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
    public class MunicipalityAPIController : ApiController
    {

        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        //GET DATA FOR MUNICIPALITY
        [Route("api/getmunicipality/municipality/get")]
        public IHttpActionResult GetMunicipality()
        {
            var municipality = Db.NgpMunicipalities.ToList().Select(Mapper.Map<NgpMunicipality, MunicipalityDTO>);
            return Ok(municipality);
        }


        [Route("api/barangaylist/get/{id}")]
        public IHttpActionResult GetgroupQueryGroupId(int id)
        {
            var barangay = Db.NgpBarangays.Where(d => d.MunicipalityId == id).ToList().Select(Mapper.Map<NgpBarangay, BarangayDTO>);
            if (barangay == null)
            {
                return NotFound();
            }

            return Ok(barangay);
        }
    }
}
