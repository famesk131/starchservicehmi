using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class DewController : Controller
    {
        // GET: Dew
        public ActionResult DEWOver()
        {
            return View();
        }

        public ActionResult DEWManual()
        {
            return View();
        }

        public ActionResult DEWAuto()
        {
            return View();
        }
    }
}