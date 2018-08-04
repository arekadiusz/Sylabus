using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sylabus.Models;

namespace Sylabus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Siatkigodzin()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();

        }
        public ActionResult GetList()
        {
            using (sylabusWMIEntities db = new sylabusWMIEntities())
            {
                var empList = db.Roles.ToList();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}