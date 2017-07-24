using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class DewController : Controller
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

        // GET: Dew
        public ActionResult DEWOver()
        {
            List<TagConfig> list = getTagConfigList("DEWOverview");
            ViewData["TagConfigObject"] = list;
            return View();
        }

        

        public ActionResult DEWController()
        {
            return View();
        }
    }
}