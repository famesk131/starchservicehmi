using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;
using System.Data.SqlClient;

namespace StarchServiceHMI.Models
{
    public class JsonModel
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
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

        public JsonModel() { }

        //Do this method first
        public JsonModel(String url)
        {
            JObject jsonObject = getAllMachineTagValue(url);
            //use method of JsonObject below then get each jsonObject (id,s,r,v) and kept data in readResult
            id = (String)jsonObject["readResults"][0]["id"];
            s = (Boolean)jsonObject["readResults"][0]["s"];
            v = (String)jsonObject["readResults"][0]["v"];
            r = (String)jsonObject["readResults"][0]["r"];
            //t = (String) jsonObject["readResults"][0]["t"] + "";
        }

        public static JObject getAllMachineTagValue(String url)
        {
            List<MachineTag> listMachineTag = MachineTag.getAll();
            //To get JsonObject need to call json string from URL first and then Parse it into object type
            WebClient webClient = new WebClient();
            DupeNVC dnvc = new DupeNVC("ids");
            foreach (MachineTag matchineTag in listMachineTag)
            {
                dnvc.Add("ids", matchineTag.TagName);
                //Debug.WriteLine(matchineTag.TagName);
                //webClient.QueryString.Add("ids", matchineTag.TagName);
            }
            webClient.QueryString = dnvc;
            //Debug.WriteLine("Hello");
            
            string respones = webClient.DownloadString(url); // get json string from URL

            JObject jsonObject = JObject.Parse(respones); //Parse json string to jsonObject
            // JValue id = (JValue)jsonObject["readResults"][0]["id"];
            return jsonObject; // return json object for use in other method
        }

        public void collectJsonValueToDB()
        {
            JObject jsonResponse = getAllMachineTagValue("http://192.168.245.130:39320/iotgateway/read");
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

        public override string ToString()
        {
            return "JSON: id=" + id + ", s=" + s + ", v=" + v + ", r=" + r;
        }

        

    }
}