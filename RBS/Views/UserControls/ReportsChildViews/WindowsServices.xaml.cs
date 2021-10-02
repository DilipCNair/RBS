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

namespace RBS.Views.ReportsChildViews
{
    /// <summary>
    /// Interaction logic for WindowsServices.xaml
    /// </summary>
    public partial class WindowsServices : UserControl
    {
        public WindowsServices()
        {
            InitializeComponent();
            ButtonRefresh.IsEnabled = false;
            AppResources.WinServOver += AppResources_WinServOver;
        }

        private void AppResources_WinServOver(object sender, EventArgs e)
        {
            ButtonRefresh.IsEnabled = true;
        }

        private void Button_DisplayCount_Clicked(object sender, RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = DataGrid_WS.Items.Count.ToString();
        }
    }
}
