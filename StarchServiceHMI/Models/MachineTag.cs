using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StarchServiceHMI.Models
{
    public class MachineTag
    {
        private int id;
        private string tagName;
        string urlAPI = "http://192.168.245.132:39320/iotgateway/read?ids=simulator.Device1.ABC";

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;
            }
        }

        public static List<MachineTag> getAll()
        {
            List<MachineTag> listMachineTag = new List<MachineTag>();
            SqlConnection conn = ConnectionBuilder.getConnection();
            conn.Open();
            string sql = "SELECT tag_name FROM Tag";
            SqlCommand sqlCom = new SqlCommand(sql, conn);
            //sqlCom.ExecuteReader();
            using (SqlDataReader reader = sqlCom.ExecuteReader())
            {
                while (reader.Read())
                {
                    MachineTag mt = new MachineTag();
                    //mt.Id = int.Parse(reader["id"].ToString());
                    mt.TagName = reader["tag_name"].ToString();
                    listMachineTag.Add(mt);
                }
                //users.Add(reader.GetInt32(0), reader.GetString(1));
                //ViewData["Message_V"] = reader["tag_name"].ToString();
                //System.Diagnostics.Debug.WriteLine(reader["tag_name"].ToString());
            }
            
            conn.Close();

            return listMachineTag;
        } 
    }
}