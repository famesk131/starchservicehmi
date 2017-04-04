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

        public ActionResult Index()
        {
            //Laikram
            /*SqlConnection conn = new SqlConnection("Data Source=DESKTOP-87BI6EK\\FAMESK131;Initial Catalog=StarchServiceHMI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
             {
             conn.Open();
              string sql = "SELECT tag_name FROM Tag";
              string sql = "INSERT INTO Tag VALUES (@param1, @param2)";


             SqlCommand sqlCom = new SqlCommand(sql, conn);
             sqlCom.Parameters.AddWithValue("@param1", 1);
             sqlCom.Parameters.AddWithValue("@param2", "EIEI");
             sqlCom.ExecuteNonQuery();
            sqlCom.ExecuteReader();
            using (SqlDataReader reader = sqlCom.ExecuteReader())
            {
               while (reader.Read())
                    users.Add(reader.GetInt32(0), reader.GetString(1));
                    ViewData["Message_V"] = reader["tag_name"].ToString();
            }
            ViewData["Message_V"] = sqlCom;
                conn.Close();

             }*/


            // string Identifier = @"http://192.168.245.144:39320/iotgateway/read?ids=simulator.Device1.ABC";
            //JsonModel json = new JsonModel(Identifier);
            //ViewData["Message_Id"] = json.Id;
            //ViewData["Message_V"] = json.V;

            //MachineTag.getAll();

            //string x = JsonModel.getJsonObject("http://192.168.245.144:39320/iotgateway/read");
            new JsonModel().collectJsonValueToDB();
            
            //ViewData["Message"] = x;

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