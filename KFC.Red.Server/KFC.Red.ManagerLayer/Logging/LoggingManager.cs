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
using KFC.Red.ManagerLayer.UserManagement;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.ManagerLayer.Logging
{
    public class LoggingManager
    {
        public int failedLogs;
        public async Task<List<LogDTO>> DisplayLogsAsync()
        {
            LoggingService logService = new LoggingService();
            var collection = logService.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await logService._logCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        public void CreateErrorLog(Exception ex, string token)
        {
            UserManager userman = new UserManager();
            ErrorLoggingService logService = new ErrorLoggingService();

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = logService.GetCollection("CustomLog1");

            var session = GetLogInfo(token);
            var user = userman.GetUser(session.UId);

            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement error = new BsonElement("error", ex.Message.ToString());
                BsonElement target = new BsonElement("target", ex.TargetSite.ToString());
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", user.Email);
                BsonElement userRequest = new BsonElement("userRequest", ex.Source.ToString());
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                myDoc.InsertOne(log);
            }
            catch (MongoConnectionException e)
            {
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

        public void CreateTelemetryLog(string token, string ip, string loc)
        {
            BsonDocument log = new BsonDocument();
            TelemetryLoggingService logger = new TelemetryLoggingService();
            IMongoCollection<BsonDocument> myDoc = logger.GetCollection("CustomLog");

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

        public void DeleteLog(string id)
        {
            LoggingService loggerService = new LoggingService();
            loggerService._logCollection.FindOneAndDelete(new BsonDocument { { "_id", new ObjectId(id) } });
        }

        public Session GetLogInfo(string token)
        {
            SessionManager sessman = new SessionManager();
            var session = sessman.GetSession(token);
            return session;
        }
    }
}
