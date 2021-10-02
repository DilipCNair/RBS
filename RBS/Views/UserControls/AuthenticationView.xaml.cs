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
            AppResources.NavigatedToMainWindow += AppResources_NavigatedToMainWindow;
            AppResources.NavigatedToMainAuthenticationWindow += AppResources_NavigatedToMainAuthenticationWindow;
            AppResources.AuthenticationError += AppResources_AuthenticationError;         
        }

        private void AppResources_AuthenticationError(object sender, System.EventArgs e)
        {
            TextBlock_Notification.Text = "Invalid Credentials";
        }

        private void AppResources_NavigatedToMainAuthenticationWindow(object sender, System.EventArgs e)
        {
            if (AppResources.IsMonitoringEngineOn)
                ButtonShutdown.IsEnabled = false;
            else
                ButtonShutdown.IsEnabled = true;
        }

        private void AppResources_NavigatedToMainWindow(object sender, System.EventArgs e)
        {
            TextBox_EmployeeID.Text = null;
            TextBox_MasterPassword.Password = null;
            TextBlock_Notification.Text = null;
        }

        private void ButtonShutdown_Clicked(object sender, RoutedEventArgs e)
        {
            AppResources.Shutdown();
        }

        private void TextBox_EmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
               AppResources.InitiateKeyDownFromTextBox();
        }

        private void TextBox_MasterPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AppResources.InitiateKeyDownFromTextBox();
        }

        private void ButtonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            AppResources.MasterPassword = TextBox_MasterPassword.Password;

        }

        private void Button_Background_Clicked(object sender, RoutedEventArgs e)
        {
            AppResources.Minimizetheapp();
        }
    }
}
