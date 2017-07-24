using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            string controllerName = Request.QueryString["controller-name"];
            ViewData["controllerName"] = controllerName;
            return View();
        }
    }
}