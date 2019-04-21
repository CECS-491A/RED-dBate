using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.ManagerLayer.SessionManagement;
using System.Net.Mail;
using System.Net;

namespace KFC.Red.ManagerLayer.Logging
{
    public class TelemetryLoggingManager
    {
        public int failedLogs;
        public async Task<List<TelemetryLogDTO>> DisplayTelemetryLogsAsync()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            var collection = ls.GetCollection("CustomLog");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._tlogCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        public void CreateTelemetryLog(string token, string ip, string loc )
        {
            BsonDocument log = new BsonDocument();
            TelemetryLoggingService tlog = new TelemetryLoggingService();
            IMongoCollection<BsonDocument> myDoc = tlog.GetCollection("CustomLog");

            var session = GetLogInfo(token);
            var logouttime = "12/15/1996";//session.DeleteTime;
            var logintime = "12/15/1996"; //session.CreateTime;
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userlogin = new BsonElement("userLogin", logouttime);
                BsonElement userlogout = new BsonElement("userLogout", logintime);
                BsonElement functionalityexecution = new BsonElement("clickevent", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement pagevisit = new BsonElement("pageVisit", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement ipaddress = new BsonElement("IPAddress", ip);
                BsonElement location = new BsonElement("location", loc);

                myDoc.InsertOne(log);

                log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);
                log.Add(location);

                myDoc.InsertOne(log);
            }
            catch (MongoConnectionException e)
            {
                failedLogs++;
                if (failedLogs <= 100)
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
                    failedLogs = 0;
                }
            }
        }

        public Session GetLogInfo(string token)
        {
            SessionManager sm = new SessionManager();
            var session = sm.GetSession(token);
            return session;
        }
    }
}
