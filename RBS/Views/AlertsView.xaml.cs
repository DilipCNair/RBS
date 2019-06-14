using RBS.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for AlertsView.xaml
    /// </summary>
    public partial class AlertsView : UserControl
    {
        public AlertsView()
        {
            InitializeComponent();
        }

        private void NotifyButton_Clicked(object sender, RoutedEventArgs e)
        {
            NotificationWindow NotificationWindow = new NotificationWindow();
            NotificationWindow.Show();
        }

        private void Textbox_SearchAlerts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid_AllAlerts.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Textbox_SearchAlerts.Text))
                return true;
            else
                return ((item as AlertsModel).Information.IndexOf(Textbox_SearchAlerts.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
