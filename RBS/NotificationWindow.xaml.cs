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

            this.Closing += NotificationWindow_Closing; // For Canceling the Closing Event
            this.Activated += NotificationWindow_Activated; // To play sound when activated
            this.Deactivated += NotificationWindow_Deactivated; //To assure window always opens in foreground

            GlobalResources.ShowNotiffication += GlobalResources_ShowNotiffication; //To activate notification window
            GlobalResources.AlertSound += GlobalResources_AlertSound; //To play alert sound
            GlobalResources.UpdateAlert += GlobalResources_UpdateAlert; //To update Alert
            
        }

        private void NotificationWindow_Deactivated(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void GlobalResources_UpdateAlert(object sender, System.EventArgs e)
        {
            ShowLatestAlert();
        }

        private void GlobalResources_AlertSound(object sender, System.EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void WindowNotification_Loaded(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void NotificationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            GlobalResources.IsNotificationWindowShown = false;
            e.Cancel = true;
        }

        private void NotificationWindow_Activated(object sender, System.EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void GlobalResources_ShowNotiffication(object sender, System.EventArgs e)
        {
            this.ShowDialog();
            GlobalResources.IsNotificationWindowShown = true;
        }

        private void ShowLatestAlert()
        {
            SystemSounds.Hand.Play();
            Application.Current.Dispatcher.Invoke(delegate
            {
                TextBlock_AlertNo.Text = GlobalResources.LastAlert.No.ToString();
                Information_Textblock.Text = GlobalResources.LastAlert.Information;
                Activity_Textblock.Text = GlobalResources.LastAlert.Activity;
                Date_Textblock.Text = GlobalResources.LastAlert.Date;
                Time_Textblock.Text = GlobalResources.LastAlert.Time;
                TextBlock_AlertNo.Text = GlobalResources.LastAlert.No.ToString();
            });
        }

    }
}
