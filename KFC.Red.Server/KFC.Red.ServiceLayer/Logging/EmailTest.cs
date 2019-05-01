using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.Logging
{
    public class EmailTest
    {
        public interface ISmtpClient
        {
            void Send(MailMessage message);
        }

        public class FakeSmtpClient : ISmtpClient
        {
            public bool MailSent { get; set; }
            public FakeSmtpClient()
            {
                MailSent = false;
            }
            public void Send(MailMessage message)
            {
                MailSent = true;
            }
        }

    }
}
