using System;
using System.ComponentModel;
using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace RBS.Monitoring_Engine
{
    public static class Process_Monitoring
    {
        private static ObservableCollection<ProcessReportsModel> _ProcessListHolder;

        public static ObservableCollection<ProcessReportsModel> ProcessListHolder
        {
            get
            {
                return _ProcessListHolder;
            }
            set
            {
                if(_ProcessListHolder!=value)
                {
                    _ProcessListHolder = value;
                    AppResources.DetectedNewProcess();
                }
            }
        }

        public static BackgroundWorker Worker { get; set; }

        public static DispatcherTimer Timer { get; set; }
      
        public static void InitialiseProcessMonitoring()
        {
            AppResources.ProcessMonitoringIsOn += AppResources_ProcessMonitoringIsOn;
            AppResources.ProcessMonitoringIsOff += AppResources_ProcessMonitoringIsOff;
        }      

        private static void AppResources_ProcessMonitoringIsOn(object sender, EventArgs e)
        {
            StartProcessMonitoring();
        }

        private static void AppResources_ProcessMonitoringIsOff(object sender, EventArgs e)
        {
            StopProcessMonitoring();
        }

        public static void StartProcessMonitoring()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(5);
            Timer.Tick += Timer_Tick;
            Timer.Start();          
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            CheckAllProcesses();
        }

        public static void CheckAllProcesses()
        {
            Worker = new BackgroundWorker();
            ProcessListHolder = new ObservableCollection<ProcessReportsModel>();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(ProcessListHolder);
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<ProcessReportsModel> ProcessListHolder_Worker = e.Argument as ObservableCollection<ProcessReportsModel>;
            Process[] processlist = Process.GetProcesses();

            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                ProcessListHolder_Worker.Clear();
            try
            {
                foreach (Process theprocess in processlist)
                    {
                        double memory;
                        ProcessReportsModel ProcessData = new ProcessReportsModel();
                        ProcessData.ID = theprocess.Id.ToString();
                        memory = theprocess.PrivateMemorySize64;
                        memory = memory / 1000000;                       
                        ProcessData.Memory = memory.ToString() + " MB";
                        ProcessData.Name = theprocess.ProcessName;
                        ProcessData.Status = theprocess.Responding;                      
                        try
                        {
                            ProcessData.ExecutionPath = theprocess.MainModule.FileName;
                            ProcessData.MachineName = theprocess.MachineName;
                        }
                        catch(Win32Exception w)
                        {
                            ProcessData.ExecutionPath = w.Message;
                            ProcessData.MachineName = w.Message;
                        }

                        ProcessListHolder_Worker.Add(ProcessData);
                    }
                }
                catch (Exception)
                { }
            }));
            e.Result = ProcessListHolder_Worker;
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ObservableCollection<ProcessReportsModel> ProcessListHolder = e.Result as ObservableCollection<ProcessReportsModel>;
            AppResources.ProcessLoadComplete();
            if(AppResources.IsRestrictionsMonitoringSet & AppResources.IsProcessRestrictionsSet)
            foreach (ProcessReportsModel Process in ProcessListHolder)
            {
                Agents.Agent_Processes.ProcessAnalyse(Process);
            }
        }

        public static void StopProcessMonitoring()
        {
            Timer.Stop();
        }
    }
}
