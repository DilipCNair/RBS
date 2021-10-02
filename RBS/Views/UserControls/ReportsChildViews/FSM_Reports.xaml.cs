using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using RBS.Model.ReportsChildModels;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for FSMReportsDataGrid.xaml
    /// </summary>
    public partial class FSM_Reports : UserControl
    {
        public FSM_Reports()
        {
            InitializeComponent();
            if (AppResources.FileSystemMonitoring & AppResources.IsMonitoringEngineOn)
                FSM_Label.Visibility = Visibility.Collapsed;
            else
                FSM_Label.Visibility = Visibility.Visible;
        }

        private void Button_DisplayCount_Clicked(object sender, RoutedEventArgs e)
        {
            TextBox_DisplayCount.Text = DataGrid_FSC.Items.Count.ToString();
        }

        private void TextBox_DisplayFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid_FSC.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private void TextBox_DisplayFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DataGrid_FSC.ItemsSource).Refresh();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBox_DisplayFilter.Text))
                return true;
            else
                return ((item as FileSystemReportsModel).FullPath.IndexOf(TextBox_DisplayFilter.Text, 
                    StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void UserControl_FSM_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppResources.FileSystemMonitoring & AppResources.IsMonitoringEngineOn)
                FSM_Label.Visibility = Visibility.Collapsed;
            else
                FSM_Label.Visibility = Visibility.Visible;
        }
    }
}
