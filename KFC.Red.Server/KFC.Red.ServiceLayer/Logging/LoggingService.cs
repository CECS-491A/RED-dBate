using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging.Interfaces;
using System.Net.Mail;
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
        public IMongoDatabase documents { get; set; }
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
                documents = Client.GetDatabase("Logging");
                _logCollection = documents.GetCollection<T>(collectionName);
                Collection = collectionName;
        }

        /// <summary>
        /// Mongo method to retrieve information about the collection into a list
        /// </summary>
        /// <returns></returns>
        public List<BsonDocument> GetListOfCollections()
        {
            var collectionList = documents.ListCollections().ToList();
            return collectionList;
        }

        /// <summary>
        /// Mongo method to return a view of the collection.
        /// </summary>
        /// <param name="collectionName">name of the collecction being stored</param>
        /// <returns></returns>
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return documents.GetCollection<BsonDocument>(Collection);
        }

        /// <summary>
        /// Retrieving all documenten from the mongodb collection
        /// </summary>
        /// <returns></returns>
        public Task<List<BsonDocument>> GetAllLogsAsync()
        {
            IMongoCollection<BsonDocument> SpeCollection = this.documents.GetCollection<BsonDocument>(Collection);
            //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            var documents = SpeCollection.AsQueryable();
            return null;
            //return documents;
        }
        /// <summary>
        /// Mongo method that inserts a document into a collection.
        /// </summary>
        /// <param name="myDoc">bson document format</param>
        /// <param name="log">the logs getting store into the document</param>
        public void CreateLog(IMongoCollection<BsonDocument> myDoc, BsonDocument Log)
            {
                myDoc.InsertOne(Log);
            }

        /// <summary>
        /// Mongo method that counts the number of documents in the collection.
        /// </summary>
        /// <param name="myDoc">bson document format</param>
        /// <param name="log">the logs getting store into the document</param>
        public void CountLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
                myDoc.CountDocumentsAsync(log);
        }
        
        /// <summary>
        /// Method to email admin
        /// </summary>
        public void EmailNotification()
        {
            //Email Notification
            //https://stackoverflow.com/questions/4677258/send-email-using-system-net-mail-through-gmail/4677382
            //System.NetMail. Represents and email Message that can be sent using SmtpClient
            MailMessage mail = new MailMessage();

            mail.From = new System.Net.Mail.MailAddress("teamred533@yahoo.com");

            //Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; //Gets the port used for SMTP transactions.
            smtp.EnableSsl = true; //Encrypt the connection using SSl.
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //Specifies how outgoing email messages will be handled.
            smtp.UseDefaultCredentials = false; //Gets or sets a Boolean value that controls whether the DefaultCredentials are sent with requests
            smtp.Credentials = new NetworkCredential(mail.From.ToString(), "dbate2019!"); //Gets the credentials used to authenticate the sender.
            smtp.Host = "smtp.mail.yahoo.com"; //Gets the name or IP address of the host.

            //Mail to the recepient address
            mail.To.Add(new MailAddress("deivisleung027@gmail.com"));

            //Mail format
            mail.IsBodyHtml = true;
            mail.Subject = "Test Subject";
            mail.Body = "Test Message";
            smtp.Send(mail); //Send mail to an Smtp Server

        }
    }
}
