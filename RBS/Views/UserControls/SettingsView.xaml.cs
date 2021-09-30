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
            GlobalResources.SelectedNetworkInterface = Interface_Selction_ComboBox.SelectedIndex;
            GlobalResources.SelectedProcessRestrictionType = ProcessSignature_ComboBox.SelectedIndex;
            GlobalResources.UpdateSettings += GlobalResources_UpdateSettings;
        }

        private void GlobalResources_UpdateSettings(object sender, System.EventArgs e)
        {
            if (GlobalResources.IsMonitoringEngineOn)
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
            GlobalResources.UserInputMonitoringChecked = true;
        }

        private void CheckBox_UIM_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.UserInputMonitoringChecked = false;
        }

        private void CheckBox_PM_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ProcessMonitoring = true;
        }

        private void CheckBox_PM_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ProcessMonitoring = false;
        }

        private void CheckBox_FSM_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.FileSystemMonitoring = true;
        }

        private void CheckBox_FSM_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.FileSystemMonitoring = false;
        }

        private void CheckBox_PS_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.PacketSniffer = true;
        }

        private void CheckBox_PS_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.PacketSniffer = false;
        }

        private void CheckBox_PPM_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ProcessPortMapper = true;
        }

        private void CheckBox_PPM_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ProcessPortMapper = false;
        }

        private void CheckBox_WRM_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.WindowsRegistryMonitoring = true;
        }

        private void CheckBox_WRM_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.WindowsRegistryMonitoring = false;
        }

        private void CheckBox_C_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.C_CheckBox = true;
        }

        private void CheckBox_C_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.C_CheckBox = false;
        }

        private void CheckBox_D_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.D_CheckBox = true;
        }

        private void CheckBox_D_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.D_CheckBox = false;
        }

        private void CheckBox_E_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.E_CheckBox = true;
        }

        private void CheckBox_E_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.E_CheckBox = false;
        }

        private void CheckBox_F_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.F_CheckBox = true;
        }

        private void CheckBox_F_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.F_CheckBox = false;
        }

        private void Interface_Selction_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalResources.SelectedNetworkInterface = Interface_Selction_ComboBox.SelectedIndex;
        }

        private void CheckBox_WSM_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.WindowsServices = true;
        }

        private void CheckBox_WSM_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.WindowsServices = false;
        }

        private void CheckBox_Applications_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ApplicationsMonitoring = true;
        }

        private void CheckBox_Applications_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.ApplicationsMonitoring = false;
        }

        private void ToggleButton_AlertMailing_Checked(object sender, RoutedEventArgs e)
        {
            GlobalResources.AlertMailing = true;
        }

        private void ToggleButton_AlertMailing_Unchecked(object sender, RoutedEventArgs e)
        {
            GlobalResources.AlertMailing = false;
        }

        private void ProcessSignature_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalResources.SelectedProcessRestrictionType = ProcessSignature_ComboBox.SelectedIndex;
        }
    }
}
