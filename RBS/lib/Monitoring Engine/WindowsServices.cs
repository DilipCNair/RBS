using System;
using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceProcess;

namespace RBS.Monitoring_Engine
{
    public static class WindowsServices
    {
        public static BGWData BGWData { get; set; }

        public static BackgroundWorker Worker { get; set; }

        public static void InitializePPM()
        {
            BGWData = new BGWData();
            GlobalResources.WindowsServicesIsOn += GlobalResources_WindowsServicesIsOn;       
        }

        private static void GlobalResources_WindowsServicesIsOn(object sender, EventArgs e)
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(BGWData);
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BGWData BGWDataOfWorker = e.Argument as BGWData;

            ServiceController[] services = ServiceController.GetServices();

            ServiceController[] devices = ServiceController.GetDevices();

            // try to find service name
            foreach (ServiceController service in services)
            {
               BGWDataOfWorker.WinServHolder.Add(new WindowsServices_Model
                {
                    Service = service.ServiceName,
                    Information = service.DisplayName,
                    Status = service.Status.ToString()
                });
            }

            foreach (ServiceController device in devices)
            {
                BGWDataOfWorker.WinDriverHolder.Add(new WindowsServices_Model
                {
                    Service = device.ServiceName,
                    Information = device.DisplayName,
                    Status = device.Status.ToString()
                });
            }

        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BGWData BGWData = e.Result as BGWData;
            Worker.Dispose();
            GlobalResources.WinServIsOver();
        }      
    }

    public class BGWData
    {
        public ObservableCollection<WindowsServices_Model> WinServHolder { get; set; }

        public ObservableCollection<WindowsServices_Model> WinDriverHolder { get; set; }
        public BGWData()
        {
            WinServHolder = new ObservableCollection<WindowsServices_Model>();

            WinDriverHolder = new ObservableCollection<WindowsServices_Model>();
        }
    }
}
