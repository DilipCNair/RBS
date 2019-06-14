using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS.Model.ReportsChildModels
{
    public class Process_Port_Map_Model : INotifyPropertyChanged
    {
       
        private string _Name;

        private string _PortNumber;

        private string _Protocol;

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

        public string PortNumber
        {
            get
            {
                return _PortNumber;
            }
            set
            {
                if (_PortNumber != value)
                {
                    _PortNumber = value;
                    RaisePropertyChanged("PortNumber");
                }
            }
        }

        public string Protocol
        {
            get
            {
                return _Protocol;
            }
            set
            {
                if (_Protocol != value)
                {
                    _Protocol = value;
                    RaisePropertyChanged("Protocol");
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
