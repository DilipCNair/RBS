using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using RBS.Model.ReportsChildModels;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for ProcessReports.xaml
    /// </summary>
    public partial class ProcessReports : UserControl
    {
        public ProcessReports()
        {
            InitializeComponent();
            if (GlobalResources.ProcessMonitoring & GlobalResources.IsMonitoringEngineOn)
                PM_Label.Visibility = Visibility.Collapsed;
            else
                PM_Label.Visibility = Visibility.Visible;
            GlobalResources.NewProcessDetected += GlobalResources_NewProcessDetected;
        }

        private void GlobalResources_NewProcessDetected(object sender, EventArgs e)
        {
            //CollectionViewSource.GetDefaultView(DataGrid_Processes.ItemsSource).Refresh();
        }

        private void TextBox_DisplayFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid_Processes.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBox_DisplayFilter.Text))
                return true;
            else
                return ((item as ProcessReportsModel).Name.IndexOf(TextBox_DisplayFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void TextBox_DisplayFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DataGrid_Processes.ItemsSource).Refresh();
        }

        private void Button_DisplayCount_Clicked(object sender, RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = DataGrid_Processes.Items.Count.ToString();
        }

        private void UserControl_ProcessReports_Loaded(object sender, RoutedEventArgs e)
        {
            if (GlobalResources.ProcessMonitoring & GlobalResources.IsMonitoringEngineOn)
                PM_Label.Visibility = Visibility.Collapsed;
            else
                PM_Label.Visibility = Visibility.Visible;
        }
    }
}
