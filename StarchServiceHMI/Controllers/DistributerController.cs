using Newtonsoft.Json.Linq;
using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class DistributerController : Controller
    {
        // GET: Distributer
        public ActionResult Index()
        {
            return View();
        }

        public void main()
        {
            JObject jsonResponse= JsonModel.getAllMachineTagValue("http://192.168.245.147:39320/iotgateway/read");
            SqlConnection conn = ConnectionBuilder.getConnection();
            string sql = "INSERT INTO Value (tag_name_fk, v) VALUES (@param1, @param2)";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            conn.Open();
            foreach (var jsonArray in jsonResponse["readResults"])
            {
                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@param1", (String)jsonArray["id"]);
                sqlCom.Parameters.AddWithValue("@param2", double.Parse((String)jsonArray["v"]));

                sqlCom.ExecuteNonQuery();

            }
            conn.Close();

        }
    }
}