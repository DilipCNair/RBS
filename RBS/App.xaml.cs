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

        private void Application_RBS_Startup(object sender, StartupEventArgs e)
        {
            _ = new AuthenticationWindow();
            _ = new NotificationWindow();
            AppResources.IsNotificationWindowShown = false;
            AppResources.AlertMailing = false;
            AppResources.IsProcessRestrictionsSet = false;
            AppResources.IsFileSytemRestrictionSet = false;
            AppResources.IsRestrictionsMonitoringSet = false;
            AppResources.InitialiseAppResources();
            GlobalAlerts.InitializeGlobalAlerts();
            GlobalException.InitializeGlobalException();
            MailingSystem.InitializeMailingSystem();
            GettingCurrentUserInfo();
            GettingAllUsersInfo();
            AppResources.ShowCurrentUser();
        }

        private void GettingCurrentUserInfo()
        {
            AppResources.CurrentUser = new User();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            AppResources.CurrentUser.UserName = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
            AppResources.CurrentUser.UserName = AppResources.CurrentUser.UserName.Remove(0, 12);
            if (string.Equals(AppResources.CurrentUser.UserName, "Dilip"))
                AppResources.CurrentUser.Email_ID = "dilipn6@gmail.com";
            else if (string.Equals(AppResources.CurrentUser.UserName, "Sharada Valiveti"))
                AppResources.CurrentUser.Email_ID = "sharada.valiveti@nirmauni.ac.in";

        }

        private void GettingAllUsersInfo()
        {
            int id = 1;
            AppResources.Users = new System.Collections.ObjectModel.ObservableCollection<User>();
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject user in searcher.Get())
            {
                AppResources.Users.Add(new User { UserName = user["Name"].ToString() });
            }
            foreach (User user in AppResources.Users)
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
            File.Delete(AppResources.Path + "Keylogger.txt");
            File.Delete(AppResources.Path + "Mouselogger.txt");
        }
    }
}
