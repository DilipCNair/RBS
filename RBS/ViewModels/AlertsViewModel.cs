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
            AppResources.AlertGenerated += AppResources_AlertGenerated;
        }

        private void AppResources_AlertGenerated(object sender, System.EventArgs e)
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
