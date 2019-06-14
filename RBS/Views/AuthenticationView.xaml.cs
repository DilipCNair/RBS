using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for AuthenticationScreen.xaml
    /// </summary>
    public partial class AuthenticationView : UserControl
    {
        public AuthenticationView()
        {
            InitializeComponent();
            TextBlock_Notification.Text = null;
            GlobalResources.NavigatedToMainWindow += GlobalResources_NavigatedToMainWindow;
            GlobalResources.NavigatedToMainAuthenticationWindow += GlobalResources_NavigatedToMainAuthenticationWindow;
            GlobalResources.AuthenticationError += GlobalResources_AuthenticationError;         
        }

        private void GlobalResources_AuthenticationError(object sender, System.EventArgs e)
        {
            TextBlock_Notification.Text = "Invalid Credentials";
        }

        private void GlobalResources_NavigatedToMainAuthenticationWindow(object sender, System.EventArgs e)
        {
            if (GlobalResources.IsMonitoringEngineOn)
                ButtonShutdown.IsEnabled = false;
            else
                ButtonShutdown.IsEnabled = true;
        }

        private void GlobalResources_NavigatedToMainWindow(object sender, System.EventArgs e)
        {
            TextBox_EmployeeID.Text = null;
            TextBox_MasterPassword.Password = null;
            TextBlock_Notification.Text = null;
        }

        private void ButtonShutdown_Clicked(object sender, RoutedEventArgs e)
        {
            GlobalResources.Shutdown();
        }

        private void TextBox_EmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
               GlobalResources.IInitiatedKeyDownFromTextBox();
        }

        private void TextBox_MasterPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                GlobalResources.IInitiatedKeyDownFromTextBox();
        }

        private void ButtonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            GlobalResources.MasterPassword = TextBox_MasterPassword.Password;
        }

        private void Button_Background_Clicked(object sender, RoutedEventArgs e)
        {
            GlobalResources.Minimizetheapp();
        }
    }
}
