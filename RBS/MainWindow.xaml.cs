using System;
using MahApps.Metro.Controls;

namespace RBS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        NotificationWindow NotificationWindow = new NotificationWindow();
        public MainWindow()
        {
            InitializeComponent();
            GlobalResources.ShowNotiffication += GlobalResources_ShowNotiffication;
            NotificationWindow.Hide();
        }

        private void GlobalResources_ShowNotiffication(object sender, EventArgs e)
        {
            NotificationWindow.Show();
        }

        public void Notify()
        {
            NotificationWindow NotificationWindow = new NotificationWindow();
            NotificationWindow.Show();
        }
    }
}
