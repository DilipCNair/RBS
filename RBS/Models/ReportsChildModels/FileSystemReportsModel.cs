using System.ComponentModel;

namespace RBS.Model.ReportsChildModels
{
    public class FileSystemReportsModel : INotifyPropertyChanged
    {
        private string _Time;

        private string _ChangeType;

        private string _FileType;

        private string _Name;

        private string _Permissions;

        private string _Size;

        private string _FullPath;

        private string _Author;

        public string Time
        {
            get
            {
                return _Time;
            }
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    RaisePropertyChanged("Time");
                }
            }
        }
        public string ChangeType
        {
            get
            {
                return _ChangeType;
            }
            set
            {
                if (_ChangeType != value)
                {
                    _ChangeType = value;
                    RaisePropertyChanged("ChangeType");
                }
            }
        }
        public string FileType
        {
            get
            {
                return _FileType;
            }
            set
            {
                if(_FileType!=value)
                {
                    _FileType = value;
                    RaisePropertyChanged("FileType");
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
                if(_Name!=value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Permissions
        {
            get
            {
                return _Permissions;
            }
            set
            {
                if(_Permissions!=value)
                {
                    _Permissions = value;
                    RaisePropertyChanged("Permissions");
                }
            }
        }
        public string Size
        {
            get
            {
                return _Size;
            }
            set
            {
                if(_Size!=value)
                {
                    _Size = value;
                    RaisePropertyChanged("Size");
                }
            }
        }
        public string FullPath
        {
            get
            {
                return _FullPath;
            }
            set
            {
                if(_FullPath!=value)
                {
                    _FullPath = value;
                    RaisePropertyChanged("FullPath");
                }
            }
        }

        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                if (_Author != value)
                {
                    _Author = value;
                    RaisePropertyChanged("Author");
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
