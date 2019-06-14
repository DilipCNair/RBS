using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS.Model.ReportsChildModels
{
    public class WindowsServices_Model : INotifyPropertyChanged
    {
        private string _Service;

        private string _Information;

        private string _Status;

        public string Service
        {
            get
            {
                return _Service;
            }
            set
            {
                if (_Service != value)
                {
                    _Service = value;
                    RaisePropertyChanged("Service");
                }
            }
        }

        public string Information
        {
            get
            {
                return _Information;
            }
            set
            {
                if (_Information != value)
                {
                    _Information = value;
                    RaisePropertyChanged("Information");
                }
            }
        }

        public string Status
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
