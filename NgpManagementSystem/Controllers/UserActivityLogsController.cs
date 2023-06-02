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
    public class UserActivityLogsController : Controller
    {
        // GET: UserActivityLogs
        public NgpdbmsEntities Db = new NgpdbmsEntities();
        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserContractorLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult UserProjectLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }

        public ActionResult UserContractLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult UserPaymentLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult UserAccountLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }



        public ActionResult GetUserContractorLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())
            {
                IQueryable<NgpLogsContractor> logsusercontractorlist = Db.NgpLogsContractors;

                logsusercontractorlist = (IQueryable<NgpLogsContractor>)Db.NgpLogsContractors;

                int totalrows = logsusercontractorlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    logsusercontractorlist = logsusercontractorlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()));

                }
                //Query UserId Show 
                var sess_id = (int)Session["LoginID"];
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                if ((int)Session["Role_Id"] != 1)

                {
                    logsusercontractorlist = logsusercontractorlist.Where(d => d.UserId == userID);
                }
                //

                int totalrowsafterfiltering = logsusercontractorlist.Count();
                //sorting
                logsusercontractorlist = logsusercontractorlist.OrderBy(sortColumnName + " " + sortDirection).OrderByDescending(x => x.Id);

                //paging
                logsusercontractorlist = logsusercontractorlist.Skip(start).Take(length);



                var ContractorView = logsusercontractorlist.Select(logs => new ContractorLogs()
                {

                    Id = logs.Id,
                    LogMessage = logs.LogMessage,
                    Name = logs.Name,
                    UserName = logs.UserName,
                    Date = logs.Date,
                    RoleId = logs.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = ContractorView, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);



            }

        }



        public ActionResult GetUserProjectLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())
            {
                IQueryable<NgpLogsProject> logsuserprojectlist = Db.NgpLogsProjects;

                logsuserprojectlist = (IQueryable<NgpLogsProject>)Db.NgpLogsProjects;

                int totalrows = logsuserprojectlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    logsuserprojectlist = logsuserprojectlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()));

                }
                //Query UserId Show 
                var sess_id = (int)Session["LoginID"];
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                if ((int)Session["Role_Id"] != 1)

                {
                    logsuserprojectlist = logsuserprojectlist.Where(d => d.UserId == userID);
                }
                //

                int totalrowsafterfiltering = logsuserprojectlist.Count();
                //sorting
                logsuserprojectlist = logsuserprojectlist.OrderBy(sortColumnName + " " + sortDirection).OrderByDescending(x => x.Id);

                //paging
                logsuserprojectlist = logsuserprojectlist.Skip(start).Take(length);



                var ProjectView = logsuserprojectlist.Select(logs => new ProjectLogs()
                {

                    Id = logs.Id,
                    LogMessage = logs.LogMessage,
                    Name = logs.Name,
                    UserName = logs.UserName,
                    Date = logs.Date,
                    RoleId = logs.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = ProjectView, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);



            }

        }

        public ActionResult GetUserContractLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())
            {
                IQueryable<NgpLogsContract> logscontractlist = Db.NgpLogsContracts;

                logscontractlist = (IQueryable<NgpLogsContract>)Db.NgpLogsContracts;

                int totalrows = logscontractlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    logscontractlist = logscontractlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()));

                }
                //Query UserId Show 
                var sess_id = (int)Session["LoginID"];
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                if ((int)Session["Role_Id"] != 1)

                {
                    logscontractlist = logscontractlist.Where(d => d.UserId == userID);
                }
                //

                int totalrowsafterfiltering = logscontractlist.Count();
                //sorting
                logscontractlist = logscontractlist.OrderBy(sortColumnName + " " + sortDirection).OrderByDescending(x => x.Id);

                //paging
                logscontractlist = logscontractlist.Skip(start).Take(length);



                var ContractVIEW = logscontractlist.Select(logs => new ContractLogs()
                {

                    Id = logs.Id,
                    LogMessage = logs.LogMessage,
                    Name = logs.Name,
                    UserName = logs.UserName,
                    Date = logs.Date,
                    RoleId = logs.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = ContractVIEW, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);



            }

        }


        public ActionResult GetUserPaymentsLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())
            {
                IQueryable<NgpLogsPayment> logspaymenttlist = Db.NgpLogsPayments;

                logspaymenttlist = (IQueryable<NgpLogsPayment>)Db.NgpLogsPayments;

                int totalrows = logspaymenttlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    logspaymenttlist = logspaymenttlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()));

                }
                //Query UserId Show 
                var sess_id = (int)Session["LoginID"];
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                if ((int)Session["Role_Id"] != 1)

                {
                    logspaymenttlist = logspaymenttlist.Where(d => d.UserId == userID);
                }
                //

                int totalrowsafterfiltering = logspaymenttlist.Count();
                //sorting
                logspaymenttlist = logspaymenttlist.OrderBy(sortColumnName + " " + sortDirection).OrderByDescending(x => x.Id);

                //paging
                logspaymenttlist = logspaymenttlist.Skip(start).Take(length);



                var PAYMENTVIEW = logspaymenttlist.Select(logs => new PaymentLogs()
                {

                    Id = logs.Id,
                    LogMessage = logs.LogMessage,
                    Name = logs.Name,
                    UserName = logs.UserName,
                    Date = logs.Date,
                    RoleId = logs.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = PAYMENTVIEW, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);



            }

        }




        public ActionResult GetUserAccountLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())
            {
                IQueryable<NgpLogsUserAccount> logsuseraccountlist = Db.NgpLogsUserAccounts;

                logsuseraccountlist = (IQueryable<NgpLogsUserAccount>)Db.NgpLogsUserAccounts;

                int totalrows = logsuseraccountlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    logsuseraccountlist = logsuseraccountlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()));

                }
                //Query UserId Show 
                var sess_id = (int)Session["LoginID"];
                var userID = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id;
                if ((int)Session["Role_Id"] != 1)

                {
                    logsuseraccountlist = logsuseraccountlist.Where(d => d.UserId == userID);
                }
                //

                int totalrowsafterfiltering = logsuseraccountlist.Count();
                //sorting
                logsuseraccountlist = logsuseraccountlist.OrderBy(sortColumnName + " " + sortDirection).OrderByDescending(x => x.Id);

                //paging
                logsuseraccountlist = logsuseraccountlist.Skip(start).Take(length);



                var AccountView = logsuseraccountlist.Select(logs => new AccountLogs()

                {

                    Id = logs.Id,
                    LogMessage = logs.LogMessage,
                    Name = logs.Name,
                    UserName = logs.UserName,
                    Date = logs.Date,
                    RoleId = logs.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = AccountView, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }

    }
}