using Avalonia.Controls;
using PhoenixCalculator_Avallon.ViewModels;

namespace PhoenixCalculator_Avallon.Views;

public partial class DatabaseView : UserControl
{
    public DatabaseView()
    {
        this.DataContext = new DatabaseViewModel();
        InitializeComponent();
    }
}