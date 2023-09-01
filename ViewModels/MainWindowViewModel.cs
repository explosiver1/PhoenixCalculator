using ReactiveUI;

namespace PhoenixCalculator_Avallon.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public string Greeting => "Welcome to Avalonia!";



    // Code to add a view model from the MainWindowViewModel. 
    //This is necessary so that the view models are available as bindings for controls in our Main Window.
    // Note: We need at least a get-accessor for our Properties.
    public MainWindowViewModel()
    {

    }

}

