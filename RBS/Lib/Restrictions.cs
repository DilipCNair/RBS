using System.Collections.ObjectModel;
using RBS.Model.ReportsChildModels;

namespace RBS
{
    public static class Restrictions
    {
        public static ObservableCollection<FSC_Restrictions> AllFSC_Restritions { get; set; }

        public static ObservableCollection<ProcessReportsModel> AllProcess_Restrictions { get; set; }

        public static int ID { get; set; }

        public static void InitialiseRestrictions()
        {
            ID = 0;
            AllFSC_Restritions = new ObservableCollection<FSC_Restrictions>();
            AllProcess_Restrictions = new ObservableCollection<ProcessReportsModel>();            
        }
    }

    public class FSC_Restrictions
    {
        public int ID { get; set; }

        public string File { get; set; }

        public string Directory { get; set; }

        public string FileORDty { get; set; }

    }

}

