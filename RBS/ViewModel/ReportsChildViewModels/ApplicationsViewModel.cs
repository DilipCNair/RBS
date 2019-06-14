using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RBS.Commands;
using RBS.Monitoring_Engine;
using System.Windows.Data;
using System;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class ApplicationsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ApplicationsModel> _ApplicationsList;

        public ObservableCollection<ApplicationsModel> ApplicationsList
        {
            get
            {
                return _ApplicationsList;
            }
            set
            {
                if (_ApplicationsList != value)
                {
                    _ApplicationsList = value;
                    RaisePropertyChanged("ApplicationsList");
                }
            }
        }


        public MyICommand RefreshCommand { get; set; }

        public MyICommand ClearCommand { get; set; }


        public ApplicationsViewModel()
        {
            ApplicationsList = new ObservableCollection<ApplicationsModel>();
            RefreshCommand = new MyICommand(Refresh);
            ClearCommand = new MyICommand(Clear);
        }


        public void Refresh()
        {
            ApplicationsList = new ObservableCollection<ApplicationsModel>(Applications_Monitoring.PrgramHolderList);
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ApplicationsList);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            catch (Exception) { }
            
        }

        public void Clear()
        {
            ApplicationsList = null;
        }


        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
