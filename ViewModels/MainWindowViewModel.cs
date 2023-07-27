using Avalonia.Interactivity;
using System.Diagnostics;

namespace PhoenixCalculator_Avallon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    // Code to add a view model from the MainWindowViewModel. 
    //This is necessary so that the view models are available as bindings for controls in our Main Window.
    // Note: We need at least a get-accessor for our Properties.
    public PanelCostViewModel PanelCostViewModel { get; } = new PanelCostViewModel();
    public SettingsViewModel SettingsViewModel { get; }= new SettingsViewModel();

    
}
