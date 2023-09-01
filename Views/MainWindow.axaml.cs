using Avalonia.Controls;
using PhoenixCalculator_Avallon.ViewModels;

namespace PhoenixCalculator_Avallon.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.DataContext = new MainWindowViewModel();
        InitializeComponent();

    }

}