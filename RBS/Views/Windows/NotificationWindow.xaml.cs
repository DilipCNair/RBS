using System.Media;
using System.Windows;
using MahApps.Metro.Controls;
using System;

namespace RBS
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : MetroWindow
    {
        public NotificationWindow()
        {
            InitializeComponent();
            Hide();
            Closing += NotificationWindow_Closing; // For Canceling the Closing Event
            Activated += NotificationWindow_Activated; // To play sound when activated
            Deactivated += NotificationWindow_Deactivated; //To assure window always opens in foreground

            AppResources.ShowNotiffication += AppResources_ShowNotiffication; //To activate notification window
            AppResources.AlertSound += AppResources_AlertSound; //To play alert sound
            AppResources.UpdateAlert += AppResources_UpdateAlert; //To update Alert

        }

        private void NotificationWindow_Deactivated(object sender, EventArgs e)
        {
            Activate();
        }

        private void AppResources_UpdateAlert(object sender, System.EventArgs e)
        {
            ShowLatestAlert();
        }

        private void AppResources_AlertSound(object sender, System.EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void WindowNotification_Loaded(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void NotificationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            AppResources.IsNotificationWindowShown = false;
            e.Cancel = true;
        }

        private void NotificationWindow_Activated(object sender, System.EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void AppResources_ShowNotiffication(object sender, System.EventArgs e)
        {
            Show();
            AppResources.IsNotificationWindowShown = true;
        }

        private void ShowLatestAlert()
        {
            SystemSounds.Hand.Play();
            Application.Current.Dispatcher.Invoke(delegate
            {
                //TextBlock_AlertNo.Text = AppResources.LastAlert.No.ToString();
                Information_Textblock.Text = AppResources.LastAlert.Information;
                Activity_Textblock.Text = AppResources.LastAlert.Activity;
                Date_Textblock.Text = AppResources.LastAlert.Date;
                Time_Textblock.Text = AppResources.LastAlert.Time;
                //TextBlock_AlertNo.Text = AppResources.LastAlert.No.ToString();
            });
        }

    }
}
