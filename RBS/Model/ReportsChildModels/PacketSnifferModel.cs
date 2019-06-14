using System.ComponentModel;

namespace RBS.Model.ReportsChildModels
{
    public class PacketSnifferModel : INotifyPropertyChanged
    {
        private long _PacketNo;

        private string _PacketArrivalTime;

        private string _EthernetSourceAddress;

        private string _EthernetDestinationAddress;

        private string _IpSource;

        private string _IpDestination;

        private string _ConnectionType;

        private string _SourcePort;

        private string _DesinationPort;

        private string _PayloadLength;

        public long PacketNo
        {
            get
            { return _PacketNo; }
            set
            {
                if (_PacketNo != value)
                {
                    _PacketNo = value;
                    RaisePropertyChanged("PacketNo");
                }
            }
        }

        public string PacketArrivalTime
        {
            get
            { return _PacketArrivalTime; }
            set
            {
                if (_PacketArrivalTime != value)
                {
                    _PacketArrivalTime = value;
                    RaisePropertyChanged("PacketArrivalTime");
                }
            }
        }

        public string EthernetSourceAddress
        {
            get
            { return _EthernetSourceAddress; }
            set
            {
                if (_EthernetSourceAddress != value)
                {
                    _EthernetSourceAddress = value;
                    RaisePropertyChanged("EthernetSourceAddress");
                }
            }
        }

        public string EthernetDestinationAddress
        {
            get
            { return _EthernetDestinationAddress; }
            set
            {
                if (_EthernetDestinationAddress != value)
                {
                    _EthernetDestinationAddress = value;
                    RaisePropertyChanged("EthernetDestinationAddress");
                }
            }
        }

        public string IpSource
        {
            get
            { return _IpSource; }
            set
            {
                if (_IpSource != value)
                {
                    _IpSource = value;
                    RaisePropertyChanged("IpSource");
                }
            }
        }

        public string IpDestination
        {
            get
            { return _IpDestination; }
            set
            {
                if (_IpDestination != value)
                {
                    _IpDestination = value;
                    RaisePropertyChanged("IpDestination");
                }
            }
        }

        public string ConnectionType
        {
            get
            { return _ConnectionType; }
            set
            {
                if (_ConnectionType != value)
                {
                    _ConnectionType = value;
                    RaisePropertyChanged("ConnectionType");
                }
            }
        }

        public string SourcePort
        {
            get
            { return _SourcePort; }
            set
            {
                if (_SourcePort != value)
                {
                    _SourcePort = value;
                    RaisePropertyChanged("SourcePort");
                }
            }
        }

        public string DesinationPort
        {
            get
            { return _DesinationPort; }
            set
            {
                if (_DesinationPort != value)
                {
                    _DesinationPort = value;
                    RaisePropertyChanged("DesinationPort");
                }
            }
        }

        public string PayloadLength
        {
            get
            { return _PayloadLength; }
            set
            {
                if (_PayloadLength != value)
                {
                    _PayloadLength = value;
                    RaisePropertyChanged("PayloadLength");
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
