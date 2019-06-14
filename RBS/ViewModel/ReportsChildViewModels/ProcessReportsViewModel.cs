using System;
using System.Collections.ObjectModel;
using RBS.Model.ReportsChildModels;
using RBS.Monitoring_Engine;
using RBS.Commands;
using System.ComponentModel;
using System.Windows.Data;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class ProcessReportsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProcessReportsModel> _ProcessList;       

        public ObservableCollection<ProcessReportsModel> ProcessList
        {
            get
            {
                return _ProcessList;
            }
            set
            {
                if(_ProcessList!=value)
                {
                    _ProcessList = value;
                    RaisePropertyChanged("ProcessList");
                }
            }
        }
       
        public MyICommand LoadCommand { get; private set; }

        public MyICommand ClearCommand { get; private set; }

        public ProcessReportsViewModel()
        {
            ProcessList = new ObservableCollection<ProcessReportsModel>();         
            LoadCommand = new MyICommand(Load);
            ClearCommand = new MyICommand(Clear);
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

        public void Clear()
        {
            ProcessList = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string Property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
