using RBS.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
using RBS.Model.ReportsChildModels;
using RBS.Monitoring_Engine;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class FileSystemReportsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FileSystemReportsModel> _FSMList;

        public ObservableCollection<FileSystemReportsModel> FSMList
        {
            get
            { return _FSMList; }
            set
            {
                if(_FSMList!=value)
                {
                    _FSMList = value;
                    RaisePropertyChanged("FSMList");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MyICommand LoadCommand { get; private set; }

        public MyICommand RefreshCommand { get; private set; }

        public MyICommand ClearCommand { get; private set; }

        public FileSystemReportsViewModel()
        {
            FSMList = new ObservableCollection<FileSystemReportsModel>();
            LoadCommand = new MyICommand(Load);
            RefreshCommand = new MyICommand(Refresh);
            ClearCommand = new MyICommand(Clear);

        }

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Load()
        {
            FSMList = File_System_Monitoring.FSMListHolder;
        }

        public void Refresh()
        {
            FSMList = File_System_Monitoring.FSMListHolder;
        }

        public void Clear()
        {
            FSMList = null;
        }
    }
}
