using System;
using System.Collections.ObjectModel;
using RBS.Model.ReportsChildModels;
using System.ComponentModel;
using Microsoft.Win32;

namespace RBS.Monitoring_Engine
{
    public static class Applications_Monitoring
    {
        public static ObservableCollection<ApplicationsModel> PrgramHolderList;

        public static BackgroundWorker Worker { get; set; }

        public static void InitializeApplicationMonitoring()
        {
            PrgramHolderList = new ObservableCollection<ApplicationsModel>();
            AppResources.ApplicationMonitoringIsOn += AppResources_ApplicationMonitoringIsOn;
            AppResources.ApplicationMonitoringIsOff += AppResources_ApplicationMonitoringIsOff;
        }


        private static void AppResources_ApplicationMonitoringIsOn(object sender, EventArgs e)
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(PrgramHolderList);
        }

       
        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<ApplicationsModel> ProgramHolderListOfWorker = new ObservableCollection<ApplicationsModel>();
            ProgramHolderListOfWorker = e.Argument as ObservableCollection<ApplicationsModel>;


            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey rk;

            using (rk = Registry.CurrentUser.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var Size = sk.GetValue("EstimatedSize");
                            string publisher;
                            string path;
                            try
                            {
                                publisher = sk.GetValue("Publisher").ToString();
                                path = sk.GetValue("InstallLocation").ToString();
                            }
                            catch (Exception m)
                            {
                                publisher = "Exception";
                                path = "Exception";
                                GlobalException.No++;
                                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                                GlobalException.LogTheException();
                            }

                            if (publisher == null)
                                publisher = "no data";

                            if (path == null)
                                path = "no data";

                            ProgramHolderListOfWorker.Add(new ApplicationsModel { Name = displayName.ToString(), Size = Convert.ToInt32(Size), Path = path.ToString() , Publisher = publisher.ToString() });

                        }
                        catch (Exception m)
                        {

                            GlobalException.No++;
                            GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                            GlobalException.LogTheException();
                        }
                    }
                }
            }

            using (rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var Size = sk.GetValue("EstimatedSize");
                            string publisher;
                            string path;
                            try
                            {
                                publisher = sk.GetValue("Publisher").ToString();
                                path = sk.GetValue("InstallLocation").ToString();
                            }
                            catch (Exception m)
                            {
                                publisher = "Exception";
                                path = "Exception";
                                GlobalException.No++;
                                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                                GlobalException.LogTheException();
                            }

                            if (publisher == null)
                                publisher = "no data";

                            if (path == null)
                                path = "no data";

                            ProgramHolderListOfWorker.Add(new ApplicationsModel { Name = displayName.ToString(), Size = Convert.ToInt32(Size), Path = path.ToString(), Publisher = publisher.ToString() });

                        }
                        catch (Exception m)
                        {
                            GlobalException.No++;
                            GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                            GlobalException.LogTheException();
                        }
                    }
                }
            }

            using (rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var Size = sk.GetValue("EstimatedSize");
                            string publisher;
                            string path;
                            try
                            {
                                publisher = sk.GetValue("Publisher").ToString();
                                path = sk.GetValue("InstallLocation").ToString();
                            }
                            catch (Exception m)
                            {
                                publisher = "Exception";
                                path = "Exception";
                                GlobalException.No++;
                                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                                GlobalException.LogTheException();
                            }

                            if (publisher == null)
                                publisher = "no data";

                            if (path == null)
                                path = "no data";

                            ProgramHolderListOfWorker.Add(new ApplicationsModel { Name = displayName.ToString(), Size = Convert.ToInt32(Size), Path = path.ToString(), Publisher = publisher.ToString() });

                        }
                        catch (Exception m)
                        {
                            GlobalException.No++;
                            GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = m.Message });
                            GlobalException.LogTheException();
                        }
                    }
                }
            }            

            e.Result = ProgramHolderListOfWorker;
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ObservableCollection<ApplicationsModel> ProgramHolderList = e.Result as ObservableCollection<ApplicationsModel>;
            AppResources.ApplicationFetchingCompleted();
        }

        private static void AppResources_ApplicationMonitoringIsOff(object sender, EventArgs e)
        {
            
        }

       
    }
}
