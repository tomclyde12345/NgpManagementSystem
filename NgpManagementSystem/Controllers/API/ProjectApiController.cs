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
    public class ProjectApiController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }


        //CREATE/ PROJECT SAVING METHODS 
        [HttpPost
        ]
        [Route("api/project/post")
        ]
        public IHttpActionResult SaveProject(ProjectDTO projectDTO)
        {
            var project = Mapper.Map<ProjectDTO, ngp_projects>(projectDTO);

            if (projectDTO.projectID == 0)
            {

                project.site_code = projectDTO.site_code;
                project.location_municipality = projectDTO.location_municipality;
                project.location_barangay = projectDTO.location_barangay;
                project.area = projectDTO.area;
                project.year_form = projectDTO.year_form;
                project.penro = projectDTO.penro;
                project.cenro = projectDTO.cenro;
                project.region = projectDTO.region;
                Db.ngp_projects.Add(project);
            }


            Db.SaveChanges();

            return Ok();
        }

    }
}
