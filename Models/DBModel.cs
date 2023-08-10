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
using Avalonia;

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
            if (LoadSettingsFromFile())
            {
                SetConnString();
                TestDBConn();
            }
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
            if (settings.server != "")
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                if (settings.winAuth)
                {
                    sb["Data Source"] = settings.server;
                    sb["integrated security"] = true;
                    sb["Initial Catalog"] = "Calculator";
                    sqlConnString = sb.ConnectionString;

                }
                else
                {
                    sb["Server"] = settings.server;
                    sb["User Id"] = settings.un;
                    sb["Password"] = settings.pw;
                    sqlConnString = sb.ConnectionString;
                }
            } else
            {
                sqlConnString = "";
            }
        }

        public bool TestDBConn()
        {
            if (sqlConnString != "" && sqlConnString != null) { 
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
            }
            return false;
        }

        private bool LoadSettingsFromFile()
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
                return true;
                
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
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

         //This was a test function. Don't use it in any production code.
      /*  public WoodPanel[] LoadPanelCostCalcWoodMaterials()
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
                                woodPanels[i] = new WoodPanel();
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
                    return woodPanels;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new WoodPanel[1];
            }
        } */

        public bool AddPanelCostWoodMaterial(string type, string thickness, string panelWidth, string panelHeight, string price, string date, string lastUpdatedBy) {

            WoodPanel wp = GetWoodPanel(type, thickness, panelHeight, panelWidth);
            if (!wp.type.Equals("Error"))
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(sqlConnString))
                    {
                        using (SqlCommand updateRow = new SqlCommand($"UPDATE PanelCostWoodMaterial SET Price='{price}', Date='{date}', LastUpdatedBy='{lastUpdatedBy}' WHERE Type='{type}' AND Thickness='{thickness}' AND PanelHeight='{panelHeight}' AND PanelWidth='{panelWidth}';", cnn))
                        {
                            cnn.Open();
                            updateRow.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(sqlConnString))
                    {
                        using (SqlCommand insertRow = new SqlCommand($"INSERT INTO PanelCostWoodMaterial VALUES ('{type}', '{thickness}', '{panelWidth}', '{panelHeight}', '{price}', '{date}', '{lastUpdatedBy}');", cnn))
                        {
                            cnn.Open();
                            insertRow.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
        public bool RemovePanelCostWoodMaterial(string type, string thickness, string panelWidth, string panelHeight)
        {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(sqlConnString))
                    {
                        using (SqlCommand removeRow = new SqlCommand($"DELETE FROM PanelCostWoodMaterial WHERE Type='{type}' AND Thickness='{thickness}' AND PanelWidth='{panelWidth}' AND PanelHeight='{panelHeight}';", cnn))
                        {
                            cnn.Open();
                            removeRow.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
        }
        public bool AddPanelCostLaminateMaterial(string type, string panelWidth, string panelHeight, string price, string date, string lastUpdatedBy)
        {
            //Attempts to load a laminate panel matching that name. If it exists, it performs a SQL update statement instead of an insert.
            LaminateSiding ls = GetLaminateSiding(type);
            if (ls.type != "Error")
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(sqlConnString))
                    {
                        using (SqlCommand updateRow = new SqlCommand($"UPDATE PanelCostLaminateMaterial SET Price='{price}', Date='{date}',  Width='{panelWidth}', Height='{panelHeight}', LastUpdatedBy='{lastUpdatedBy}' WHERE Type='{type}';", cnn))
                        {
                            cnn.Open();
                            updateRow.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(sqlConnString))
                    {
                        using (SqlCommand insertRow = new SqlCommand($"INSERT INTO PanelCostLaminateMaterial VALUES ('{type}', '{panelWidth}', '{panelHeight}', '{price}', '{date}', '{lastUpdatedBy}');", cnn))
                        {
                            cnn.Open();
                            insertRow.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
        public bool RemovePanelCostLaminateMaterial(string type)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand removeRow = new SqlCommand($"DELETE FROM PanelCostLaminateMaterial WHERE Type='{type}';", cnn))
                    {
                        cnn.Open();
                        removeRow.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public string FormatDate(int day, int month, int year)
        {
            return day.ToString() +"-"+ month.ToString() + "-" + year.ToString();
        }
        //This is for loading a list of different wood panels for selection in Panel Cost Calculator
        public string[] GetWoodPanelMaterialTypes()
        {
            string[] types = new string[1000];
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand cmd    = new SqlCommand("SELECT DISTINCT Type FROM PanelCostWoodMaterial ORDER BY Type;", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                types[i] = reader.GetString(0);
                                i++;
                            }
                        }
                    }
                }
                return types;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new string[1];
            }
        }

        public string[] GetLaminateSidingTypes()
        {
            string[] types = new string[1000];
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand selectDB = new SqlCommand("SELECT DISTINCT Type FROM PanelCostLaminateMaterial ORDER BY Type;", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = selectDB.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                types[i] = reader.GetString(0);
                                i++;
                            }
                        }
                    }
                }
                return types;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new string[1];
            }
        }

        public WoodPanel GetWoodPanel(string type, string thickness, string height, string width)
        {
            WoodPanel woodPanel = new WoodPanel();
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand selectDB = new SqlCommand($"SELECT * FROM PanelCostWoodMaterial WHERE Type='{type}' AND Thickness='{thickness}' AND PanelHeight='{height}' AND PanelWidth='{width}';", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = selectDB.ExecuteReader())
                        {
                    
                            while (reader.Read())
                            {
                                woodPanel.type = reader.GetString(0);
                                woodPanel.thickness = (float)reader.GetDouble(1);
                                woodPanel.panelWidth = reader.GetInt32(2);
                                woodPanel.panelHeight = reader.GetInt32(3);
                                woodPanel.price = (float)reader.GetDouble(4);
                                woodPanel.date = reader.GetString(5);
                                woodPanel.lastUpdatedBy = reader.GetString(6);

                            }
                        }
                    }
                }
                return woodPanel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new WoodPanel();
            }
        }
        //Thickness and Dimension functions are used for getting lists of what values are left after certain selections are made. 
        //Call Thickness, then call Dimensions. 
        //Setting Dimensions should not call affect thickness to avoid looping. 
        //That's the order the user will go down when making selections, so it should be fine. 
        public string[] GetWoodPanelThicknesses(string type)
        {
            string[] thicknesses = new string[100];
            try
            {
                
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    string sqlCommString = $"SELECT DISTINCT Thickness FROM PanelCostWoodMaterial WHERE Type='{type}';";
                    //if (width != "" && height != "") sqlCommString = $"SELECT * FROM PanelCostWoodMaterial WHERE Type='{type}'AND panelWidth='{width}' AND panelHeight='{height}';";
                    // else sqlCommString = $"SELECT * FROM PanelCostWoodMaterial WHERE Type='{type}';";
                    using (SqlCommand cmd = new SqlCommand(sqlCommString, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            thicknesses[0] = "";
                            int i = 1;
                            while (reader.Read())
                            {
                                thicknesses[i] = reader.GetDouble(0).ToString();
                                i++;
                            }
                        }
                    }
                }
                return thicknesses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new string[1];
            }
        }
        public string[] GetWoodPanelDimensions(string type, string thickness)
        {
            string[] dimensions = new string[10];
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    string sqlCommString;
                    if (thickness != "") sqlCommString = $"SELECT CONCAT(PanelWidth, 'x', PanelHeight) FROM PanelCostWoodMaterial WHERE Type='{type}'AND Thickness='{thickness}';";
                    else return new string[1];
                        //sqlCommString = $"SELECT PanelWidth, PanelHeight FROM PanelCostWoodMaterial WHERE Type='{type}';";
                    using (SqlCommand selectDB = new SqlCommand(sqlCommString, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = selectDB.ExecuteReader())
                        {
                            dimensions[0] = "";
                            int i = 1;
                            while (reader.Read())
                            {
                                dimensions[i] = reader.GetString(0);
                                i++;
                            }
                        }
                    }
                }
                return dimensions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                for (int i = 0; i < dimensions.Length; i++)
                {
                    dimensions[i] = "";
                }
                return new string[1];
            }
        }
        public LaminateSiding GetLaminateSiding(string type)
        {
            LaminateSiding lamSide = new LaminateSiding();
            try
            {
                using (SqlConnection cnn = new SqlConnection(sqlConnString))
                {
                    using (SqlCommand selectDB = new SqlCommand($"SELECT * FROM PanelCostLaminateMaterial WHERE Type='{type}';", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader reader = selectDB.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                lamSide.type = reader.GetString(0);
                                lamSide.sidingWidth = reader.GetInt32(1);
                                lamSide.sidingHeight = reader.GetInt32(2);
                                lamSide.price = (float)reader.GetDouble(3);
                                lamSide.date = reader.GetString(4);
                                lamSide.lastUpdatedBy = reader.GetString(5);

                            }
                        }
                    }
                }
                return lamSide;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new LaminateSiding();
            }
        }
       

    }

    //Data Classes
    //These represent sets of data and a few static functions. 
    public class WoodPanel
    {
        public string type = "Error";
        public float thickness = 9999f;
        public int panelWidth = 9999;
        public int panelHeight = 9999;
        public float price = 9999f;
        public string date = "1/1/1900";
        public string lastUpdatedBy = "System";

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
        public string type = "Error";
        public int sidingWidth = 9999;
        public int sidingHeight = 9999;
        public float price = 9999f;
        public string date = "1/1/1900";
        public string lastUpdatedBy = "System";
    }

    public class Settings
    {
        public string server = "";
        public bool winAuth = true;
        public string un = "";
        public string pw = "";
    }

}
