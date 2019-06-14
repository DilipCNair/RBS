using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using RBS.Model.ReportsChildModels;
using System.Windows;
using System.ComponentModel;

namespace RBS.Views.ReportsChildViews
{
    /// <summary>
    /// Interaction logic for Process_Port_Map.xaml
    /// </summary>
    public partial class Process_Port_Map : UserControl
    {
        public Process_Port_Map()
        {
            InitializeComponent();
            ButtonRefresh.IsEnabled = false;
            GlobalResources.PPMOver += GlobalResources_PPMOver;
            if (GlobalResources.ProcessPortMapper & GlobalResources.IsMonitoringEngineOn)
                PPM_Label.Visibility = Visibility.Collapsed;
            else
                PPM_Label.Visibility = Visibility.Visible;
        }

        private void GlobalResources_PPMOver(object sender, EventArgs e)
        {
            ButtonRefresh.IsEnabled = true;
        }

        private void TextBox_DisplayFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid_PPM.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBox_DisplayFilter.Text))
                return true;
            else
                return ((item as Process_Port_Map_Model).Name.IndexOf(TextBox_DisplayFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Button_DisplayCount_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = DataGrid_PPM.Items.Count.ToString();
        }

        private void ButtonRefresh_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = DataGrid_PPM.Items.Count.ToString();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (GlobalResources.ProcessPortMapper & GlobalResources.IsMonitoringEngineOn)
                PPM_Label.Visibility = Visibility.Collapsed;
            else
                PPM_Label.Visibility = Visibility.Visible;
        }
    }
}
