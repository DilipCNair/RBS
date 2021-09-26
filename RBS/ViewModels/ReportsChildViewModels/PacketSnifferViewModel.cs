using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBS.Monitoring_Engine;
using RBS.Commands;
using RBS.Model.ReportsChildModels;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class PacketSnifferViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PacketSnifferModel> _PacketsCaptured;

        public ObservableCollection<PacketSnifferModel> PacketsCaptured
        {
            get
            {
                return _PacketsCaptured;
            }
            set
            {
                if(_PacketsCaptured != value)
                {
                    _PacketsCaptured = value;
                    RaisePropertyChanged("PacketsCaptured");
                }
            }
        }

        public MyICommand LoadCommand { get; private set; }

        public MyICommand RefreshCommand { get; private set; }

        public MyICommand ClearCommand { get; private set; }

        public PacketSnifferViewModel()
        {
            LoadCommand = new MyICommand(Load);
            RefreshCommand = new MyICommand(Refresh);
            ClearCommand = new MyICommand(Clear);
            PacketsCaptured = new ObservableCollection<PacketSnifferModel>();
        }

        public void Load()
        {
            PacketsCaptured = Packet_Sniffer.PacketSnifferResourcesObject.Packet_HolderList;
        }

        public void Refresh()
        {
            PacketsCaptured = Packet_Sniffer.PacketSnifferResourcesObject.Packet_HolderList;
        }

        public void Clear()
        {
            PacketsCaptured = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
