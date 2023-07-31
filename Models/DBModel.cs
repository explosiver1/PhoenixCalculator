using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace PhoenixCalculator_Avallon.Models
{
    public class DBModel 
    {
        private string sqlConnString;

        private static DBModel _instance;
     

      


        //Constructor
        public DBModel()
        {
            sqlConnString = "";
            TestDBConn();
        }

        public static DBModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBModel();
            }
            return _instance;
        }

        public void BuildConnString(string server, bool winAuth, string un, string pw)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            if (winAuth)
            {
                sb["Data Source"] = server;
                sb["integrated security"] = true;
                sqlConnString = sb.ConnectionString;
                
            } else
            {
                sb["Server"] = server;
                sb["User Id"] = un;
                sb["Password"] = pw;
                sqlConnString = sb.ConnectionString;
            }
            
        }

        public bool TestDBConn()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    cnn.Open();
                    Console.WriteLine("SQL Connection Works");
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("We dun goofed");
            }
            return false;
        }
    }
}
