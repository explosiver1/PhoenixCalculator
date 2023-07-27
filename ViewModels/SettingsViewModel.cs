using Avalonia.Interactivity;
using ReactiveUI;
using System.Reactive;

namespace PhoenixCalculator_Avallon.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        //Declarations
        public string dbname = "";
        public string dbpassword = "";
        public string dbusername = "";
       // public ReactiveCommand<Unit, Unit> UpdateSettingsClicked { get; }

        //Constructor
       // public SettingsViewModel()
        //{
            //UpdateSettingsClicked = ReactiveCommand.Create(UpdateSettings);
        //}
        //}

        //Command Functions
        public void UpdateSettings()
        {
            ConnectDB();
            PopulateFromDB();
        }

        //Public Accessor Functions
    

        //Private Functions
        private void ConnectDB()
        {

        }

        private void PopulateFromDB()
        {

        }
    }
}
