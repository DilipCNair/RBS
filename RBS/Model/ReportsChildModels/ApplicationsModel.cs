using System.ComponentModel;

namespace RBS.Model.ReportsChildModels
{
    public class ApplicationsModel : INotifyPropertyChanged
    {

        private string _Name;

        private int _Size;

        private string _Publisher;

        private string _Path;

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

        public int Size
        {
            get
            {
                return _Size;
            }
            set
            {
                if (_Size != value)
                {
                    _Size = value;
                    RaisePropertyChanged("Size");
                }
            }
        }

        public string Publisher
        {
            get
            {
                return _Publisher;
            }
            set
            {
                if (_Publisher != value)
                {
                    _Publisher = value;
                    RaisePropertyChanged("Publisher");
                }
            }
        }

        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                if (_Path != value)
                {
                    _Path = value;
                    RaisePropertyChanged("Path");
                }
            }
        }


        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
