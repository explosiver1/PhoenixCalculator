using Avalonia.Controls;
using PhoenixCalculator_Avallon.ViewModels;

namespace PhoenixCalculator_Avallon.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        this.DataContext = new SettingsViewModel();
        InitializeComponent();
    }
}