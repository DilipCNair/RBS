using RBS.Model;
using System.Windows;
using RBS.Commands;

namespace RBS.ViewModel
{
    public class AuthenticationViewModel :BindableBase
    {

        public string TextBox_EmployeeID { get; set; }

        public string TextBox_MasterPassword { get; set; }

        private readonly AuthenticationModel AuthenticationModelObject;

        public MyICommand LoginCommand { get; set; }

        public AuthenticationViewModel()
        {
            AuthenticationModelObject = new AuthenticationModel();
            LoginCommand = new MyICommand(Login);
            GlobalResources.KeyDownFromTextBox += GlobalResources_KeyDownFromTextBox;
        }

        private void GlobalResources_KeyDownFromTextBox(object sender, System.EventArgs e)
        {
            Login();
        }

        public void Login()
        {
            TextBox_MasterPassword = GlobalResources.MasterPassword;
            GlobalResources.MasterPassword = null;
            if (string.Equals(TextBox_EmployeeID, AuthenticationModelObject.EmployeeID) & 
                string.Equals(TextBox_MasterPassword, AuthenticationModelObject.MasterPassword))
            {
                GlobalResources.InitiateNavigationToMainWindow();
                foreach (Window RBSWindow in Application.Current.Windows)
                {
                    if (RBSWindow is AuthenticationWindow)
                        RBSWindow.Hide();
                    if (RBSWindow is MainWindow)
                        RBSWindow.Show();
                }
                RBSNavigationSystem.IPressedAuthenticationViewLoginButton();
            }
            else
            {     
                //To bypass User AUthentication from SQL Database
                GlobalResources.InitiateNavigationToMainWindow();
                foreach (Window RBSWindow in Application.Current.Windows)
                {
                    if (RBSWindow is AuthenticationWindow)
                        RBSWindow.Hide();
                    if (RBSWindow is MainWindow)
                        RBSWindow.Show();
                }
                RBSNavigationSystem.IPressedAuthenticationViewLoginButton();

                //Real code for authentication
                //GlobalResources.IInitiatedAuthenticationError();

            }
        }
    }
}
