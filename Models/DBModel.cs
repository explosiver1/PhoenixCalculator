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
        string serverName;
        string dbname = "";
        string un = "";
        string pw = "";
        bool isWindowsAuth;
        bool useLocalFile;
        string connectionString;
        SqlConnection cnn;

        public void ConnectToDB(string connectionString, string queryString)
        {
            using (cnn = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, cnn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //Constructor
        public DBModel()
        {
            //Load values from a configuration file. 
            //I'll write this part later once I get other pieces working. 
            serverName = @".\SQLExpress";
            dbname = "";
            un = "";
            pw = "";
            isWindowsAuth = true;
            useLocalFile = false;
            cnn = new SqlConnection();
            if (serverName != "")
            {
                if (isWindowsAuth) { connectionString = "Server=" + serverName + ";" + "Database=master;Trusted_Connection=True;"; }
                else { connectionString = "Server=" + serverName + ";" + "Database=master;User Id=" + un + ";Password=" + pw + ";"; }

                try
                {
                    cnn.Open();
                    Console.WriteLine("SQL Connection Works");
                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("We dun goofed");
                }
            }
            else
            {
                connectionString = "";
            }
        }

        /*
        public void SetupDB(string db)
        {
            if (cnn != null)
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "USE master;\r\ngo\r\nIF (db_id('[DBNAME]') is null)\r\n\tCREATE DATABASE [DBNAME];\r\ngo\r\nUSE [DBNAME];";
                cnn.Open();
                cnn.Close();
            }
        } */

        public void UpdateModel()
        {

        }

        public string GetPanelData()
        {
            return "";
        }

        //Destructor
       /* ~DBModel() 
        { 
            if (cnn != null)
            {
                cnn.Close();
            }
        }*/

    }
}
