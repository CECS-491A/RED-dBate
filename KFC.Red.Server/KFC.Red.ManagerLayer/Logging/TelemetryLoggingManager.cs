using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.Logging
{
    public class TelemetryLoggingManager
    {
        public async Task<List<TelemetryLogDTO>> DisplayTelemetryLogsAsync()
        {
            TelemetryLogs e = new TelemetryLogs();
            TelemetryLoggingService ls = new TelemetryLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._tlogCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }
    }
}
