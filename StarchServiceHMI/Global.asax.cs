using Microsoft.ApplicationInsights.Extensibility;
using Newtonsoft.Json.Linq;
using StarchServiceHMI.Controllers;
using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StarchServiceHMI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            TelemetryConfiguration.Active.DisableTelemetry = true;

            //browserTag2DB();
            Debug.Write("HELLO EIEI");

            Thread thread = new Thread(CronThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void CronThread()
        {
            ResourceManager rm = new ResourceManager("StarchServiceHMI.Resource", Assembly.GetExecutingAssembly());
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(Convert.ToInt32(rm.GetString("Interval"))));
                JObject jsonResponse = DistributerController.getAllMachineTagValue("http://" + rm.GetString("IP") + "/iotgateway/read");
                DistributerController.setJsonResponse(jsonResponse);
                //DistributerController.getValueFromJson();
            }
        }

        private void browserTag2DB()
        {
            bool isSuccess = true;
            while (isSuccess)
            {
                try
                {
                    JObject allTagJson = DistributerController.browserTag();
                    isSuccess = false;
                    Debug.WriteLine(allTagJson);
                    SqlConnection conn = ConnectionBuilder.getConnection();
                    string sql = "TRUNCATE TABLE Tag";
                    SqlCommand sqlCom = new SqlCommand(sql, conn);
                    conn.Open();
                    sqlCom.ExecuteNonQuery();
                
                    sql = "INSERT INTO Tag (tag_name) VALUES (@param1)";
                    sqlCom = new SqlCommand(sql, conn);
                    
                    foreach (var tag in allTagJson["browseResults"])
                    {
                        string tagName = tag["id"].ToString();
                        
                        sqlCom.Parameters.Clear();
                        sqlCom.Parameters.AddWithValue("@param1", tagName);
                        sqlCom.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Browser Tag API is not Success, " + ex);
                    Debug.WriteLine("System is try to calling API again.");
                }
            }
        }
    }
}
