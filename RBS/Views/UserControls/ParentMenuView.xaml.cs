using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for ParentMenu.xaml
    /// </summary>
    public partial class ParentMenuView : UserControl
    {

        public ParentMenuView()
        {
            InitializeComponent();
            RBSNavigationSystem.AuthenticationViewLoginButtonPressed += RBSNavigationSystem_AuthenticationViewLoginButtonPressed;
        }

        private void RBSNavigationSystem_AuthenticationViewLoginButtonPressed(object sender, EventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");

           
        }

        private void ButtonHome_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuHomeButton();
        }

        private void ButtonAlerts_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuAlertsButton();
        }

        private void ButtonReports_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuReportsButton();
        }
        private void ButtonCustomize_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuCustomizeButton();
        }

        private void ButtonSettings_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuSettingsButton();
        }

        private void Button_Help_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsSelected");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonDefault");
            RBSNavigationSystem.IClickedParentMenuHelpsButton();
        }

        private void ButtonLogout_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Home.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Alerts.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Reports.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Customize.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Settings.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Help.Style = (Style)FindResource("StyleMainMenuButtonsDefault");
            Button_Logout.Style = (Style)FindResource("StyleLogoutButtonSelected");

            GlobalResources.IInitiatedNavigationToAuthenticationWindow();

            foreach (Window RBSWindow in Application.Current.Windows)
            {
                if (RBSWindow is MainWindow)
                    RBSWindow.Hide();
                if (RBSWindow is AuthenticationWindow)
                    RBSWindow.Show();               
            }
        }

       
    }
}
