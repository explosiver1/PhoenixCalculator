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
        private DBModel _model;
        private string _dbname = "";
        public string DBName
        {
            get => _dbname;
            set => this.RaiseAndSetIfChanged(ref _dbname, value);
        }
        private string _dbpassword = "";
        public string DBPassword
        {
            get => _dbpassword;
            set => this.RaiseAndSetIfChanged(ref _dbpassword, value);
        }
        private string _dbusername = "";
        public string DBUsername
        {
            get => _dbusername;
            set => this.RaiseAndSetIfChanged(ref _dbusername, value);
        }
        private bool _useWindowsAuth = true;

        public bool UseWindowsAuth
        {
            get => _useWindowsAuth;
            set => this.RaiseAndSetIfChanged(ref  _useWindowsAuth, value);
        }

        private string connStatus = "";
        public string ConnectionStatus
        {
            get => connStatus;
            set => this.RaiseAndSetIfChanged(ref connStatus, value);
        }


        public SettingsViewModel() {

            _model = DBModel.GetInstance();
            UpdateSettings();
        }
   
        public void UpdateSettings()
        {
        _model.BuildConnString(DBName, UseWindowsAuth, DBUsername, DBPassword);
            if (_model.TestDBConn())
            {
                ConnectionStatus = "Up";
            } else
            {
                ConnectionStatus = "Down";
            }

            
        }
}

