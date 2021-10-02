using System;
using RBS.Model.ReportsChildModels;
using System.Windows;
using RBS.Model;

namespace RBS.Agents
{
    public static class Agent_Processes
    {
        public static void ProcessAnalyse(ProcessReportsModel Process)
        {
            bool AuthorizeProcessAnalyse = true;

            bool IsProcessUnwanted = true;
            bool IsProcessBlacklisted = false;

            bool AddAlert_W = true;
            bool AddAlert_B = true;

            foreach (ProcessReportsModel EProcess in AppResources.ProcessList)
            {
                if (string.Equals(EProcess.Name, Process.Name))
                    AuthorizeProcessAnalyse = false;
            }

            if (AuthorizeProcessAnalyse)
            {    
                if (AppResources.SelectedProcessRestrictionType == 0)
                {
                    //Checks whether a process is there in the whitelist, if not triggers an alert
                    foreach (ProcessReportsModel _Process in Restrictions.AllProcess_Restrictions)
                    {
                        if (string.Equals(_Process.Name, Process.Name) & string.Equals(_Process.ExecutionPath, Process.ExecutionPath))
                        {
                            IsProcessUnwanted = false;
                        }
                       
                    }
                    if (IsProcessUnwanted)
                    {                                             
                        foreach (AlertsModel AM in GlobalAlerts.AllAlerts)
                        {
                            if (string.Equals(AM.Activity, Process.Name))
                            {
                                AddAlert_W = false;
                                AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Type = "UnWanted Process", Activity = Process.Name, Information = "Process Restriction Violation " };
                                AppResources.Update_Alert(Alert);
                            }
                        }
                        if (AddAlert_W)
                        {
                            GlobalAlerts.No++;
                            AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Type = "UnWanted Process", Activity = Process.Name, Information = "Process Restriction Violation " };
                            Application.Current.Dispatcher.Invoke(delegate
                            {          
                                GlobalAlerts.AllAlerts.Add(Alert);
                            });
                            AppResources.Update_Alert(Alert);
                        }
                        AppResources.GeneratedAlert();                       
                        if (!AppResources.IsNotificationWindowShown)
                        {
                            Notify();
                        }
                    }
                }
                else
                {
                    //Checks whether a process is there in the Blacklist, if not triggers an alert
                    foreach (ProcessReportsModel _Process in Restrictions.AllProcess_Restrictions)
                    {
                        if (string.Equals(_Process.Name, Process.Name) & string.Equals(_Process.ExecutionPath, Process.ExecutionPath))
                        {
                            IsProcessBlacklisted = true;
                        }
                        if (IsProcessBlacklisted)
                        {
                            foreach (AlertsModel AM in GlobalAlerts.AllAlerts)
                            {
                                if (string.Equals(AM.Activity, Process.Name))
                                {
                                    AddAlert_B = false;
                                    AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Type = "Blacklisted Process", Activity = Process.Name, Information = "Process Restriction Violation" };
                                    AppResources.Update_Alert(Alert);
                                }
                            }
                            if (AddAlert_B)
                            {
                                GlobalAlerts.No++;
                                AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Type = "Blacklisted Process", Activity = Process.Name, Information = "Process Restriction Violation" };
                                App.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    GlobalAlerts.AllAlerts.Add(Alert);
                                });
                                AppResources.GeneratedAlert();
                                AppResources.Update_Alert(Alert);
                            }
                            if (!AppResources.IsNotificationWindowShown)
                                Notify();
                        }
                        
                    }
                } 
            }
        }

        public static void Notify()
        {
            AppResources.IsNotificationWindowShown = true;
            Application.Current.Dispatcher.Invoke(delegate
            {
                foreach (Window RBSWindow in Application.Current.Windows)
                {
                    if (RBSWindow is NotificationWindow)
                    {
                        if (!RBSWindow.IsActive)
                        {
                            RBSWindow.Show();
                            RBSWindow.Activate();
                            RBSWindow.Focus();
                            break;
                        }
                    }
                }
            });
        }
    }
}
