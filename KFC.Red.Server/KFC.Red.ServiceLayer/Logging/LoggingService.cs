using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging.Interfaces;
using System.Net.Mail;
using System;
using System.Net;

namespace KFC.Red.ServiceLayer.Logging
{
    public class LoggingService<T> : ILoggingService
    {
        /// <summary>
        /// Built in Mongo Client Method from the mongo driver nuget package to connect with the mongo client
        /// </summary>
        public MongoClient Client { get; set; }
        /// <summary>
        /// Built in mongodb method of the mongo database
        /// </summary>
        public IMongoDatabase db { get; set; }
        /// <summary>
        /// Built in mongodb generic mong
        /// </summary>
        public IMongoCollection<T> _logCollection;
        /// <summary>
        /// Private collection method to get and set the collection in mongo
        /// </summary>
        private string Collection { get; set; }

        /// <summary>
        /// Logging Service method to set the connection of the mo
        /// </summary>
        /// <param name="collectionName"></param>
        public LoggingService(string collectionName)
        {
                Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
                db = Client.GetDatabase("Logging");
                _logCollection = db.GetCollection<T>(collectionName);
                Collection = collectionName;
        }

        /// <summary>
        /// Mongo method to retrieve information about the collection into a list
        /// </summary>
        /// <returns></returns>
        public List<BsonDocument> GetListOfCollections()
        {
            var collectionList = db.ListCollections().ToList();
            return collectionList;
        }

        /// <summary>
        /// Mongo method to return a view of the collection.
        /// </summary>
        /// <param name="collectionName">name of the collecction being stored</param>
        /// <returns></returns>
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return db.GetCollection<BsonDocument>(Collection);
        }

        /// <summary>
        /// Retrieving all documenten from the mongodb collection
        /// </summary>
        /// <returns></returns>
        public Task<List<BsonDocument>> GetAllLogsAsync()
        {
            IMongoCollection<BsonDocument> SpeCollection = this.db.GetCollection<BsonDocument>(Collection);
            //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            var documents = SpeCollection.AsQueryable();
            return null;
            //return documents;
        }
        /// <summary>
        /// Mongo method that inserts a document into a collection.
        /// </summary>
        /// <param name="collection">bson document format</param>
        /// <param name="log">the logs getting store into the document</param>
        public void CreateLog(IMongoCollection<BsonDocument> collection, BsonDocument Log)
            {
                collection.InsertOne(Log);
            }

        /// <summary>
        /// Mongo method that counts the number of documents in the collection.
        /// </summary>
        /// <param name="collection">bson document format</param>
        /// <param name="log">the logs getting store into the document</param>
        public void CountLog(IMongoCollection<BsonDocument> collection, BsonDocument log)
        {
                collection.CountDocumentsAsync(log);
        }
        
        /// <summary>
        /// Method to email admin
        /// </summary>
        public void EmailNotification()
        {
            try
            {
                //Email Notification
                //https://stackoverflow.com/questions/4677258/send-email-using-system-net-mail-through-gmail/4677382
                //System.NetMail. Represents and email Message that can be sent using SmtpClient
                MailMessage mail = new MailMessage();

                mail.From = new System.Net.Mail.MailAddress("teamred533@yahoo.com");

                //Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587; 
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false; 
                smtp.Credentials = new NetworkCredential(mail.From.ToString(), "dbate2019!"); 
                smtp.Host = "smtp.mail.yahoo.com";

                //Mail to the recepient address
                mail.To.Add(new MailAddress("deivisleung027@gmail.com"));

                //Mail format
                mail.IsBodyHtml = true;
                mail.Subject = "Test Subject";
                mail.Body = "Test Message";
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public bool FailCountEmail(int failedLogs)
        {
            failedLogs++;
            if (failedLogs <= 100)
            {
                //Email Notification
                //https://stackoverflow.com/questions/4677258/send-email-using-system-net-mail-through-gmail/4677382
                EmailNotification();
                failedLogs = 0;
                
                return true;
            }

            return false;
        }

        public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
