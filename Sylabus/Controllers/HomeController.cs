using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Wykladowca()
        {
            return View();
        }
    }
}