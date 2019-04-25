using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.Archiving
{
    public class ArchivingService
    {
        public int failedArchives;
        public void CreateArchives()
        {
            try
            {

            }
            catch (Exception e)
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
    }
}
