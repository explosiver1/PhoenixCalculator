using Avalonia.Interactivity;
using PhoenixCalculator_Avallon.Models;
using ReactiveUI;
using System.Reactive;

namespace PhoenixCalculator_Avallon.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
       

        //Declarations
        DBModel model;
        public string dbname;
        public string dbpassword;
        public string dbusername;


   
        public SettingsViewModel(DBModel model) {
            this.model = model;
            dbname = "";
            dbpassword = "";
            dbusername = "";
        }
   
        public void UpdateSettings()
        {
            
        }

  

        
    }
}
