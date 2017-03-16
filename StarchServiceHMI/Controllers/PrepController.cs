using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class PrepController : Controller
    {
        public ActionResult PREP1Over()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PREP2Over()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}