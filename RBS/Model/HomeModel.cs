using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS.Model
{
    public class HomeModel : INotifyPropertyChanged
    {
        private bool _METoggleButton;

        public bool METoggleButton
        {
            get
            {
                return _METoggleButton;
            }
            set
            {
                _METoggleButton = value;
                RaisePropertyChanged("METoggleButton");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
