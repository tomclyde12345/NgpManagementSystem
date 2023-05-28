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
    public class ContractorController : Controller
    {
        // GET: Contractor
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
        public ActionResult GetContractorTable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_contractor> contractorlist = Db.ngp_contractor;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}



                int totalrows = contractorlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractorlist = contractorlist.
                        Where(x => x.contractorID.ToString().Contains(searchValue.ToLower()) ||
                            x.contractor_name.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpMunicipality.MunicipalityName.ToLower().Contains(searchValue.ToLower()) ||
                            x.NgpBarangay.BarangayName.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpRole.RoleName.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpUser.UserName.ToString().Contains(searchValue.ToLower()) ||
                             x.NgpUser.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.contractor_type.ToString().Contains(searchValue.ToLower()));


                }

                //SEARCH FILTER  ROLE
                if (!string.IsNullOrEmpty(Request["columns[5][search][value]"]))
                {
                    var filtersearcroles = Request["columns[5][search][value]"].ToLowerInvariant();
                    contractorlist = contractorlist.Where(x => x.NgpRole != null && x.NgpRole.RoleName.ToLower().Contains(filtersearcroles)).OrderBy(x => x.contractorID);
                }


                //SEARCH FILTER  CONTRACTOR NAME
                //if (!string.IsNullOrEmpty(Request["columns[1][search][value]"]))
                //{
                //    var filtersearchcontractor= Request["columns[1][search][value]"].ToLowerInvariant();
                //    contractorlist = contractorlist.Where(x => x.contractor_name != null && x.contractor_name.ToLower().Contains(filtersearchcontractor)).OrderBy(x => x.contractorID);
                //}


                int totalrowsafterfiltering = contractorlist.Count();
                //sorting
                contractorlist = contractorlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.contractorID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractorlist = contractorlist.Skip(start).Take(length);



                var contractorview = contractorlist.Select(user => new ContractorVM()
                {

                    contractorID = user.contractorID,
                    contractor_name = user.contractor_name,
                    address_barangay = user.NgpBarangay.BarangayName,
                    address_municipality = user.NgpMunicipality.MunicipalityName,
                    contractor_type = user.contractor_type,
                    RoleId = user.NgpRole.RoleName,
                    Name = user.NgpUser.Name,
                    DateAdded = user.DateAdded,



                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }




        public ActionResult GetProjectTables()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_contractor> contractorlist = Db.ngp_contractor;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}



                int totalrows = contractorlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractorlist = contractorlist.
                        Where(x => x.area.ToString().Contains(searchValue.ToLower()) ||
                            x.cenro.ToString().Contains(searchValue.ToLower()) ||
                            x.region.ToLower().Contains(searchValue.ToLower()) ||
                            x.year_form.ToString().Contains(searchValue.ToLower()) ||
                            x.penro.ToString().Contains(searchValue.ToLower()));


                }



                int totalrowsafterfiltering = contractorlist.Count();
                //sorting
                contractorlist = contractorlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.contractorID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractorlist = contractorlist.Skip(start).Take(length);



                var contractorview = contractorlist.Select(user => new ContractorVM()
                {

                    contractorID = user.contractorID,
                    area = user.area,
                    cenro = user.cenro,
                    region = user.region,
                    location_barangay = user.NgplocationBarangay.BarangayName,
                    location_municipality = user.NgplocationMunicipality.MunicipalityName,

                    penro = user.penro,
                    year_form = user.year_form,
                    RoleId = user.NgpRole.RoleName,
                    Name = user.NgpUser.Name,
                    DateAdded = user.DateAdded,

                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult GetContractTables()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_contractor> contractorlist = Db.ngp_contractor;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}



                int totalrows = contractorlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractorlist = contractorlist.
                        Where(x => x.contractorID.ToString().Contains(searchValue.ToLower()) ||
                            //x.contractor_name.ToString().Contains(searchValue.ToLower()) ||

                            x.contractor_name.ToString().Contains(searchValue.ToLower()));


                }



                int totalrowsafterfiltering = contractorlist.Count();
                //sorting
                contractorlist = contractorlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.contractorID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractorlist = contractorlist.Skip(start).Take(length);



                var contractorview = contractorlist.Select(user => new ContractorVM()
                {

                    contractorID = user.contractorID,
                    contractor_name = user.contractor_name,
                    RoleId = user.NgpRole.RoleName,
                    Name = user.NgpUser.Name,
                    DateAdded = user.DateAdded,


                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }



        public ActionResult GetPaymenttable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_contractor> contractorlist = Db.ngp_contractor;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}



                int totalrows = contractorlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractorlist = contractorlist.
                        Where(x => x.contractorID.ToString().Contains(searchValue.ToLower()) ||
                            //x.contractor_name.ToString().Contains(searchValue.ToLower()) ||

                            x.contractor_name.ToString().Contains(searchValue.ToLower()));


                }



                int totalrowsafterfiltering = contractorlist.Count();
                //sorting
                contractorlist = contractorlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.contractorID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractorlist = contractorlist.Skip(start).Take(length);



                var contractorview = contractorlist.Select(user => new ContractorVM()
                {

                    contractorID = user.contractorID,
                    contractor_name = user.contractor_name,
                    RoleId = user.NgpRole.RoleName,
                    Name = user.NgpUser.Name,
                    DateAdded = user.DateAdded,


                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }








    }
}