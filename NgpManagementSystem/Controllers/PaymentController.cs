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
    public class PaymentController : Controller
    {
        // GET: Payment
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
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
        public ActionResult GetPaymentTable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<ngp_payment> paymentlist = Db.ngp_payment;



                int totalrows = paymentlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    paymentlist = paymentlist.
                        Where(x => x.paymentID.ToString().Contains(searchValue.ToLower()) ||
                          x.contractorName.ToString().Contains(searchValue.ToLower()) ||
                            x.num_release.ToString().Contains(searchValue.ToLower()));


                }
             

                int totalrowsafterfiltering = paymentlist.Count();
                //sorting
                paymentlist = paymentlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.paymentID); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                paymentlist = paymentlist.Skip(start).Take(length);



                var PaymentView = paymentlist.Select(paymentsdata => new PaymentVM()
                {

                    paymentID = paymentsdata.paymentID,
                 
                    contractorName = paymentsdata.contractorName,
                    yearestablishedId = paymentsdata.NgpYear.Name,




                }).ToList();


                return Json(new { data = PaymentView, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }
    }
}