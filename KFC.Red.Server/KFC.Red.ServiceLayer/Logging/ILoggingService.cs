using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using KFC.RED.DataAccessLayer.Models;


namespace KFC.Red.ServiceLayer.Logging
{
    public interface ILoggingService
    {
        List<BsonDocument> GetListOfCollections();
        IMongoCollection<BsonDocument> GetCollection(string collection);
        Task<List<BsonDocument>> GetAllErrorLogsAsync();
    }
}
