using NgpManagementSystem.Models;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NgpManagementSystem.Controllers
{
    public class NgpManagementController : Controller
    {
        // GET: Login
        public NgpdbmsEntities Db = new NgpdbmsEntities();
        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }
        public ActionResult Login() //the same name to login
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(NgpUser log) //the same name to login
        {
            ScryptEncoder encoder = new ScryptEncoder();

            var result = Db.NgpUsers.SingleOrDefault(a => a.UserName == log.UserName);


            if (result != null)
            {
                if (!encoder.Compare(log.Password, result.Password))
                {
                    ViewBag.Message = "Incorrect Username or Password";
                    return View(log);
                }


                Session["LoginedTime"] = DateTime.Now.ToLongDateString();
                Session["LoginID"] = result.Id;

                Session["Role_Id"] = result.RoleID;

                FormsAuthentication.SetAuthCookie(result.UserName, false);

                //IF admin
                if (result.RoleID == 1)
                {
                    return RedirectToAction("Index", "Admin");

                }
                else 
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ViewBag.Message = "Incorrect Username or Password";
            }

            return View(log);
        }

        public ActionResult Logout()
        {

            Session["Role_Id"] = null;
            FormsAuthentication.SignOut();
            return Redirect("Login");
        }
    }
}