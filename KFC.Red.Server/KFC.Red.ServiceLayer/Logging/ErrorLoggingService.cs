using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.RED.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.Logging.Interfaces;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.ServiceLayer.Logging
{
    public class ErrorLoggingService : IErrorLoggingService
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase database { get; set; }
        public IMongoCollection<ErrorLogDTO> _logCollection;

        public ErrorLoggingService()
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            database = Client.GetDatabase("Logging");
            _logCollection = database.GetCollection<ErrorLogDTO>("CustomLog1");
        }

        public List<BsonDocument> GetListOfCollections()
        {
            var collectionList = database.ListCollections().ToList();
            return collectionList;
        }

        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return database.GetCollection<BsonDocument>(collection);
        }

        public List<IMongoCollection<BsonDocument>> GetDocuments()
        {
            return null;
        }

        public Task<List<BsonDocument>> GetAllErrorLogsAsync()
        {
            IMongoCollection<BsonDocument> SpeCollection = this.database.GetCollection<BsonDocument>("CustomLog");
            //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            var documents = SpeCollection.AsQueryable();

            return null;
            //return documents;
        }

        public Task<List<BsonDocument>> GetAllLogsAsync()
        {
            IMongoCollection<BsonDocument> SpeCollection = this.database.GetCollection<BsonDocument>("CustomLog");
            //var documents = await SpeCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            var documents = SpeCollection.AsQueryable();

            return null;
            //return documents;
        }

        /*
        public void CreateLog(IMongoCollection<BsonDocument> myDoc, ErrorLogs errorLog)
        {
            //BsonElement employeename = new BsonElement("employeename","Tapas Pal");
            BsonElement date = new BsonElement("date", errorLog.Date);
            BsonElement error = new BsonElement("error", errorLog.Error);
            BsonElement target = new BsonElement("target", errorLog.LineofCode);
            BsonElement currentLoggedUser = new BsonElement("loggedInUser", errorLog.CurrentLoggedInUser);
            BsonElement userRequest = new BsonElement("userRequest", errorLog.CurrentLoggedInUser);

            BsonDocument log = new BsonDocument();
            log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);
            myDoc.InsertOne(log);
            //return myDoc;
        }
        */

        public void CreateErrorLog(IMongoCollection<BsonDocument> myDoc, BsonDocument errorLog)
        {
            myDoc.InsertOne(errorLog);
        }

        public void CreateErrorLog()
        {
            ErrorLogs errorLog = new ErrorLogs();
            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = GetCollection("CustomLog1");

            try
            {
                int zero = 0;
                int result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {
                BsonElement date = new BsonElement("date", errorLog.Date);
                BsonElement error = new BsonElement("error", ex.Message.ToString());
                BsonElement target = new BsonElement("target", ex.TargetSite.ToString());
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "Jane Doe");
                BsonElement userRequest = new BsonElement("userRequest", "click event");
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);
            }

            myDoc.InsertOne(log);
        }

        public void DeleteErrorLog(BsonDocument log)
        {
            //myDoc.FindOneAndDelete(log);
            _logCollection.FindOneAndDelete(log);
        }

        public void DeleteAllErrorLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
            myDoc.DeleteMany(log);
        }

        public void CountErrorLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log)
        {
            myDoc.CountDocumentsAsync(log);
        }

    }
}
