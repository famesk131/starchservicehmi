using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class PrepController : Controller
    {
        public static List<TagConfig> getTagConfigList(string webpageName)
        {
            SqlConnection conn = ConnectionBuilder.getConnection();
            string sql = "SELECT * FROM Tag_Config WHERE webpage = @param1";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            sqlCom.Parameters.AddWithValue("@param1", webpageName);
            conn.Open();

            List<TagConfig> list = new List<TagConfig>();
            using (SqlDataReader reader = sqlCom.ExecuteReader())
            {
                while (reader.Read())
                {
                    TagConfig tc = new TagConfig();
                    tc.Id = (int)reader["id"];
                    tc.Tag_id = reader["tag_id"].ToString();
                    tc.Webpage = reader["webpage"].ToString();
                    tc.Tag_name = reader["tag_name"].ToString();
                    list.Add(tc);
                }
            }
            conn.Close();
            return list;
        }

        public ActionResult PREP1Over()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP1Overview");
            ViewData["TagConfigObject"] = list;
            return View();
        }

        public ActionResult PREP1Desanding()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP1Desanding");
            ViewData["TagConfigObject"] = list;
            return View("Prep1Unit/PREP1Desanding");
        }

        public ActionResult PREP1Washer()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP1Washer");
            ViewData["TagConfigObject"] = list;
            return View("Prep1Unit/PREP1Washer");
        }

        public ActionResult PREP1Chopper()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP1Chopper");
            ViewData["TagConfigObject"] = list;
            return View("Prep1Unit/PREP1Chopper");
        }

        public ActionResult PREP1Rasper()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP1Rasper");
            ViewData["TagConfigObject"] = list;
            return View("Prep1Unit/PREP1Rasper");
        }


        public ActionResult PREP2Over()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP2Overview");
            ViewData["TagConfigObject"] = list;
            return View();
        }

        public ActionResult PREP2Desanding()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP2Desanding");
            ViewData["TagConfigObject"] = list;
            return View("Prep2Unit/PREP2Desanding");
        }

        public ActionResult PREP2Washer()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP2Washer");
            ViewData["TagConfigObject"] = list;
            return View("Prep2Unit/PREP2Washer");
        }

        public ActionResult PREP2Chopper()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP2Chopper");
            ViewData["TagConfigObject"] = list;
            return View("Prep2Unit/PREP2Chopper");
        }

        public ActionResult PREP2Rasper()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("PREP2Rasper");
            ViewData["TagConfigObject"] = list;
            return View("Prep2Unit/PREP2Rasper");
        }



    }
}