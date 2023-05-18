using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgpManagementSystem.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            var maintenance = Db.NgpMaintenanceModes.ToList();
            return Json(maintenance, JsonRequestBehavior.AllowGet);
        }

    }
}