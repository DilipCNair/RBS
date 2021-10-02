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
    /// Interaction logic for RegistrationScreen.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            RBSNavigationSystem.IPressedRegistrationScreenCancelButton();
        }

        private void Button_Register_Clicked(object sender, RoutedEventArgs e)
        {
            AppResources.MasterPassword = PasswordBoxMasterPassword.Password;
            AppResources.ConfirmMasterPassword = PasswordBoxConfirmMasterPassword.Password;
        }
    }
}
