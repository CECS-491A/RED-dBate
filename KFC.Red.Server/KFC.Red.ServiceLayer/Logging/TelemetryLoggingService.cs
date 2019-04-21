using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging.Interfaces;
using System.Net.Mail;
using System.Net;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;

namespace KFC.Red.ServiceLayer.Logging
{
    public class TelemetryLoggingService : ITelemetryLoggingService
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase documents { get; set; }
        public IMongoCollection<TelemetryLogDTO> _tlogCollection;
        public int failedLogs;

        public TelemetryLoggingService()
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            documents = Client.GetDatabase("TelemetryLogging");
            _tlogCollection = documents.GetCollection<TelemetryLogDTO>("CustomLog");
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

        public Task<List<BsonDocument>> GetAllTelemetryLogsAsync()
        {
            IMongoCollection<BsonDocument> SpeCollection = this.documents.GetCollection<BsonDocument>("CustomLog");
            //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            var documents = SpeCollection.AsQueryable();

            return null;
            //return documents;
        }

        public void CreateTelemetryLog(IMongoCollection<BsonDocument> myDoc, BsonDocument telemetryLog)
        {
            myDoc.InsertOne(telemetryLog);
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

        /// <summary>
        /// From mongo shell, this will print client IP:port, along with connection ID:
        /// 
        /// passing true to db.currentOp() shows all connections (including idle). 
        /// The docs have more examples on filtering connections, 
        /// see: db.currentOp reference and currentOp output fileds with descriptions.
        /// </summary>
        /// <param name="myDoc"></param>
        /// <param name="telemetryLog"></param>
        public void IPTelemetryLog(IMongoCollection<BsonDocument> myDoc, BsonDocument telemetryLog)
        {
            //myDoc.currentOp(true).inprog.forEach(function(d){ if (d.client) print(d.client, d.connectionId)})
        }

        /// <summary>
        /// Using geospatial index to find location
        /// </summary>
        /// <param name="myDoc"></param>
        /// <param name="telemetryLog"></param>
        public void LocationTelemetryLog(IMongoCollection<BsonDocument> myDoc, BsonDocument telemetryLog)
        {
            //myDoc.currentOp(true).inprog.forEach(function(d){ if (d.client) print(d.client, d.connectionId)})
        }

        public void CountTelemetryLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
            myDoc.CountDocumentsAsync(log);
        }

        public Task<List<BsonDocument>> GetAllErrorLogsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
