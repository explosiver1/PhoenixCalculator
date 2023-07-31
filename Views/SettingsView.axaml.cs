using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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