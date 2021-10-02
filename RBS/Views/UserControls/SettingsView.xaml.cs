using System.Windows;
using System.Windows.Controls;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            AppResources.SelectedNetworkInterface = Interface_Selction_ComboBox.SelectedIndex;
            AppResources.SelectedProcessRestrictionType = ProcessSignature_ComboBox.SelectedIndex;
            AppResources.UpdateSettings += AppResources_UpdateSettings;
        }

        private void AppResources_UpdateSettings(object sender, System.EventArgs e)
        {
            if (AppResources.IsMonitoringEngineOn)
            {
                TreeView_ME.IsEnabled = false;
                TreeView_FSM.IsEnabled = false;
                Interface_Selction_ComboBox.IsEnabled = false;
                ProcessSignature_ComboBox.IsEnabled = false;

            }
            else
            {
                TreeView_ME.IsEnabled = true;
                TreeView_FSM.IsEnabled = true;
                Interface_Selction_ComboBox.IsEnabled = true;
                ProcessSignature_ComboBox.IsEnabled = true;
            }

        }     

        private void CheckBox_UIM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.UserInputMonitoringChecked = true;
        }

        private void CheckBox_UIM_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.UserInputMonitoringChecked = false;
        }

        private void CheckBox_PM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.ProcessMonitoring = true;
        }

        private void CheckBox_PM_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.ProcessMonitoring = false;
        }

        private void CheckBox_FSM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.FileSystemMonitoring = true;
        }

        private void CheckBox_FSM_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.FileSystemMonitoring = false;
        }

        private void CheckBox_PS_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.PacketSniffer = true;
        }

        private void CheckBox_PS_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.PacketSniffer = false;
        }

        private void CheckBox_PPM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.ProcessPortMapper = true;
        }

        private void CheckBox_PPM_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.ProcessPortMapper = false;
        }

        private void CheckBox_WRM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.WindowsRegistryMonitoring = true;
        }

        private void CheckBox_WRM_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.WindowsRegistryMonitoring = false;
        }

        private void CheckBox_C_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.C_CheckBox = true;
        }

        private void CheckBox_C_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.C_CheckBox = false;
        }

        private void CheckBox_D_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.D_CheckBox = true;
        }

        private void CheckBox_D_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.D_CheckBox = false;
        }

        private void CheckBox_E_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.E_CheckBox = true;
        }

        private void CheckBox_E_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.E_CheckBox = false;
        }

        private void CheckBox_F_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.F_CheckBox = true;
        }

        private void CheckBox_F_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.F_CheckBox = false;
        }

        private void Interface_Selction_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppResources.SelectedNetworkInterface = Interface_Selction_ComboBox.SelectedIndex;
        }

        private void CheckBox_WSM_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.WindowsServices = true;
        }

        private void CheckBox_WSM_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.WindowsServices = false;
        }

        private void CheckBox_Applications_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.ApplicationsMonitoring = true;
        }

        private void CheckBox_Applications_UnChecked(object sender, RoutedEventArgs e)
        {
            AppResources.ApplicationsMonitoring = false;
        }

        private void ToggleButton_AlertMailing_Checked(object sender, RoutedEventArgs e)
        {
            AppResources.AlertMailing = true;
        }

        private void ToggleButton_AlertMailing_Unchecked(object sender, RoutedEventArgs e)
        {
            AppResources.AlertMailing = false;
        }

        private void ProcessSignature_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppResources.SelectedProcessRestrictionType = ProcessSignature_ComboBox.SelectedIndex;
        }
    }
}
