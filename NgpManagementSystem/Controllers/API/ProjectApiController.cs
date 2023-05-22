using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using NgpManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

            var sess_id = (int)HttpContext.Current.Session["LoginID"];
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
                project.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                project.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving userId depend in UserId of user login
                project.UserName = Db.NgpUsers.FirstOrDefault(o=>o.Id== sess_id)?.UserName; //saving username depend in username of user login
                project.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving name depend in login
                Db.ngp_projects.Add(project);
            }

            Db.NgpLogsProjects.Add(new NgpLogsProject()
            {

                Date = DateTime.Now,
                Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                LogMessage = "Added a Project " + "SiteCode Name: " + projectDTO.site_code,
                UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.NgpRole.RoleName,

            });

            Db.SaveChanges();

            return Ok();
        }

    }
}
