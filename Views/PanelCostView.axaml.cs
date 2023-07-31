using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PhoenixCalculator_Avallon.ViewModels;

namespace PhoenixCalculator_Avallon.Views;

public partial class PanelCostView : UserControl
{
    public PanelCostView()
    {
        this.DataContext = new PanelCostViewModel();
        InitializeComponent();
    }
}