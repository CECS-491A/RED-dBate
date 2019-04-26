using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging.Interfaces;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.ServiceLayer.Logging
{
    public class LoggingService : ILoggingService
        {
            public MongoClient Client { get; set; }
            public IMongoDatabase documents { get; set; }
            public IMongoCollection<LogDTO> _logCollection;
            public int failedLogs;

            public LoggingService()
            {
                Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
                documents = Client.GetDatabase("Logging");
                _logCollection = documents.GetCollection<LogDTO>("CustomLog");
            }

            public List<BsonDocument> GetListOfCollections()
            {
                var collectionList = documents.ListCollections().ToList();
                return collectionList;
            }

            public IMongoCollection<BsonDocument> GetCollection(string collection)
            {
                collection = "CustomLog";
                return documents.GetCollection<BsonDocument>(collection);
            }

            public Task<List<BsonDocument>> GetAllLogsAsync()
            {
                IMongoCollection<BsonDocument> SpeCollection = this.documents.GetCollection<BsonDocument>("CustomLog");
                //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
                var documents = SpeCollection.AsQueryable();

                return null;
                //return documents;
            }

            public void CreateLog(IMongoCollection<BsonDocument> myDoc, BsonDocument Log)
            {
                myDoc.InsertOne(Log);
            }

            /*
            public void CreateTelemetryLog(Exception ex)
            {
                BsonDocument log = new BsonDocument();
                IMongoCollection<BsonDocument> myDoc = GetCollection("CustomLog");

                try
                {
                    BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    BsonElement userlogin = new BsonElement("userLogin", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    BsonElement userlogout = new BsonElement("userLogout", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    BsonElement functionalityexecution = new BsonElement("functionalityExecution", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    BsonElement pagevisit = new BsonElement("pageVisit", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    BsonElement ipaddress = new BsonElement("IPAddress", "some ip");
                    BsonElement location = new BsonElement("location", "some location");

                    myDoc.InsertOne(log);

                    log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);
                    log.Add(location); 

                    myDoc.InsertOne(log);
                }
                catch (MongoConnectionException e)
                {
                    failedLogs++;
                    if(failedLogs <= 100)
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
            }*/

            public void CountLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
            {
                myDoc.CountDocumentsAsync(log);
            }
        }
}
