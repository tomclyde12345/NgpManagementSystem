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
                            x.contractor_type.ToString().Contains(searchValue.ToLower()));


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
                    address_barangay = user.NgpBarangay.BarangayName,
                    address_municipality = user.NgpMunicipality.MunicipalityName,
                    contractor_type = user.contractor_type,


                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }

       
    }
}