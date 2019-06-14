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
using RBS;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for UIM_Reports.xaml
    /// </summary>
    public partial class UIM_Reports : UserControl
    {
        public UIM_Reports()
        {
            InitializeComponent();
            if (GlobalResources.UserInputMonitoringChecked & GlobalResources.IsMonitoringEngineOn)
                UIM_Label.Visibility = Visibility.Collapsed;
            else
                UIM_Label.Visibility = Visibility.Visible;
        }

        private void UserControl_UIMReports_Loaded(object sender, RoutedEventArgs e)
        {
            if (GlobalResources.UserInputMonitoringChecked & GlobalResources.IsMonitoringEngineOn)
                UIM_Label.Visibility = Visibility.Collapsed;
            else
                UIM_Label.Visibility = Visibility.Visible;
        }
    }
}
