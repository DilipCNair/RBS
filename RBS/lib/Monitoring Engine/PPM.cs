using System;
using RBS.Model.ReportsChildModels;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RBS.Monitoring_Engine
{
    public static class PPM
    {
        public static ObservableCollection<Process_Port_Map_Model> PPMListHolder { get; set; }

        public static BackgroundWorker Worker { get; set; }

        public static void InitializePPM()
        {
            PPMListHolder = new ObservableCollection<Process_Port_Map_Model>();
            GlobalResources.ProcessPortMapperIsOn += GlobalResources_ProcessPortMapperIsOn;
        }

        private static void GlobalResources_ProcessPortMapperIsOn(object sender, EventArgs e)
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.RunWorkerAsync(PPMListHolder);
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<Process_Port_Map_Model> PPMListOfWorker = e.Argument as ObservableCollection<Process_Port_Map_Model>;
            string[] rows;
            string[] tokens;
            string LocalAddress;
            string _Name;
            try
            {
                using (Process p = new Process())
                {
                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.Arguments = "-a -n -o";
                    ps.FileName = "netstat.exe";
                    ps.UseShellExecute = false;
                    ps.CreateNoWindow = true;
                    ps.RedirectStandardInput = true;
                    ps.RedirectStandardOutput = true;
                    ps.RedirectStandardError = true;

                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    StreamReader stdError = p.StandardError;

                    string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                    string exitStatus = p.ExitCode.ToString();

                    //Get The Rows
                    rows = Regex.Split(content, "\r\n");
                    foreach (string row in rows)
                    {
                        //Split it baby
                        tokens = Regex.Split(row, "\\s+");


                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                        {
                            LocalAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                            _Name = tokens[1] == "UDP" ? LookupProcess(Convert.ToInt16(tokens[4])) : LookupProcess(Convert.ToInt16(tokens[5]));
                            if (!_Name.Equals("Idle"))
                                PPMListOfWorker.Add(new Process_Port_Map_Model
                                {
                                    Protocol = LocalAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]),
                                    PortNumber = LocalAddress.Split(':')[1],
                                    Name = _Name
                                });
                        }
                    }
                    p.Kill();
                }
            }
            catch (Exception)
            {

            }
            e.Result = PPMListOfWorker;
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ObservableCollection<Process_Port_Map_Model> PPMListHolder = e.Result as ObservableCollection<Process_Port_Map_Model>;
            GlobalResources.PPMIsOver();
            Worker.Dispose();
        }

        public static string LookupProcess(int pid)
        {
            string procName;
            try
            {
                procName = Process.GetProcessById(pid).ProcessName;
            }
            catch (Exception) { procName = "UnIdentified"; }
            return procName;
        }
    }
}
