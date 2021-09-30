using RBS.Model;
using System.Collections.ObjectModel;

namespace RBS
{
    public static class GlobalException
    {
        public static double No { get; set; }

        public static ObservableCollection<ExceptionModel> AllExceptions { get; set; }

        public static void InitializeGlobalException()
        {
            No = 0;
            AllExceptions = new ObservableCollection<ExceptionModel>();
        }

        public static void LogTheException()
        {
            //using (StreamWriter SW = File.AppendText(GlobalResources.Path + "Exception.log"))
            //{
            //    foreach (ExceptionModel _Exception in AllExceptions)
            //    {
            //        string message = _Exception.Message;
            //        string no = _Exception.No.ToString();
            //        string date = _Exception.Date;
            //        string time = _Exception.Time;
            //        SW.WriteLine(no + " : " + date + " : " + time + " : " + message);
            //    }
            //}
        }
    }
}
