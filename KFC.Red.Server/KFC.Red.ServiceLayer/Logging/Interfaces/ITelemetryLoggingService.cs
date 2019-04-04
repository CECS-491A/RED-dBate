using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace KFC.Red.ServiceLayer.Logging.Interfaces
{
    public interface ITelemetryLoggingService
    {
        List<BsonDocument> GetListOfCollections();
        IMongoCollection<BsonDocument> GetCollection(string collection);
        Task<List<BsonDocument>> GetAllErrorLogsAsync();
    }
}
