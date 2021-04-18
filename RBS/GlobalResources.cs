using RBS.Model;
using RBS.Model.ReportsChildModels;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace RBS
{
    public static class GlobalResources
    {

        public static bool IsMonitoringEngineOn;

        public static event EventHandler UserInputMonitoringIsOn;

        public static event EventHandler ProcessMonitoringIsOn;

        public static event EventHandler FileSystemMonitoringIsOn;

        public static event EventHandler PacketSnifferIsOn;

        public static event EventHandler ProcessPortMapperIsOn;

        public static event EventHandler WindowsServicesIsOn;

        public static event EventHandler ApplicationMonitoringIsOn;

        public static event EventHandler UserInputMonitoringIsOff;

        public static event EventHandler ProcessMonitoringIsOff;

        public static event EventHandler FileSystemMonitoringIsOff;

        public static event EventHandler PacketSnifferIsOff;

        public static event EventHandler ProcessPortMapperIsOff;

        public static event EventHandler WindowsServicesIsOff;

        public static event EventHandler ApplicationMonitoringIsOff;

        public static event EventHandler NewKeyStrokesCaptured;

        public static event EventHandler NewMouseStrokesCaptured;

        public static event EventHandler NewProcessDetected;

        public static event EventHandler NavigatedToMainWindow;

        public static event EventHandler NavigatedToMainAuthenticationWindow;

        public static event EventHandler UpdateSettings;

        public static event EventHandler AuthenticationError;

        public static event EventHandler KeyDownFromTextBox;

        public static event EventHandler PPMOver;

        public static event EventHandler WinServOver;

        public static event EventHandler AllApplicationsFetched;

        public static event EventHandler Minimize;

        public static event EventHandler ShowNotiffication;

        public static event EventHandler SendMail;

        public static event EventHandler AlertGenerated;

        public static event EventHandler GettingAllProcesses;

        public static event EventHandler RefreshProcessList;

        public static event EventHandler AlertSound;

        public static event EventHandler UpdateAlert;

        public static event EventHandler Show_User;

        public static ObservableCollection<User> Users { get; set; }

        public static void ITurnedOnMonitoringEngine()
        {
            IsMonitoringEngineOn = true;
            UserInputMonitoringIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            ProcessMonitoringIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            FileSystemMonitoringIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            PacketSnifferIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            ProcessPortMapperIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            WindowsServicesIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            ApplicationMonitoringIsOn?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void PlayAlertSound()
        {
            AlertSound?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IWantToShowCurrentUser()
        {
            Show_User?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IWantToUpdateAlert(AlertsModel Alert)
        {
            LastAlert = new AlertsModel();
            LastAlert.Activity = Alert.Activity;
            LastAlert.Time = Alert.Time;
            LastAlert.Date = Alert.Date;
            LastAlert.Information = Alert.Information;
            LastAlert.No = Alert.No;
            UpdateAlert?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IWantToShowNotification()
        {
            ShowNotiffication?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IWantToRefreshProcessList()
        {
            RefreshProcessList?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void ProcessLoadComplete()
        {
            GettingAllProcesses?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IGeneratedAlert()
        {
            AlertGenerated?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IWantToSendMail()
        {
            SendMail?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void Minimizetheapp()
        {
            Minimize?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void ITurnedOffMonitoringEngine()
        {
            IsMonitoringEngineOn = false;
            ProcessMonitoringIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            FileSystemMonitoringIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            PacketSnifferIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            ProcessPortMapperIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            WindowsServicesIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
            ApplicationMonitoringIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IInitiatedNavigationToMainWindow()
        {
            NavigatedToMainWindow?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IInitiatedKeyDownFromTextBox()
        {
            KeyDownFromTextBox?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IInitiatedAuthenticationError()
        {
            AuthenticationError?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IInitiatedSettingsUpdate()
        {
            UpdateSettings?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void IInitiatedNavigationToAuthenticationWindow()
        {
            NavigatedToMainAuthenticationWindow?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        // Special Case - UIM needs to be turned off just before calling F_Dispose() in FSM since RBS resides in F: Drive
        public static void ITurnerOffUIM()
        {
            UserInputMonitoringIsOff?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void PPMIsOver()
        {
            PPMOver?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void WinServIsOver()
        {
            WinServOver?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void ApplicationFetchingCompleted()
        {
            AllApplicationsFetched?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void NewKeyStrokesHasCaptured()
        {
            NewKeyStrokesCaptured?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static void NewMouseStrokesHasCaptured()
        {
            NewMouseStrokesCaptured?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static ObservableCollection<ProcessReportsModel> ProcessList { get; set; }

        public static string Path { get; set; }

        public static User CurrentUser { get; set; }

        public static bool C_CheckBox { get; set; }

        public static bool D_CheckBox { get; set; }

        public static bool E_CheckBox { get; set; }

        public static bool F_CheckBox { get; set; }

        public static bool UserInputMonitoringChecked { get; set; }

        public static bool ProcessMonitoring { get; set; }

        public static bool FileSystemMonitoring { get; set; }

        public static bool PacketSniffer { get; set; }

        public static bool ProcessPortMapper { get; set; }

        public static bool WindowsServices { get; set; }

        public static bool WindowsRegistryMonitoring { get; set; }

        public static bool ApplicationsMonitoring { get; set; }

        public static bool IsNotificationWindowShown { get; set; }

        public static bool AlertMailing { get; set; }

        public static int SelectedNetworkInterface { get; set; }

        public static int SelectedProcessRestrictionType { get; set; }

        public static AlertsModel LastAlert { get; set; }

        public static void InitialiseGlobalResources()
        {
            Path = Assembly.GetExecutingAssembly().Location;
        }

        public static void IDetectedNewProcess()
        {
            NewProcessDetected?.Invoke(typeof(GlobalResources), EventArgs.Empty);
        }

        public static string MasterPassword { get; set; }

        public static bool IsRestrictionsMonitoringSet { get; set; }

        public static bool IsProcessRestrictionsSet { get; set; }      

        public static bool IsFileSytemRestrictionSet { get; set; }

        public static string ConfirmMasterPassword { get; set; }

        public static int TotalAlerts { get; set; }

        public static void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
