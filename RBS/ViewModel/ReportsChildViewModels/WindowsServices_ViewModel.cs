using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RBS.Commands;
using RBS.Monitoring_Engine;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class WindowsServices_ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<WindowsServices_Model> _WinServList;

        public ObservableCollection<WindowsServices_Model> WinServList
        {
            get
            {
                return _WinServList;
            }
            set
            {
                if (_WinServList != value)
                {
                    _WinServList = value;
                    RaisePropertyChanged("WinServList");
                }
            }
        }

        private ObservableCollection<WindowsServices_Model> _WinDriverList;

        public ObservableCollection<WindowsServices_Model> WinDriverList
        {
            get
            {
                return _WinDriverList;
            }
            set
            {
                if (_WinDriverList != value)
                {
                    _WinDriverList = value;
                    RaisePropertyChanged("WinDriverList");
                }
            }
        }

        public MyICommand RefreshCommand { get; set; }

        public MyICommand ClearCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public WindowsServices_ViewModel()
        {
            WinServList = new ObservableCollection<WindowsServices_Model>();
            WinDriverList = new ObservableCollection<WindowsServices_Model>();
            RefreshCommand = new MyICommand(Refresh);
            ClearCommand = new MyICommand(Clear);
        }

        public void Refresh()
        {
            WinServList = new ObservableCollection<WindowsServices_Model>(WindowsServices.BGWData.WinServHolder);
            WinDriverList = new ObservableCollection<WindowsServices_Model>(WindowsServices.BGWData.WinDriverHolder);
        }

        public void Clear()
        {
            WinServList.Clear();
            WinDriverList.Clear();
        }

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
