using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using lib_of_jared;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace PhoenixCalculator_Avallon.Models
{
    //This is the main model that connects to SQL and interfaces with the view models. 
    public class DBModel 
    {
        /*
         Note about SQL in C#:
            Use SqlConnectionStringBuilder for constructing a safe connection string from user input. 
            \\ is unnecessary for heading servers. use servername\sqlserverinstance or servername,port
                The comma is intentional. Idk why they chose that syntax, but it's the right one. 
            SQL commands are executed two ways:
                ExecuteNonQuery for commands that don't return a value. 
                ExecuteReader for commands that return a value.
                ExecuteScalar for commands that return specifically one value.
                There are also async versions of each command.
         SQL Data Types are not always a 1to1 conversion to C#. 
            Most are fine, but floats are wacky. 
            float in C# maps to real in SQL.
            double in C# maps to float in SQL. 
         */
        private string sqlConnString ="";
        public Settings settings;
        //Singleton for the DBModel. 
        //I can leave most things public and non-static by just making the constructor private and leaving a static method to get the instance.
        private static DBModel _instance;
     

        //Constructor
        private DBModel()
        {
            settings = new Settings();
            LoadSettingsFromFile();
            SetConnString();
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


        public void SetConnString()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            if (settings.winAuth)
            {
                sb["Data Source"] = settings.server;
                sb["integrated security"] = true;
                sb["Initial Catalog"] = "Calculator";
                sqlConnString = sb.ConnectionString;
                
            } else
            {
                sb["Server"] = settings.server;
                sb["User Id"] = settings.un;
                sb["Password"] = settings.pw;
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

        private void LoadSettingsFromFile()
        {
            try
            {
                string path = "%AppData%";
                path = Environment.ExpandEnvironmentVariables(path);
                string fileName = path + @"\PHXCalcSettings.json";
                string jsonString = File.ReadAllText(fileName);
                string[] data = jsonString.Split(' ');
                settings.server = data[0];
                settings.un = data[1];
                settings.pw = data[2];
                settings.winAuth = Convert.ToBoolean(data[3]);
                
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool SaveSettingsToFile()
        {
            //Fill in the JSON serialization code
            //Currently custom string concatenation because JSON serializer sucks ass and writes a blank string.
            if (settings != null)
            {
                string path = @"%AppData%";
                path =  Environment.ExpandEnvironmentVariables(path);
                path = path + @"\PHXCalcSettings.json";
                string data = settings.server + " " + settings.un + " " + settings.pw + " " + settings.winAuth.ToString();
                File.WriteAllText(path, data);
                return true;
            } else
            {
                return false;
            }
        }

         
        public void LoadPanelCostCalcWoodMaterials(WoodPanel[] woodPanels)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand selectDB = new SqlCommand("SELECT * FROM PanelCostWoodMaterial;", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = selectDB.ExecuteReader())
                        {

                            int i = 0;
                             while (reader.Read())
                             {
                             woodPanels[i].type = reader.GetString(1);
                             woodPanels[i].thickness = (float) reader.GetDouble(2);
                             woodPanels[i].panelWidth = reader.GetInt32(3);
                             woodPanels[i].panelHeight = reader.GetInt32(4);
                             woodPanels[i].price = (float) reader.GetDouble(5);
                             woodPanels[i].date = reader.GetString(6);
                             woodPanels[i].lastUpdatedBy = reader.GetString(7);
                             i++;
                             //if (i == woodPanels.Length) woodPanels = WoodPanel.ExpandArray(woodPanels);
                             }
                        }
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void AddPanelCostWoodMaterial(WoodPanel woodPanel)
        {

        }

        public string FormatDate(int day, int month, int year)
        {
            return day.ToString() +"-"+ month.ToString() + "-" + year.ToString();
        }
    }

    //Data Classes
    //These represent sets of data and a few static functions. 
    public class WoodPanel
    {
        public string type = "";
        public float thickness = 0f;
        public int panelWidth = 0;
        public int panelHeight = 0;
        public float price = 0f;
        public string date = "";
        public string lastUpdatedBy = "";

        public static WoodPanel[] ExpandArray(WoodPanel[] arr)
        {
            //Performs dynamic array expansion
            int newBound = arr.Length * 2;
            WoodPanel[] newArr = new WoodPanel[newBound];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }
    }

    public class LaminateSiding
    {
        public string type = "";
        public int sidingWidth = 0;
        public int sidingHeight = 0;
        public float cost = 0f;
        public string date = "";
        public string lastUpdatedBy = "";
    }

    public class SpecialtyFinish
    {
        public string type = "";
        public float sqftPrice = 0f;
        public string date = "";
        public string lastUpdatedBy = "";
    }

    public class Settings
    {
        public string server = "";
        public bool winAuth = true;
        public string un = "";
        public string pw = "";
    }

}
