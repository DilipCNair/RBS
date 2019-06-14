using System;
using System.Collections.ObjectModel;
using RBS.Model.ReportsChildModels;
using RBS.Monitoring_Engine;
using RBS.Commands;
using System.ComponentModel;
using System.Windows.Data;

namespace RBS.ViewModel
{
    public class CustomizeViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<FSC_Restrictions> _AllFSCRestrictions;

        public ObservableCollection<FSC_Restrictions> AllFSCRestrictions
        {
            get { return _AllFSCRestrictions; }
            set
            {
                if(_AllFSCRestrictions!=value)
                {
                    _AllFSCRestrictions = value;
                    RaisePropertyChanged("AllFSCRestrictions");
                }
            }
        }
       
        private ObservableCollection<ProcessReportsModel> _ProcessList;

        public ObservableCollection<ProcessReportsModel> ProcessList
        {
            get
            {
                return _ProcessList;
            }
            set
            {
                if (_ProcessList != value)
                {
                    _ProcessList = value;
                    RaisePropertyChanged("ProcessList");
                }
            }
        }

        private ObservableCollection<ProcessReportsModel> _SelectedProcesses;

        public ObservableCollection<ProcessReportsModel> SelectedProcesses
        {
            get
            {
                return _SelectedProcesses;
            }
            set
            {
                if (_SelectedProcesses != value)
                {
                    _SelectedProcesses = value;
                    RaisePropertyChanged("SelectedProcesses");
                }
            }
        }

        public MyICommand AddDirectory_Command { get; set; }

        public MyICommand AddFile_Command { get; set; }

        public MyICommand LoadCommand { get; private set; }

        public MyICommand SelectAllCommand { get; private set; }

        public MyICommand AddToSignatureCommand { get; private set; }

        public CustomizeViewModel()
        {
            AllFSCRestrictions = new ObservableCollection<FSC_Restrictions>();
            SelectedProcesses = new ObservableCollection<ProcessReportsModel>();

            AddDirectory_Command = new MyICommand(AddDirectory);
            AddFile_Command = new MyICommand(AddFile);
            LoadCommand = new MyICommand(Load);
            SelectAllCommand = new MyICommand(SelectAll);
            AddToSignatureCommand = new MyICommand(AddToSignature);

            GlobalResources.ProcessList = new ObservableCollection<ProcessReportsModel>();
            Process_Exceptions();
        }

        public void Process_Exceptions()
        {
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "Idle" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "svchost" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "conhost" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "System" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "backgroundTaskHost" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "LocationNotificationWindows" });
            GlobalResources.ProcessList.Add(new ProcessReportsModel { Name = "audiodg" });
        }

        public void AddDirectory()
        {
            AllFSCRestrictions = new ObservableCollection<FSC_Restrictions>(Restrictions.AllFSC_Restritions);
            GlobalResources.IsFileSytemRestrictionSet = true;
        }

        public void AddFile()
        {
            AllFSCRestrictions = new ObservableCollection<FSC_Restrictions>(Restrictions.AllFSC_Restritions);
            GlobalResources.IsFileSytemRestrictionSet = true;
        }

        public void Load()
        {
            ProcessList = Process_Monitoring.ProcessListHolder;           
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ProcessList);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            catch (Exception) { }          
        }

        public void SelectAll()
        {
            foreach(ProcessReportsModel PM in ProcessList)
            {
                if (PM.Selected == false)
                    PM.Selected = true;
                else
                    PM.Selected = false;
            }
        }

        public void AddToSignature()
        {
            foreach (ProcessReportsModel PM in ProcessList)
            {
                if (PM.Selected & !SelectedProcesses.Contains(PM))
                    SelectedProcesses.Add(PM);
            }
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SelectedProcesses);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            catch (Exception) { }
            Restrictions.AllProcess_Restrictions = SelectedProcesses;
            GlobalResources.IsProcessRestrictionsSet = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
