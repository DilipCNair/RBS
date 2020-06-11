using RBS.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RBS.ViewModel
{
    public class AlertsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AlertsModel> _AlertList;

        public ObservableCollection<AlertsModel> AlertList
        {
            get
            {
                return _AlertList;
            }
            set
            {
                if(_AlertList!=value)
                {
                    _AlertList = value;
                    RaisePropertyChanged("AlertList");
                }
            }
        }

        public AlertsViewModel()
        {
            GlobalResources.AlertGenerated += GlobalResources_AlertGenerated;
        }

        private void GlobalResources_AlertGenerated(object sender, System.EventArgs e)
        {
            AlertList = GlobalAlerts.AllAlerts;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        
    }
}
