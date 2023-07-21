using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoenixCalculator
{

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public string sqlServerAddress;
        public MainPage()
        {
            InitializeComponent();
        }

        private void setSQLServerButton_Click(object sender, RoutedEventArgs e)
        {
            sqlServerAddress = @"\\" + sqlServerNameText.Text;
            MessageBox.Show($"The SQL Server has been set to: {sqlServerAddress}");
            
        }

        private void gotoPanelCostCalculatorButton_Click(object sender, RoutedEventArgs e )
        {
            this.NavigationService.Navigate(new Uri("PanelCostCalculator.xaml", UriKind.Relative));
        }
    }
}
