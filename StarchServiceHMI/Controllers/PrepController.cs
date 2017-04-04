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

        public ActionResult PREP1Desanding()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep1Unit/PREP1Desanding");
        }

        public ActionResult PREP1Washer()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep1Unit/PREP1Washer");
        }

        public ActionResult PREP1Chopper()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep1Unit/PREP1Chopper");
        }

        public ActionResult PREP1Rasper()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep1Unit/PREP1Rasper");
        }


        public ActionResult PREP2Over()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PREP2Desanding()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep2Unit/PREP2Desanding");
        }

        public ActionResult PREP2Washer()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep2Unit/PREP2Washer");
        }

        public ActionResult PREP2Chopper()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep2Unit/PREP2Chopper");
        }

        public ActionResult PREP2Rasper()
        {
            ViewBag.Message = "Your contact page.";

            return View("Prep2Unit/PREP2Rasper");
        }



    }
}