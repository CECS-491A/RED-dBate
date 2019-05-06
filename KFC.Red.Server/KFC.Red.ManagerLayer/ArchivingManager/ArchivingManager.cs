using KFC.Red.ServiceLayer.Archiving;
using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace KFC.Red.ManagerLayer.ArchivingManager
{
    public class ArchivingManager
    {
        private string archivePath;
        private ArchivingService archiveLogs = new ArchivingService();

        public int failedArchives;

        public void CreateArchives()
        {
            try
            {
                string g = "";
                //
            }
            catch (Exception)
            {
                failedArchives++;
                if (failedArchives < 3)
                {
                    //Email Notification
                    //https://stackoverflow.com/questions/4677258/send-email-using-system-net-mail-through-gmail/4677382
                    MailMessage mail = new MailMessage();

                    mail.From = new System.Net.Mail.MailAddress("teamred533@yahoo.com");

                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mail.From.ToString(), "dbate2019!");
                    smtp.Host = "smtp.mail.yahoo.com";

                    //Replace with admin address
                    mail.To.Add(new MailAddress("caytkid1@gmail.com"));

                    mail.IsBodyHtml = true;
                    mail.Subject = "Test Subject";
                    mail.Body = "Test Message";
                    smtp.Send(mail);

                    //Reset counter
                    failedArchives = 0;
                }
            }
        }
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
