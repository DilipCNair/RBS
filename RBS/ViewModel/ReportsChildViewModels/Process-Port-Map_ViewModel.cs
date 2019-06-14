using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RBS.Monitoring_Engine;
using RBS.Commands;
using System.Windows.Data;
using System;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class Process_Port_Map_ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Process_Port_Map_Model> _PPMList;

        public  ObservableCollection<Process_Port_Map_Model> PPMList
        {
            get { return _PPMList; }
            set
            {
                if(_PPMList!=value)
                {
                    _PPMList = value;
                    RaisePropertyChanged("PPMList");
                }
            }
        }

        public MyICommand RefreshCommand { get; set; }

        public MyICommand ClearCommand { get; set; }

        public Process_Port_Map_ViewModel()
        {
            PPMList = new ObservableCollection<Process_Port_Map_Model>();
            RefreshCommand = new MyICommand(Refresh);
            ClearCommand = new MyICommand(Clear);
        }

        public void Refresh()
        {
            PPMList = new ObservableCollection<Process_Port_Map_Model>(PPM.PPMListHolder);           
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PPMList);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            catch (Exception) { }
           
        }

        public void Clear()
        {
            PPMList.Clear();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
