using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for PanelCostCalculator.xaml
    /// </summary>
    public partial class PanelCostCalculator : Page
    {
        public PanelCostCalculator()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int cost;
            cost = Int32.Parse(PanelQuantityTextBox.Text) * 100;
            PanelCostTotalTextBox.Text = cost.ToString();

        }
    }
}
