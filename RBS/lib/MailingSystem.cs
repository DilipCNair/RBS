using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using RBS.Model;

namespace RBS
{
    public static class MailingSystem
    {
        private static Thread MailingThread;

        public static MailingData Mdata { get; set; }

        public static void InitializeMailingSystem()
        {
            AppResources.SendMail += AppResources_SendMail; // To send mail
            Mdata = new MailingData();
        }

        private static void AppResources_SendMail(object sender, EventArgs e)
        {
            MailingThread = new Thread(MailThisAlert);
            if (AppResources.AlertMailing)
                MailingThread.Start(Mdata);
        }

        ///<summary>
        ///This is a function used to send mail to the required user/administrator
        ///</summary>
        private static void MailThisAlert(object Mdata)
        {
            MailingData mailingData = Mdata as MailingData;
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFrom = "dilipn6@gmail.com";
            string password = "anisatge1";
            string emailTo = null;
            foreach (User user in AppResources.Users)
            {
                if (string.Equals(user.UserName, mailingData.CompromisedUser))
                    emailTo = user.Email_ID;
            }
            string subject = "RBS Alert";
            string message = "Your restrictions has been violated by " + AppResources.CurrentUser.UserName + 
                             " as given below : <br/><br/>";
            string AlertNo = "No : " + mailingData.Alert.No + "<br/><br/>";
            string AlertTime = "Time : " + mailingData.Alert.Time + "<br/><br/>";
            string AlertDate = "Date : " + mailingData.Alert.Date + "<br/><br/>";
            string AlertInformation = "Information : " + mailingData.Alert.Information + "<br/><br/>";
            string ALertActivity = "Activity : " + mailingData.Alert.Activity + "<br/><br/>";
            string AlertType = "Type : " + mailingData.Alert.Type + "<br/><br/>";
            string body = message + AlertNo + AlertTime + AlertDate + AlertInformation + ALertActivity + AlertType;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }

    public class MailingData
    {
        public AlertsModel Alert { get; set; }

        public string CompromisedUser { get; set; }
    }
}
