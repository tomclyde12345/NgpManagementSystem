using NgpManagementSystem.Models;
using NgpManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace NgpManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }
        public ActionResult Create()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }

        //SERVERSIDE DATATABLES
        public ActionResult GetProjecttable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_projects> projectlist = Db.ngp_projects;



                int totalrows = projectlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    projectlist = projectlist.
                        Where(x => x.projectID.ToString().Contains(searchValue.ToLower()) ||
                            x.site_code.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpMunicipality.MunicipalityName.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpBarangay.BarangayName.ToString().Contains(searchValue.ToLower()) ||
                            x.area.ToString().Contains(searchValue.ToLower()) ||
                            x.year_form.ToString().Contains(searchValue.ToLower()) ||
                            x.penro.ToString().Contains(searchValue.ToLower()) ||
                             x.cenro.ToString().Contains(searchValue.ToLower()) ||
                            x.region.ToString().Contains(searchValue.ToLower()));


                }

                int totalrowsafterfiltering = projectlist.Count();
                //sorting
                projectlist = projectlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.projectID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                projectlist = projectlist.Skip(start).Take(length);



                var Projectvmlist = projectlist.Select(projectdata => new ProjectVM()
                {

                    projectID = projectdata.projectID,
                    area = projectdata.area,
                    site_code = projectdata.site_code,
                    location_barangay = projectdata.NgpBarangay.BarangayName,
                    location_municipality = projectdata.NgpMunicipality.MunicipalityName,
                    penro = projectdata.penro,
                    cenro = projectdata.cenro,
                    region = projectdata.region,
                    year_form = projectdata.year_form,


                }).ToList();


                return Json(new { data = Projectvmlist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }


        }
    }
}