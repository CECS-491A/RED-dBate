using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging.Interfaces;

namespace KFC.Red.ServiceLayer.Logging
{
    public class LoggingService<T> : ILoggingService
        {
            public MongoClient Client { get; set; }
            public IMongoDatabase documents { get; set; }
            public IMongoCollection<T> _logCollection;
            public int failedLogs;
            private string Collection { get; set; }

            public LoggingService(string collectionName)
            {
                Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
                documents = Client.GetDatabase("Logging");
                _logCollection = documents.GetCollection<T>(collectionName);
                Collection = collectionName;
            }

            public List<BsonDocument> GetListOfCollections()
            {
                var collectionList = documents.ListCollections().ToList();
                return collectionList;
            }

            public IMongoCollection<BsonDocument> GetCollection(string collectionName)
            {
                return documents.GetCollection<BsonDocument>(Collection);
            }

            public Task<List<BsonDocument>> GetAllLogsAsync()
            {
                IMongoCollection<BsonDocument> SpeCollection = this.documents.GetCollection<BsonDocument>(Collection);
                //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
                var documents = SpeCollection.AsQueryable();

                return null;
                //return documents;
            }

            public void CreateLog(IMongoCollection<BsonDocument> myDoc, BsonDocument Log)
            {
                myDoc.InsertOne(Log);
            }
        }
}
