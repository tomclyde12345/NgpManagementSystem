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
    public class AccountController : Controller
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        // GET: Account
        public ActionResult Index()
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "NgpManagement");
            }
            return View();
        }
        //SERVERSIDE DATATABLES
        public ActionResult GetUserDatatable()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (NgpdbmsEntities Db = new NgpdbmsEntities())

            {
                IQueryable<NgpUser> userlist = Db.NgpUsers;

                //SHOWING FILTER DATA BASE ON ROLE ID  DEPENDENT IN LOGIN ID
                var sess_id = (int)Session["LoginID"];

                if ((int)Session["Role_Id"] != 1)
                {
                    userlist = userlist.Where(d => d.Id == sess_id);
                }



                int totalrows = userlist.Count();

                if (!string.IsNullOrEmpty(searchValue))//FILTER SEARCH
                {
                    userlist = userlist.
                        Where(x => x.Id.ToString().Contains(searchValue.ToLower()) ||
                            x.Name.ToString().Contains(searchValue.ToLower()) ||
                            x.Email.ToLower().Contains(searchValue.ToLower()) ||
                            x.UserName.ToString().Contains(searchValue.ToLower()) ||
                            x.NgpRole.RoleName.ToString().Contains(searchValue.ToLower()));


                }

                int totalrowsafterfiltering = userlist.Count();
                //sorting
                userlist = userlist.OrderBy(sortColumnName + " " + sortDirection)
                    .OrderByDescending(a => a.Id); //ADD SYSTEM LINQ DYNAMINC IN NUGGET MANAGER(DOWNLOAD)

                //paging
                userlist = userlist.Skip(start).Take(length);



                var HouseholdVM = userlist.Select(user => new UserListVM()
                {

                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    RoleID = user.NgpRole.RoleName,
                   

                }).ToList();


                return Json(new { data = HouseholdVM, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult AdminNameViewinProfile() //IMAGE AND NAME VIEW IN DASHBOARD
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }


            var adminnameviewinprofile = Db.NgpUsers.ToList();


            var sess_id = (int)Session["LoginID"];

            if ((int)Session["Role_Id"] == 1)
            {
                adminnameviewinprofile = adminnameviewinprofile.Where(d => d.Id == sess_id).ToList();
            }
            else

             if ((int)Session["Role_Id"] != 1)
            {
                adminnameviewinprofile = adminnameviewinprofile.Where(d => d.Id == sess_id).ToList();
            }


            return PartialView(adminnameviewinprofile);
        }

        public ActionResult DisplayPicNameandRole() //DISPLAY
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }


            var adminnameviewinprofile = Db.NgpUsers.ToList();


            var sess_id = (int)Session["LoginID"];

            if ((int)Session["Role_Id"] == 1)
            {
                adminnameviewinprofile = adminnameviewinprofile.Where(d => d.Id == sess_id).ToList();
            }
            else

             if ((int)Session["Role_Id"] != 1)
            {
                adminnameviewinprofile = adminnameviewinprofile.Where(d => d.Id == sess_id).ToList();
            }


            return PartialView(adminnameviewinprofile);
        }

        public ActionResult DisplayPicture() //DISPLAY
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }


            var uploadpic = Db.NgpUploads.ToList();


            var sess_id = (int)Session["LoginID"];

            if ((int)Session["Role_Id"] == 1)
            {
                uploadpic = uploadpic.Where(d => d.AccountId == sess_id).ToList();
            }
            else

             if ((int)Session["Role_Id"] != 1)
            {
                uploadpic = uploadpic.Where(d => d.AccountId == sess_id).ToList();
            }


            return PartialView(uploadpic);
        }


        public ActionResult DisplayPictureSideTop() //DISPLAY
        {
            if (Session["Role_Id"] == null)
            {
                return RedirectToAction("logout", "Account");
            }


            var uploadpic = Db.NgpUploads.ToList();


            var sess_id = (int)Session["LoginID"];

            if ((int)Session["Role_Id"] == 1)
            {
                uploadpic = uploadpic.Where(d => d.AccountId == sess_id).ToList();
            }
            else

             if ((int)Session["Role_Id"] != 1)
            {
                uploadpic = uploadpic.Where(d => d.AccountId == sess_id).ToList();
            }


            return PartialView(uploadpic);
        }
    }
}