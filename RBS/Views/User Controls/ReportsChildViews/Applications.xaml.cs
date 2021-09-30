using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using RBS.Model.ReportsChildModels;

namespace RBS.Views.ReportsChildViews
{
    /// <summary>
    /// Interaction logic for Applications.xaml
    /// </summary>
    public partial class Applications : UserControl
    {
        public Applications()
        {
            InitializeComponent();
            ButtonRefresh.IsEnabled = false;
            if (GlobalResources.ApplicationsMonitoring & GlobalResources.IsMonitoringEngineOn)
                AM_Label.Visibility = Visibility.Collapsed;
            else
                AM_Label.Visibility = Visibility.Visible;
            GlobalResources.AllApplicationsFetched += GlobalResources_AllApplicationsFetched;
        }

        private void GlobalResources_AllApplicationsFetched(object sender, EventArgs e)
        {
            ButtonRefresh.IsEnabled = true;
        }

        private void Button_DisplayCount_Clicked(object sender, RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = Datagrid_Applications.Items.Count.ToString();
        }

        private void TextBox_DisplayFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Datagrid_Applications.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBox_DisplayFilter.Text))
                return true;
            else
                return ((item as ApplicationsModel).Publisher.IndexOf(TextBox_DisplayFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (GlobalResources.ApplicationsMonitoring & GlobalResources.IsMonitoringEngineOn)
                AM_Label.Visibility = Visibility.Collapsed;
            else
                AM_Label.Visibility = Visibility.Visible;
        }
    }
}
