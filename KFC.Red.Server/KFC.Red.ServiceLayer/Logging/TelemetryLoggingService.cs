using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.RED.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.Logging.Interfaces;

namespace KFC.Red.ServiceLayer.Logging
{
    public class TelemetryLoggingService : ITelemetryLoggingService
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase documents { get; set; }

        public TelemetryLoggingService()
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            documents = Client.GetDatabase("TelemetryLogging");
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

        public void CreateTelemetryLog()
        {
            TelemetryLogs telemetryLog = new TelemetryLogs();
            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = GetCollection("CustomLog");

            try
            {
                int zero = 0;
                int result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {
                BsonElement date = new BsonElement("date", telemetryLog.Date);
                BsonElement error = new BsonElement("error", ex.Message.ToString());
                BsonElement target = new BsonElement("target", ex.TargetSite.ToString());
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "Jane Doe");
                BsonElement userRequest = new BsonElement("userRequest", "click event");
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);
            }
            myDoc.InsertOne(log);
        }

        public void CountTelemetryLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
            myDoc.CountDocumentsAsync(log);
        }

    }
}
