using System.Windows;
using System.IO;
using System.Management;
using System.Linq;
using RBS.Model;

namespace RBS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public AuthenticationWindow AuthenticationWindow;
        public NotificationWindow NotificationWindow;

        private void Application_RBS_Startup(object sender, StartupEventArgs e)
        {
            AuthenticationWindow = new AuthenticationWindow();
            NotificationWindow = new NotificationWindow();
            AuthenticationWindow.Show();
            GlobalResources.IsNotificationWindowShown = false;
            GlobalResources.AlertMailing = false;
            GlobalResources.IsProcessRestrictionsSet = false;
            GlobalResources.IsFileSytemRestrictionSet = false;
            GlobalResources.IsRestrictionsMonitoringSet = false;
            GlobalResources.InitialiseGlobalResources();
            GlobalAlerts.InitializeGlobalAlerts();
            GlobalException.InitializeGlobalException();
            MailingSystem.InitializeMailingSystem();
            GettingCurrentUserInfo();
            GettingAllUsersInfo();
            GlobalResources.IWantToShowCurrentUser();
        }

        private void GettingCurrentUserInfo()
        {
            GlobalResources.CurrentUser = new User();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            GlobalResources.CurrentUser.UserName = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
            GlobalResources.CurrentUser.UserName = GlobalResources.CurrentUser.UserName.Remove(0, 12);
            if (string.Equals(GlobalResources.CurrentUser.UserName, "Dilip"))
                GlobalResources.CurrentUser.Email_ID = "dilipn6@gmail.com";
            else if (string.Equals(GlobalResources.CurrentUser.UserName, "Sharada Valiveti"))
                GlobalResources.CurrentUser.Email_ID = "sharada.valiveti@nirmauni.ac.in";

        }

        private void GettingAllUsersInfo()
        {
            int id = 1;
            GlobalResources.Users = new System.Collections.ObjectModel.ObservableCollection<User>();
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject user in searcher.Get())
            {
                GlobalResources.Users.Add(new User { UserName = user["Name"].ToString() });
            }
            foreach (User user in GlobalResources.Users)
            {
                user.UserID = id++;
                if (string.Equals(user.UserName, "Dilip"))
                    user.Email_ID = "dilipn6@gmail.com";
                if (string.Equals(user.UserName, "Sharada Valiveti"))
                    user.Email_ID = "sharada.valiveti@nirmauni.ac.in";
            }
        }

        private void Application_RBS_Exit(object sender, ExitEventArgs e)
        {
            File.Delete(GlobalResources.Path + "Keylogger.txt");
            File.Delete(GlobalResources.Path + "Mouselogger.txt");
        }
    }
}
