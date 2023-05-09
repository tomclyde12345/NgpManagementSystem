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
    public class SchedController : Controller
    {
        // GET: Sched
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
        public ActionResult GetSchedTable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_sched> schedlist = Db.ngp_sched;



                int totalrows = schedlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    schedlist = schedlist.
                        Where(x => x.schedID.ToString().Contains(searchValue.ToLower()) ||
                          x.ors_no.ToString().Contains(searchValue.ToLower()) ||
                           x.ors_date.ToString().Contains(searchValue.ToLower()) ||
                            x.dv_no.ToString().Contains(searchValue.ToLower()) ||
                             x.dv_date.ToString().Contains(searchValue.ToLower()) ||
                             x.lddap_no.ToString().Contains(searchValue.ToLower()) ||
                             x.contractor_name.ToString().Contains(searchValue.ToLower()) ||
                            x.lddap_date.ToString().Contains(searchValue.ToLower()));


                }


                int totalrowsafterfiltering = schedlist.Count();
                //sorting
                schedlist = schedlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.schedID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                schedlist = schedlist.Skip(start).Take(length);



                var SchedVIEW = schedlist.Select(paymentsdata => new SchedVM()
                {

                    schedID = paymentsdata.schedID,
                    ors_no = paymentsdata.ors_no,
                    ors_date = paymentsdata.ors_date,
                    dv_no = paymentsdata.dv_no,
                    dv_date = paymentsdata.dv_date,
                    lddap_no = paymentsdata.lddap_no,
                    lddap_date = paymentsdata.lddap_date,
                    contractor_name = paymentsdata.contractor_name,

                }).ToList();


                return Json(new { data = SchedVIEW, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }
    }
}