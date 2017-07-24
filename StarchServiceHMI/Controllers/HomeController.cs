using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;


namespace StarchServiceHMI.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Overview()
        {
            ViewBag.Message = "Your contact page.";
            List<TagConfig> list = getTagConfigList("Overview");
            ViewData["TagConfigObject"] = list;

            return View();
        }

        public ActionResult Alarm()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        

        public ActionResult CEX()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FEX()
        {
            ViewBag.Message = "Your contact page.";

            return View("Section/FEX");
        }

        public ActionResult VIB()
        {
            ViewBag.Message = "Your contact page.";

            return View("Section/VIB");
        }

        public ActionResult SEP()
        {
            ViewBag.Message = "Your contact page.";

            return View("Section/SEP");
        }

        public ActionResult DEW()
        {
            ViewBag.Message = "Your contact page.";

            return View("Section/DEW");
        }

        public ActionResult FLD()
        {
            ViewBag.Message = "Your contact page.";

            return View("Section/FLD");
        }
    }
}