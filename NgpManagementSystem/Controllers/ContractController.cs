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
    public class ContractController : Controller
    {
        // GET: Contract
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }
            return View();
        }

        public ActionResult Create()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }
            return View();
        }

        //SERVERSIDE DATATABLES
        public ActionResult GetContractTable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_contract> contractlist = Db.ngp_contract;



                int totalrows = contractlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractlist = contractlist.
                        Where(x => x.contractID.ToString().Contains(searchValue.ToLower()) ||
                        x.location_municipality.ToString().Contains(searchValue.ToLower()) ||
                          x.location_barangay.ToString().Contains(searchValue.ToLower()) ||
                            x.location_sitio.ToString().Contains(searchValue.ToLower()) ||
                              x.area.ToString().Contains(searchValue.ToLower()) ||
                                x.survival_rate.ToString().Contains(searchValue.ToLower()) ||
                                  x.ngp_contractor.contractor_name.ToString().Contains(searchValue.ToLower()) ||

                            x.site_code.ToString().Contains(searchValue.ToLower()));


                }
                //SEARCH FILTER  municipality
                if (!string.IsNullOrEmpty(Request["columns[1][search][value]"]))
                {
                    var s = Request["columns[1][search][value]"].ToLowerInvariant();
                    contractlist = contractlist.Where(x => x.NgpMunicipality != null && x.NgpMunicipality.MunicipalityName.ToLower().Contains(s));
                }

                int totalrowsafterfiltering = contractlist.Count();
                //sorting
                contractlist = contractlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.contractID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractlist = contractlist.Skip(start).Take(length);



                var ContractVMLIST = contractlist.Select(contractdata => new ContractVM()
                {

                    contractID = contractdata.contractID,
                    moa = contractdata.moa,
                    contractorName = contractdata.contractorName,
                    location_municipality = contractdata.NgpMunicipality.MunicipalityName,
                    location_barangay = contractdata.NgpBarangay.BarangayName,
                    location_sitio = contractdata.location_sitio,
                    area = contractdata.area,
                    commodity = contractdata.commodity,
                    commodity_type = contractdata.commodity_type,
                    survival_rate = contractdata.survival_rate,
                    project_name = contractdata.project_name,
                    contract_cost = contractdata.contract_cost,
                    site_code = contractdata.site_code,
                    year_established = contractdata.NgpYear.Name,
                    num_seedlings_planted = contractdata.num_seedlings_planted,
                    num_seedlings_produced = contractdata.num_seedlings_produced,
                    num_seedlings_survived = contractdata.num_seedlings_survived,
                    num_seedlings_replanted = contractdata.num_seedlings_replanted,
                    num_seedlings_survived_year1 = contractdata.num_seedlings_survived_year1,


                }).ToList();


                return Json(new { data = ContractVMLIST, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }
    }
}