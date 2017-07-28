using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            string controllerId = Request.QueryString["controller-id"];
            string controllerName = Request.QueryString["controller-name"];

            SqlConnection conn = ConnectionBuilder.getConnection();
            string sql = "SELECT * FROM ControllerMatchingTag WHERE controller_set_id = @param1";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            sqlCom.Parameters.AddWithValue("@param1", Int32.Parse(controllerId));
            conn.Open();

            Dictionary<string, string> map = new Dictionary<string, string>();
            using (SqlDataReader reader = sqlCom.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Debug.WriteLine(reader["controller_var_id"].ToString() + " ... " + reader["tag_name"].ToString());
                    map.Add(reader["controller_var_id"].ToString(), reader["tag_name"].ToString());
                    
                }
            }
            //controller_var_id
            //    if 1 = PV
            //       2 = CO
            //       3 = SP
            conn.Close();

            ViewData["ControllerName"] = controllerName;
            Debug.WriteLine("controllerName" + controllerName);
            ViewData["ChartVariableArrayInList"] = map; // [ {1, Strah.x.y} , {2, Strag,x,y}, ... ]

            return View();
        }
    }
}