using Avalonia.Interactivity;
using PhoenixCalculator_Avallon.Models;
using System;
using System.Reactive;
using System.Linq;
using ReactiveUI;


namespace PhoenixCalculator_Avallon.ViewModels;
public class SettingsViewModel : ReactiveObject
{


        //Declarations
        private DBModel model;
        private string _dbname = "";
        public string dbname
        {
            get => _dbname;
            set => this.RaiseAndSetIfChanged(ref _dbname, value);
        }
        private string _dbpassword = "";
        public string dbpassword
        {
            get => _dbpassword;
            set => this.RaiseAndSetIfChanged(ref _dbpassword, value);
        }
        private string _dbusername = "";
        public string dbusername
        {
            get => _dbusername;
            set => this.RaiseAndSetIfChanged(ref _dbusername, value);
        }
        private bool _useWindowsAuth = true;
        public bool useWindowsAuth
        {
            get => _useWindowsAuth;
            set => this.RaiseAndSetIfChanged(ref  _useWindowsAuth, value);
        }
        private string _connStatus = "Down";
        public string connectionStatus
        {
            get => _connStatus;
            set => this.RaiseAndSetIfChanged(ref _connStatus, value);
        }


        public SettingsViewModel() {

            model = DBModel.GetInstance();
            dbname = model.settings.server;
            dbpassword = model.settings.pw;
            dbusername = model.settings.un;
            useWindowsAuth = model.settings.winAuth;
            if (model.TestDBConn())
            {
                connectionStatus = "Up";
            }
            else
            {
                connectionStatus = "Down";
            }


        }
   
        public void UpdateSettings()
        {
            //Settings are encapsulated in an object for JSON serialization. 
            model.settings.server = dbname;
            model.settings.pw = dbpassword;
            model.settings.un = dbusername;
            model.settings.winAuth = useWindowsAuth;
            model.SetConnString();
            model.SaveSettingsToFile();
            if (model.TestDBConn())
            {
                connectionStatus = "Up";
            } else
            {
                connectionStatus = "Down";
            }
            
        }
  
}

