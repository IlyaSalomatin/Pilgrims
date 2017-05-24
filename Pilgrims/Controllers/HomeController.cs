using Pilgrims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pilgrims.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult AddAndCorrect()
        {
            return View();
        }

        public ActionResult Resalt()
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();

            return PartialView(hm);
        }
    }
}
