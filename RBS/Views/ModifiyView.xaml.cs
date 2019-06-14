using System.Windows;
using System.Windows.Controls;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for Modify.xaml
    /// </summary>
    public partial class ModifyView : UserControl
    {
        public ModifyView()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Clicked(object sender, RoutedEventArgs e)
        {
            RBSNavigationSystem.IPressedModifyViewCancelButton();
        }

        private void ButtonContinue_Clicked(object sender, RoutedEventArgs e)
        {
            GlobalResources.MasterPassword = TextBox_MasterPassword.Password;
        }
    }
}
