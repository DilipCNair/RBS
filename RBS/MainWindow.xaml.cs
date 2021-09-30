using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace RBS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //GlobalResources.ShowNotiffication += GlobalResources_ShowNotiffication;
            //Hide();
        }

        //private void GlobalResources_ShowNotiffication(object sender, EventArgs e)
        //{
        //    foreach (Window RBSWindow in Application.Current.Windows)
        //    {
        //        if (RBSWindow is NotificationWindow)
        //            RBSWindow.Show();
        //    }
        //}
    }
}
