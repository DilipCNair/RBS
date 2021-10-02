using RBS.Model;
using System.ComponentModel;
using RBS.Commands;
using RBS.Monitoring_Engine;

namespace RBS.ViewModel
{
    public class HomeViewModel : BindableBase, INotifyPropertyChanged
    {
        //private readonly HomeModel HomeModelObject;

        public MyICommand Command_ToggleButtonMEIsChecked { get; private set; }
        public MyICommand Command_ToggleButtonMEIsUnChecked { get; private set; }

        public HomeViewModel()
        {
            //HomeModelObject = new HomeModel();
            Command_ToggleButtonMEIsChecked = new MyICommand(ME_ToggledOn);
            Command_ToggleButtonMEIsUnChecked = new MyICommand(Me_ToggledOff);
        }

        private void ME_ToggledOn()
        {
            if(GlobalResources.UserInputMonitoringChecked)
               User_Input_Monitoring.InitialiseUserInputMonitoring();

            if(GlobalResources.ProcessMonitoring)
               Process_Monitoring.InitialiseProcessMonitoring();

            if(GlobalResources.FileSystemMonitoring)
               File_System_Monitoring.InitialiseFileSystemMonitoring();

            if (GlobalResources.ProcessPortMapper)
                PPM.InitializePPM();

            if (GlobalResources.WindowsServices)
                WindowsServices.InitializePPM();

            if (GlobalResources.ApplicationsMonitoring)
                Applications_Monitoring.InitializeApplicationMonitoring();

            GlobalResources.TurnOnMonitoringEngine();
            GlobalResources.InitiateSettingsUpdate();
        }

        private void Me_ToggledOff()
        {
            GlobalResources.TurnOffMonitoringEngine();
            GlobalResources.InitiateSettingsUpdate();
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
