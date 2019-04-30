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
        /// <param name="collectionName"></param>
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
        /// <param name="myDoc"></param>
        /// <param name="Log"></param>
        public void CreateLog(IMongoCollection<BsonDocument> myDoc, BsonDocument Log)
            {
                myDoc.InsertOne(Log);
            }

        /// <summary>
        /// Mongo method that counts the number of documents in the collection.
        /// </summary>
        /// <param name="myDoc"></param>
        /// <param name="log"></param>
        public void CountLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
                myDoc.CountDocumentsAsync(log);
        }
    }
}
