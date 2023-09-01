using Avalonia.Controls;
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