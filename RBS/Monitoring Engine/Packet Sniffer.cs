using RBS.Model.ReportsChildModels;
using SharpPcap;
using PacketDotNet;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RBS.Monitoring_Engine
{
    public static class Packet_Sniffer
    {

        public static Packet_Sniffer_Resources PacketSnifferResourcesObject { get; set; }

        public static BackgroundWorker Worker { get; set; }


        public static void InitialisePacket_Sniffer()
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            PacketSnifferResourcesObject = new Packet_Sniffer_Resources();
            GlobalResources.PacketSnifferIsOn += GlobalResources_PacketSnifferIsOn;
            GlobalResources.PacketSnifferIsOff += GlobalResources_PacketSnifferIsOff;
        }

        private static void GlobalResources_PacketSnifferIsOn(object sender, EventArgs e)
        {
            Worker.RunWorkerAsync(PacketSnifferResourcesObject);
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string InterfaceSelectedByUser = null;

            if (GlobalResources.SelectedNetworkInterface == 0)
                InterfaceSelectedByUser = "802.3 - Ethernet";
            else
                InterfaceSelectedByUser = "802.11ac - Wifi";

            Packet_Sniffer_Resources Packet_Capture_Resources_OfWorker = e.Argument as Packet_Sniffer_Resources;
            
            CaptureDeviceList Devices = CaptureDeviceList.Instance;
            foreach (ICaptureDevice Dev in Devices)
            {
                if (string.Equals(Dev.Name.ToString(), Packet_Capture_Resources_OfWorker.Ethernet))
                {
                    Packet_Capture_Resources_OfWorker.I_Ethernet = Dev;
                }
                if (string.Equals(Dev.Name.ToString(), Packet_Capture_Resources_OfWorker.WiFi))
                {
                    Packet_Capture_Resources_OfWorker.I_WiFi = Dev;
                }
            }
            #region Capture Method for 802.3-Ethernet
            if (string.Equals(InterfaceSelectedByUser, Packet_Capture_Resources_OfWorker.FriendlyNameOfEthernet))
            {
                RawCapture Raw_Packet = null;
                Packet packet = null;
                string ConnectionType;
                Packet_Capture_Resources_OfWorker.PacketCount = 0;
                Packet_Capture_Resources_OfWorker.I_Ethernet.Open(DeviceMode.Promiscuous);
                while ((Raw_Packet = Packet_Capture_Resources_OfWorker.I_Ethernet.GetNextPacket()) != null)
                {
                    Packet_Capture_Resources_OfWorker.PacketCaptureCount++;
                    Packet_Capture_Resources_OfWorker.PacketCount += 1;
                    if (Worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        Packet_Capture_Resources_OfWorker.I_Ethernet.Close();
                        return;
                    }
                    DateTime PacketArrivalTime = Raw_Packet.Timeval.Date;
                    int PacketLength = Raw_Packet.Data.Length;
                    packet = Packet.ParsePacket(Raw_Packet.LinkLayerType, Raw_Packet.Data);

                    EthernetPacket ethernet_packet = null;
                    IpPacket ip_packet = null;
                    ICMPv4Packet icmpv4_packet = null;
                    ICMPv6Packet icmpv6_packet = null;
                    TcpPacket tcp_packet = null;
                    UdpPacket udp_packet = null;
                    try
                    {
                        ethernet_packet = (EthernetPacket)packet.Extract(typeof(EthernetPacket));
                        ip_packet = (IpPacket)packet.Extract(typeof(IpPacket));
                        icmpv4_packet = (ICMPv4Packet)packet.Extract(typeof(ICMPv4Packet));
                        icmpv6_packet = (ICMPv6Packet)packet.Extract(typeof(ICMPv6Packet));
                        tcp_packet = (TcpPacket)packet.Extract(typeof(TcpPacket));
                        udp_packet = (UdpPacket)packet.Extract(typeof(UdpPacket));
                    }
                    catch (Exception)
                    { }
                    #region For ICMP Packets
                    if (icmpv4_packet != null)
                    {
                        ConnectionType = "ICMP-v4";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                            
                        }
                        catch (Exception)
                        {
                        }
                    }

                    else if (icmpv6_packet != null)
                    {
                        ConnectionType = "ICMP-v6";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                           
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For TCP Packets
                    else if (tcp_packet != null)
                    {
                        ConnectionType = "TCP";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = tcp_packet.SourcePort.ToString(),
                                        DesinationPort = tcp_packet.DestinationPort.ToString(),
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                            
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For UDP Packets
                    else if (udp_packet != null)
                    {
                        ConnectionType = "UDP";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = udp_packet.SourcePort.ToString(),
                                        DesinationPort = udp_packet.DestinationPort.ToString(),
                                        PayloadLength = udp_packet.Length.ToString() + " bytes"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                            
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For Other Packets
                    else
                    {
                        ConnectionType = "Others";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = udp_packet.Length.ToString() + " bytes"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                }
            }
            #endregion
            #region Capture Method for 8011ac-WiFi
            else if (string.Equals(InterfaceSelectedByUser, Packet_Capture_Resources_OfWorker.FriendlyNameOfWiFi))
            {
                RawCapture Raw_Packet = null;
                Packet packet = null;
                string ConnectionType;
                Packet_Capture_Resources_OfWorker.PacketCount = 0;
                Packet_Capture_Resources_OfWorker.I_Ethernet.Open(DeviceMode.Promiscuous);
                while ((Raw_Packet = Packet_Capture_Resources_OfWorker.I_Ethernet.GetNextPacket()) != null)
                {
                    Packet_Capture_Resources_OfWorker.PacketCaptureCount++;
                    Packet_Capture_Resources_OfWorker.PacketCount += 1;
                    if (Worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        Packet_Capture_Resources_OfWorker.I_Ethernet.Close();
                        return;
                    }
                    DateTime PacketArrivalTime = Raw_Packet.Timeval.Date;
                    int PacketLength = Raw_Packet.Data.Length;
                    packet = Packet.ParsePacket(Raw_Packet.LinkLayerType, Raw_Packet.Data);

                    EthernetPacket ethernet_packet = null;
                    IpPacket ip_packet = null;
                    ICMPv4Packet icmpv4_packet = null;
                    ICMPv6Packet icmpv6_packet = null;
                    TcpPacket tcp_packet = null;
                    UdpPacket udp_packet = null;
                    try
                    {
                        ethernet_packet = (EthernetPacket)packet.Extract(typeof(EthernetPacket));
                        ip_packet = (IpPacket)packet.Extract(typeof(IpPacket));
                        icmpv4_packet = (ICMPv4Packet)packet.Extract(typeof(ICMPv4Packet));
                        icmpv6_packet = (ICMPv6Packet)packet.Extract(typeof(ICMPv6Packet));
                        tcp_packet = (TcpPacket)packet.Extract(typeof(TcpPacket));
                        udp_packet = (UdpPacket)packet.Extract(typeof(UdpPacket));
                    }
                    catch (Exception)
                    { }
                    #region For ICMP Packets
                    if (icmpv4_packet != null)
                    {
                        ConnectionType = "ICMP-v4";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    else if (icmpv6_packet != null)
                    {
                        ConnectionType = "ICMP-v6";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For TCP Packets
                    else if (tcp_packet != null)
                    {
                        ConnectionType = "TCP";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = tcp_packet.SourcePort.ToString(),
                                        DesinationPort = tcp_packet.DestinationPort.ToString(),
                                        PayloadLength = "Unknown"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For UDP Packets
                    else if (udp_packet != null)
                    {
                        ConnectionType = "UDP";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = udp_packet.SourcePort.ToString(),
                                        DesinationPort = udp_packet.DestinationPort.ToString(),
                                        PayloadLength = udp_packet.Length.ToString() + " bytes"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                    #region For Other Packets
                    else
                    {
                        ConnectionType = "Others";
                        try
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                try
                                {
                                    Packet_Capture_Resources_OfWorker.Packet_HolderList.Add(new PacketSnifferModel()
                                    {
                                        PacketNo = Packet_Capture_Resources_OfWorker.PacketCount,
                                        PacketArrivalTime = PacketArrivalTime.ToString(),
                                        EthernetSourceAddress = ethernet_packet.SourceHwAddress.ToString(),
                                        EthernetDestinationAddress = ethernet_packet.DestinationHwAddress.ToString(),
                                        IpSource = ip_packet.SourceAddress.ToString(),
                                        IpDestination = ip_packet.DestinationAddress.ToString(),
                                        ConnectionType = ConnectionType,
                                        SourcePort = "Unknown",
                                        DesinationPort = "Unknown",
                                        PayloadLength = udp_packet.Length.ToString() + " bytes"

                                    });
                                }
                                catch (NullReferenceException)
                                { }
                            });
                            Packet_Capture_Resources_OfWorker.packets.Add(packet);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    #endregion
                }
            }
            #endregion
            e.Result = Packet_Capture_Resources_OfWorker.Packet_HolderList;
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Packet_Sniffer_Resources PacketSnifferResourcesObject = e.Result as Packet_Sniffer_Resources;
                
            }
            catch (Exception)
            { }
        }

        private static void GlobalResources_PacketSnifferIsOff(object sender, EventArgs e)
        {
            Worker.CancelAsync();
        }
    }

    public class Packet_Sniffer_Resources
    {
        public long PacketCount { get; set; }
        public ICaptureDevice I_WiFi { get; set; }
        public ICaptureDevice I_Ethernet { get; set; }
        public long PacketCaptureCount { get; set; }
        public string FriendlyNameOfWiFi { get; set; }
        public string FriendlyNameOfEthernet { get; set; }
        public ObservableCollection<Packet> packets { get; set; }
        public string WiFi { get; set; }
        public string Ethernet { get; set; }

        public ObservableCollection<PacketSnifferModel> Packet_HolderList { get; set; }

        public Packet_Sniffer_Resources()
        {
           PacketCount = 0;
           PacketCaptureCount = 0;
           FriendlyNameOfWiFi = "802.11ac - Wifi";
           FriendlyNameOfEthernet = "802.3 - Ethernet";
           packets = new ObservableCollection<Packet>();
           WiFi = @"rpcap://\Device\NPF_{84D36356-D143-4B7E-B0EB-B1EE67FEA65E}";
           Ethernet = @"rpcap://\Device\NPF_{1B8EE98D-29DD-472E-BD4C-EA1FD2C5AFB2}";
           Packet_HolderList = new ObservableCollection<PacketSnifferModel>();
        }

    }
}
