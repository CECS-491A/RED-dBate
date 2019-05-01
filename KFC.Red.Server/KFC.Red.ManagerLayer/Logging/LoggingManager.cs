using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KFC.Red.ManagerLayer.SessionManagement;
using System.Net.Mail;
using System.Net;
using KFC.Red.ManagerLayer.UserManagement;

namespace KFC.Red.ManagerLayer.Logging
{
    public class LoggingManager<T>
    {
        public int failedLogs;
        public async Task<List<T>> DisplayLogsAsync(string collectionName)
        {
            LoggingService<T> logService = new LoggingService<T>(collectionName);
            var collection = logService.GetCollection(collectionName);
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await logService._logCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        public void CreateErrorLog(Exception ex, string token)
        {
            UserManager userman = new UserManager();
            LoggingService<ErrorLogDTO> elogger = new LoggingService<ErrorLogDTO>("ErrorLogs");

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogger.GetCollection("ErrorLogs");

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
            catch (MongoConnectionException)
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

        public void CreateErrorLog()
        {
            UserManager userman = new UserManager();
            LoggingService<ErrorLogDTO> elogger = new LoggingService<ErrorLogDTO>("ErrorLogs");

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogger.GetCollection("ErrorLogs");

            //var session = GetLogInfo(token);
            //var user = userman.GetUser(session.UId);

            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement error = new BsonElement("error", "fail to join session");
                BsonElement target = new BsonElement("target", "chat");
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "leung027@gmail.com");
                BsonElement userRequest = new BsonElement("userRequest", "join session");
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                myDoc.InsertOne(log);
            }
            catch (MongoConnectionException)
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
            LoggingService<TelemetryLogDTO> tlogger = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> myDoc = tlogger.GetCollection("TelemetryLogs");

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

                myDoc.InsertOne(log);

                log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);

                myDoc.InsertOne(log);
            }
            catch (MongoConnectionException)
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

        public void CreateTelemetryLog()
        {
            BsonDocument log = new BsonDocument();
            LoggingService<TelemetryLogDTO> tlog = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> myDoc = tlog.GetCollection("TelemetryLogs");

            //var session = GetLogInfo();
            var logouttime = "12/15/1996";//session.DeleteTime;
            var logintime = "12/15/1996"; //session.CreateTime;
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userlogin = new BsonElement("userLogin", logouttime);
                BsonElement userlogout = new BsonElement("userLogout", logintime);
                BsonElement functionalityexecution = new BsonElement("clickevent", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement pagevisit = new BsonElement("pageVisit", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement ipaddress = new BsonElement("IPAddress", "255.255.255.0");

                log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);

                myDoc.InsertOne(log);
            }
            catch (MongoConnectionException)
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

        public void DeleteLog(string id,string collectionName)
        {
            LoggingService<T> loggerService = new LoggingService<T>(collectionName);
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
