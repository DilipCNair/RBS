using System.ComponentModel;

namespace RBS.Model.ReportsChildModels
{
    public class ProcessReportsModel : INotifyPropertyChanged
    {
        private string _ID;

        private string _Memory;

        private string _Name;

        private bool _Status;

        private bool _Selected;

        private string _ExecutionPath;

        private string _MachineName;

        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if(_ID!=value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID");
                }
            }
        }

        public string Memory
        {
            get
            {
                return _Memory;
            }
            set
            {
                if (_Memory != value)
                {
                    _Memory = value;
                    RaisePropertyChanged("Memory");
                }
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value + ".exe";
                    RaisePropertyChanged("Name");
                }
            }
        }

        public bool Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public string ExecutionPath
        {
            get
            { return _ExecutionPath; }
            set
            {
                if (_ExecutionPath != value)
                {
                    _ExecutionPath = value;
                    RaisePropertyChanged("ExecutionPath");
                }
            }

        }

        public string MachineName
        {
            get
            { return _MachineName; }
            set
            {
                if (_MachineName != value)
                {
                    _MachineName = value;
                    RaisePropertyChanged("MachineName");
                }
            }

        }

        public bool Selected
        {
            get { return _Selected; }
            set
            {
                if(_Selected!=value)
                {
                    _Selected = value;
                    RaisePropertyChanged("Selected");
                }
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
