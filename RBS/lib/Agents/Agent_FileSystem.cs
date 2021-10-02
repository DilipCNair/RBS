using System.IO;
using System;
using System.Windows;
using RBS.Model;

namespace RBS.Agents
{
    public static class Agent_FileSystem
    {
        public static void Analyse(string FS_Activity,string Author)
        {
            foreach (FSC_Restrictions FS_Restriction in Restrictions.AllFSC_Restritions)
            {
                //Variable Declaration
                string _File = FS_Restriction.File;
                string _Directory = FS_Restriction.Directory;

                //To remove extra \ in C - paths
                char[] Temp = FS_Activity.ToCharArray();
                if (Temp[3] == '\\')
                    FS_Activity = FS_Activity.Remove(3, 1);

                //Checking Whether the Change is in the file or directory
                //For a File
                #region 1.File
                if (Path.HasExtension(FS_Activity))
                {
                    bool AddAlert = true;
                    //Check whether the change is done by owner or not
                    if (!string.Equals(Author, AppResources.CurrentUser.UserName))
                    {
                        //Direct Changes to the File being locked
                        if (!string.Equals(_File, "null") & string.Equals(_File, FS_Activity))
                        {
                            foreach (AlertsModel AM in GlobalAlerts.AllAlerts)
                            {
                                if (string.Equals(AM.Activity, FS_Activity))
                                {
                                    AddAlert = false;
                                    AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Information = "File System Restriction Violation", Activity = FS_Restriction.File, Type = "File" };
                                    AppResources.Update_Alert(Alert);
                                }
                            }
                            if (AddAlert)
                            {
                                GlobalAlerts.No++;
                                AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Information = "File System Restriction Violation", Activity = FS_Restriction.File, Type = "File" };
                                Application.Current.Dispatcher.Invoke(delegate
                                {
                                    GlobalAlerts.AllAlerts.Add(Alert);
                                });
                                MailingSystem.Mdata.Alert = Alert;
                                MailingSystem.Mdata.CompromisedUser = Author;
                                AppResources.Send_Mail();
                                AppResources.Update_Alert(Alert);
                            }
                            AppResources.GeneratedAlert();
                            if (AppResources.IsNotificationWindowShown == false)
                                Notify();

                        } 
                    }
                }
                #endregion
                //For a Directory
                #region 2. Directory
                else
                {
                    if (!string.Equals(Author, AppResources.CurrentUser.UserName))
                    {
                        //Changes to the contents inside the root folder being locked
                        if (!string.Equals(_Directory, "null") & string.Equals(Directory.GetParent(FS_Activity).ToString(), _Directory))
                        {
                            bool AddAlert = true;
                            FS_Activity = Directory.GetParent(FS_Activity).ToString();
                            AlertsModel Alert = new AlertsModel
                            {
                                No = GlobalAlerts.No,
                                Time = DateTime.Now.ToShortTimeString(),
                                Date = DateTime.Now.ToShortDateString(),
                                Information = "File System Restriction Violation",
                                Activity = _Directory,
                                Type = "Directory"
                            };

                            if (string.Equals(_Directory, FS_Activity))
                            {
                                foreach (AlertsModel AM in GlobalAlerts.AllAlerts)
                                {
                                    if (string.Equals(AM.Activity, FS_Activity))
                                    {
                                        AddAlert = false;
                                        AppResources.Update_Alert(Alert);
                                    }
                                }

                                if (AddAlert)
                                {
                                    GlobalAlerts.No++;
                                    Application.Current.Dispatcher.Invoke(delegate
                                    {
                                        GlobalAlerts.AllAlerts.Add(Alert);
                                    });
                                    AppResources.Update_Alert(Alert);
                                    MailingSystem.Mdata.Alert = Alert;
                                    MailingSystem.Mdata.CompromisedUser = Author;
                                    AppResources.Send_Mail();
                                }

                                AppResources.GeneratedAlert();
                                if (AppResources.IsNotificationWindowShown == false)
                                    Notify();
                            }
                        }

                        //Direct changes to the root folder being locked
                        else
                        {
                            if (string.Equals(_Directory, FS_Activity))
                            {
                                bool AddAlert = true;
                                AlertsModel Alert = new AlertsModel { No = GlobalAlerts.No, Time = DateTime.Now.ToShortTimeString(), Date = DateTime.Now.ToShortDateString(), Information = "File System Restriction Violation", Activity = _Directory, Type = "Directory" };
                                foreach (AlertsModel AM in GlobalAlerts.AllAlerts)
                                {
                                    if (string.Equals(AM.Activity, FS_Activity))
                                    {
                                        AddAlert = false;
                                        AppResources.Update_Alert(Alert);
                                    }
                                }

                                if (AddAlert)
                                {
                                    GlobalAlerts.No++;
                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        GlobalAlerts.AllAlerts.Add(Alert);
                                    });
                                    AppResources.Update_Alert(Alert);
                                    MailingSystem.Mdata.Alert = Alert;
                                    MailingSystem.Mdata.CompromisedUser = Author;
                                    AppResources.Send_Mail();
                                }
                                AppResources.GeneratedAlert();
                                if (AppResources.IsNotificationWindowShown == false)
                                    Notify();
                            }
                        }
                    }
                }
                #endregion
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
