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






        //GET DATA FOR MUNICIPALITY
        [Route("api/getlocationmunicipality/locationmunicipality/get")]
        public IHttpActionResult GetlocationMunicipality()
        {
            var municipality = Db.NgplocationMunicipalities.ToList().Select(Mapper.Map<NgplocationMunicipality, LocationMunicipalityDTO>);
            return Ok(municipality);
        }


        [Route("api/locationbarangaylist/get/{id}")]
        public IHttpActionResult GetLocationbarangay(int id)
        {
            var barangay = Db.NgplocationBarangays.Where(d => d.MunicipalityId == id).ToList().Select(Mapper.Map<NgplocationBarangay, LocationBarangayDTO>);
            if (barangay == null)
            {
                return NotFound();
            }

            return Ok(barangay);
        }
    }
}
