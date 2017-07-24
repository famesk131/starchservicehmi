using Newtonsoft.Json.Linq;
using StarchServiceHMI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace StarchServiceHMI.Controllers
{
    public class DistributerController : Controller
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        internal static void getAllMachineTagValue()
        {
            throw new NotImplementedException();
        }

        private Boolean s;

        public Boolean S
        {
            get { return s; }
            set { s = value; }
        }
        private String v;

        public String V
        {
            get { return v; }
            set { v = value; }
        }
        private String r;

        public String R
        {
            get { return r; }
            set { r = value; }
        }

        static JObject jsonResponse;
        // GET: Distributer
        public ActionResult Index()
        {
            //ส่วนที่เชื่อมกับ JS โดยลิ้งด้วย tag
            string tag = this.Request.QueryString["tag"];
            string x = DistributerController.getValueFromJson(tag);

            Response.ContentType = "text/event-stream";
            Response.CacheControl = "no-cache";
            Response.Expires = -1;
            Response.Flush();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            return Content("data: "+x+ "\n\n");
        }
        /*
        internal static void getAllMachineTagValue()
        {
            throw new NotImplementedException();
        }
        */
        public static string getTagValue(string tagName)
        {
            string value = DistributerController.getValueFromJson(tagName);
            return value;
        }

        public static void setJsonResponse(JObject json)
        {
            jsonResponse = json;
        }

        public static JObject getJsonResponse()
        {
            return jsonResponse;
        }


       
        //1.อ้างอิง IP address เป้าหมายเพื่อ request tag ที่ดึงมาทั้งหมดจาก method getAlltagValue-------------ไปยัง getValuefromJson
        public static void collectJsonValueToDB(string tagname, double value)
        {
            //รีเควสแต่ละ URL tagname ไปยัง IP เป้าหมายโดยใช้คู่กับ method getValuefromJson โดย เก็บใน JObject
            ResourceManager rm = new ResourceManager("StarchServiceHMI.Resource", Assembly.GetExecutingAssembly());
            JObject jsonResponse = getAllMachineTagValue("http://" + rm.GetString("IP") + "/iotgateway/read");
            //รวมทั้งเก็บค่าแต่ละค่าที่อ่านได้ไปยัง DB DataCollect
            SqlConnection conn = ConnectionBuilder.getConnection();
            string sql = "INSERT INTO DataCollect (tagname, value) VALUES (@param1, @param2)";
            
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            conn.Open();

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@param1", tagname);
            sqlCom.Parameters.AddWithValue("@param2", value);
            sqlCom.ExecuteNonQuery();
            conn.Close();
            /*
            foreach (var jsonArray in jsonResponse["readResults"])
            {
                
                sqlCom.Parameters.AddWithValue("@param1", (String)jsonArray["id"]);
                sqlCom.Parameters.AddWithValue("@param2", double.Parse((String)jsonArray["v"]));
                
                sqlCom.Parameters.Clear();
                sqlCom.Parameters.AddWithValue("@param1", tagname);
                sqlCom.Parameters.AddWithValue("@param2", value);
                sqlCom.ExecuteNonQuery();
                
            }
            
            conn.Close();
            */
        }

        public static void getValueFromJson()
        {
            JObject jsonResponse = DistributerController.getJsonResponse();
            //Debug.WriteLine(jsonResponse);
            string x = jsonResponse["readResults"].ToString();
            //Debug.WriteLine("JSON = "+x);
            foreach (var jsonArray in jsonResponse["readResults"])
            {
                x = jsonArray["v"].ToString();
                try
                {
                    collectJsonValueToDB(jsonArray["id"].ToString(), Double.Parse(x));
                }
                catch (System.FormatException ex)
                {
                }
            }
        }

        //3.แสกนค่าตัวแปร "V" ที่ได้จาก tagname เพื่อดึงค่ามาเก็บลง variable x  ----------------เสร็จกระบวนการของ Distributer
        public static String getValueFromJson(String tag_name)
        {
            
            JObject jsonResponse = DistributerController.getJsonResponse();
            
            string x = jsonResponse["readResults"].ToString();
            //แสกนค่าแต่ละตัวที่เป็นตัวแปร v
            foreach (var jsonArray in jsonResponse["readResults"])
            {
                //เช็ค JSON ค่า "id" ว่าตรงกับ tagname มั้ยถ้าใช่สั่งสแกนค่า v
                if (jsonArray["id"].ToString() == tag_name)
                {
                    x = jsonArray["v"].ToString();
                    //Debug.WriteLine(jsonArray["id"].ToString() + ">>>>>>" + x);
                    try
                    {
                        collectJsonValueToDB(jsonArray["id"].ToString(), Double.Parse(x));
                    }
                    catch (System.FormatException )
                    {
                        
                    }
                    
                }
            }
            //ได้ค่า Jresult ที่แสกนจาก readresult แล้ว JObject ก็จะเป็นค่าที่ต้องการ
            return x;
        }

        

        //2.ดึงชื่อ tag ทุกชื่อจาก DB ----- ไปที่ method CollectJsonToDB 
        public static JObject getAllMachineTagValue(String url)
        {
            List<MachineTag> listMachineTag = MachineTag.getAll();
            WebClient webClient = new WebClient();
            DupeNVC dnvc = new DupeNVC("ids");
            foreach (MachineTag matchineTag in listMachineTag)
            {
                dnvc.Add("ids", matchineTag.TagName);
            }
            webClient.QueryString = dnvc;

            string respones = webClient.DownloadString(url); // get json string from URL

            JObject jsonObject = JObject.Parse(respones); //Parse json string to jsonObject
            return jsonObject; // return json object for use in other method
        }


        public override string ToString()
        {
            return "JSON: id=" + id + ", s=" + s + ", v=" + v + ", r=" + r;
        }

        static ResourceManager rm = new ResourceManager("StarchServiceHMI.Resource", Assembly.GetExecutingAssembly());

        public static JObject browserTag()
        {
            WebClient webClient = new WebClient();
            string browserAllTag = webClient.DownloadString("http://" + rm.GetString("IP") + "/iotgateway/browse");
            JObject allTagJson = JObject.Parse(browserAllTag);
            return allTagJson;
        }

    }
}