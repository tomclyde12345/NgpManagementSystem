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
    public class AdminActivityLogsController : Controller
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();
        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContractorLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult ProjectLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult AccountLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }

        public ActionResult PaymentLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }


        public ActionResult ContractLogs()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }

        public ActionResult GetAdminContractorlogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpLogsContractor> contractorloglist = Db.NgpLogsContractors;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}

                int totalrows = contractorloglist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractorloglist = contractorloglist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()));

                }


                int totalrowsafterfiltering = contractorloglist.Count();
                //sorting
                contractorloglist = contractorloglist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractorloglist = contractorloglist.Skip(start).Take(length);



                var contractorview = contractorloglist.Select(user => new ContractorLogs()
                {

                    Id = user.Id,
                    Date = user.Date,
                    UserName = user.UserName,
                    Name = user.Name,
                    LogMessage = user.LogMessage,  
                    RoleId = user.NgpRole.RoleName,
                

                }).ToList();


                return Json(new { data = contractorview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }


        public ActionResult GetAdminProjectlogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpLogsProject> projectloglist = Db.NgpLogsProjects;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}

                int totalrows = projectloglist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    projectloglist = projectloglist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()));

                }


                int totalrowsafterfiltering = projectloglist.Count();
                //sorting
                projectloglist = projectloglist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                projectloglist = projectloglist.Skip(start).Take(length);



                var projectview = projectloglist.Select(user => new ProjectLogs()
                {

                    Id = user.Id,
                    Date = user.Date,
                    UserName = user.UserName,
                    Name = user.Name,
                    LogMessage = user.LogMessage,
                    RoleId = user.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = projectview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }
        }



        public ActionResult GetAdminAccountLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpLogsUserAccount> accountlogslist = Db.NgpLogsUserAccounts;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}

                int totalrows = accountlogslist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    accountlogslist = accountlogslist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()));

                }


                int totalrowsafterfiltering = accountlogslist.Count();
                //sorting
                accountlogslist = accountlogslist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                accountlogslist = accountlogslist.Skip(start).Take(length);



                var accountview = accountlogslist.Select(user => new AccountLogs()
                {

                    Id = user.Id,
                    Date = user.Date,
                    UserName = user.UserName,
                    Name = user.Name,
                    LogMessage = user.LogMessage,
                    RoleId = user.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = accountview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }



        public ActionResult GetAdminPaymentLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpLogsPayment> paymentloglist = Db.NgpLogsPayments;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}

                int totalrows = paymentloglist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    paymentloglist = paymentloglist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()));

                }


                int totalrowsafterfiltering = paymentloglist.Count();
                //sorting
                paymentloglist = paymentloglist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                paymentloglist = paymentloglist.Skip(start).Take(length);



                var paymentview = paymentloglist.Select(user => new PaymentLogs()
                {

                    Id = user.Id,
                    Date = user.Date,
                    UserName = user.UserName,
                    Name = user.Name,
                    LogMessage = user.LogMessage,
                    RoleId = user.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = paymentview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }


        public ActionResult GetAdminContractLogs()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpLogsContract> contractloglist = Db.NgpLogsContracts;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                //var sess_id = (int)Session["LoginID"];

                //if ((int)Session["Role_Id"] != 1)
                //{
                //    userlist = userlist.Where(d => d.Id == sess_id);
                //}

                int totalrows = contractloglist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    contractloglist = contractloglist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Date.ToString().Contains(searchValue.ToLower()) ||
                            x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.LogMessage.ToString().Contains(searchValue.ToLower()));

                }


                int totalrowsafterfiltering = contractloglist.Count();
                //sorting
                contractloglist = contractloglist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                contractloglist = contractloglist.Skip(start).Take(length);



                var contractview = contractloglist.Select(user => new ContractLogs()
                {

                    Id = user.Id,
                    Date = user.Date,
                    UserName = user.UserName,
                    Name = user.Name,
                    LogMessage = user.LogMessage,
                    RoleId = user.NgpRole.RoleName,


                }).ToList();


                return Json(new { data = contractview, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }

    }
}