using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace RBS
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : MetroWindow
    {
        public AuthenticationWindow()
        {
            InitializeComponent();
            GlobalResources.Minimize += GlobalResources_Minimize;
            Hide();
        }

        private void GlobalResources_Minimize(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
