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

namespace KFC.Red.ManagerLayer.Logging
{
    public class ErrorLoggingManager
    {
        public int failedLogs;
        public async Task<List<ErrorLogDTO>> DisplayErrorLogsAsync()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._logCollection.Find(new BsonDocument()).ToListAsync();


            return documents;
        }

        public void CreateErrorLog(Exception ex, string token)
        {
            UserManager userman = new UserManager();
            ErrorLoggingService elogService = new ErrorLoggingService();

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogService.GetCollection("CustomLog1");

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

        public void DeleteLog(string id)
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            ls._logCollection.FindOneAndDelete(new BsonDocument { { "_id", new ObjectId(id) } });
        }

        public Session GetLogInfo(string token)
        {
            SessionManager sm = new SessionManager();
            var session = sm.GetSession(token);
            return session;
        }
    }
}
