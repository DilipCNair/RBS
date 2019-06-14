using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RBS.Model.ReportsChildModels
{
    public class UIMModel : INotifyPropertyChanged
    {
        private string _KeyStrokesCaptured;

        private string _MouseStrokesCaptured;

        public string KeyStrokesCaptured
        {
            get
            {
                return _KeyStrokesCaptured;
            }
            set
            {
                if (_KeyStrokesCaptured != value)
                {
                    _KeyStrokesCaptured = value;
                    RaisePropertyChanged("KeyStrokesCaptured");
                }
            }
        }

        public string MouseStrokesCaptured
        {
            get
            {
                return _MouseStrokesCaptured;
            }
            set
            {
                if (_MouseStrokesCaptured != value)
                {
                    _MouseStrokesCaptured = value;
                    RaisePropertyChanged("MouseStrokesCaptured");
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
