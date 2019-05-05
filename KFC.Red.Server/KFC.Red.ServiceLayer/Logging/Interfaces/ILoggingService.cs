using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace KFC.Red.ServiceLayer.Logging.Interfaces
{
    public interface ILoggingService
    {
        List<BsonDocument> GetListOfCollections();
        IMongoCollection<BsonDocument> GetCollection(string collection);
        Task<List<BsonDocument>> GetAllLogsAsync();
        void CreateLog(IMongoCollection<BsonDocument> myDoc, BsonDocument Log);
        void CountLog(IMongoCollection<BsonDocument> myDoc, BsonDocument log);
        void EmailNotification();
        bool FailCountEmail(int failedLogs);
        string GetIPAddress();
    }
}
