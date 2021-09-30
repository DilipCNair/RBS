using System.Collections.ObjectModel;
using RBS.Model;

namespace RBS
{
    public static class GlobalAlerts
    {
        public static int No { get; set; }

        public static ObservableCollection<AlertsModel> AllAlerts { get; set; }

        public static void InitializeGlobalAlerts()
        {
            AllAlerts = new ObservableCollection<AlertsModel>();
            No = 0;
        }
    }
}
