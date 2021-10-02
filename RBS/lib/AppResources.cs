using RBS.Model;
using RBS.Model.ReportsChildModels;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace RBS
{
    public static class AppResources
    {
        #region 1. Static Events
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
        #endregion

        #region 2. Static Event Handlers
        public static void TurnOnMonitoringEngine()
        {
            IsMonitoringEngineOn = true;
            UserInputMonitoringIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            ProcessMonitoringIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            FileSystemMonitoringIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            PacketSnifferIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            ProcessPortMapperIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            WindowsServicesIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
            ApplicationMonitoringIsOn?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void PlayAlertSound()
        {
            AlertSound?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void ShowCurrentUser()
        {
            Show_User?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void Update_Alert(AlertsModel Alert)
        {
            LastAlert = new AlertsModel
            {
                Activity = Alert.Activity,
                Time = Alert.Time,
                Date = Alert.Date,
                Information = Alert.Information,
                No = Alert.No
            };
            UpdateAlert?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void Show_Notification()
        {
            ShowNotiffication?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void Refresh_ProcessList()
        {
            RefreshProcessList?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void ProcessLoadComplete()
        {
            GettingAllProcesses?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void GeneratedAlert()
        {
            AlertGenerated?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void Send_Mail()
        {
            SendMail?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void Minimizetheapp()
        {
            Minimize?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void TurnOffMonitoringEngine()
        {
            IsMonitoringEngineOn = false;
            ProcessMonitoringIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
            FileSystemMonitoringIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
            PacketSnifferIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
            ProcessPortMapperIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
            WindowsServicesIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
            ApplicationMonitoringIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void InitiateNavigationToMainWindow()
        {
            NavigatedToMainWindow?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void InitiateKeyDownFromTextBox()
        {
            KeyDownFromTextBox?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void InitiateAuthenticationError()
        {
            AuthenticationError?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void InitiateSettingsUpdate()
        {
            UpdateSettings?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void InitiateNavigationToAuthenticationWindow()
        {
            NavigatedToMainAuthenticationWindow?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        // UIM needs to be turned off just before calling F_Dispose() in FSM since RBS resides in F: Drive
        public static void TurnOffUIM()
        {
            UserInputMonitoringIsOff?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void PPMIsOver()
        {
            PPMOver?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void WinServIsOver()
        {
            WinServOver?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void ApplicationFetchingCompleted()
        {
            AllApplicationsFetched?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void NewKeyStrokesHasCaptured()
        {
            NewKeyStrokesCaptured?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void NewMouseStrokesHasCaptured()
        {
            NewMouseStrokesCaptured?.Invoke(typeof(AppResources), EventArgs.Empty);
        }

        public static void DetectedNewProcess()
        {
            NewProcessDetected?.Invoke(typeof(AppResources), EventArgs.Empty);
        }
        #endregion

        #region 3. Static Properties

        public static ObservableCollection<User> Users { get; set; }

        public static ObservableCollection<ProcessReportsModel> ProcessList { get; set; }

        public static string Path { get; set; }

        public static User CurrentUser { get; set; }

        public static bool IsMonitoringEngineOn;

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

        public static string MasterPassword { get; set; }

        public static bool IsRestrictionsMonitoringSet { get; set; }

        public static bool IsProcessRestrictionsSet { get; set; }

        public static bool IsFileSytemRestrictionSet { get; set; }

        public static string ConfirmMasterPassword { get; set; }

        public static int TotalAlerts { get; set; }

        #endregion

        #region 4. Static Methods

        public static void InitialiseAppResources()
        {
            Path = Assembly.GetExecutingAssembly().Location;
        }

        public static void Shutdown()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
