using Avalonia.Interactivity;
using PhoenixCalculator_Avallon.Models;
using System.Diagnostics;

namespace PhoenixCalculator_Avallon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public DBModel model;
    public PanelCostViewModel panelCostViewModel;
    public SettingsViewModel settingsViewModel;

    // Code to add a view model from the MainWindowViewModel. 
    //This is necessary so that the view models are available as bindings for controls in our Main Window.
    // Note: We need at least a get-accessor for our Properties.
    public MainWindowViewModel() 
    {
        model = new DBModel();
        panelCostViewModel = new PanelCostViewModel(model);
        settingsViewModel = new SettingsViewModel(model);
    }    
}
