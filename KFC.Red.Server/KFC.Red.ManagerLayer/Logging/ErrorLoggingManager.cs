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
    public class ErrorLoggingManager
    {
        public async Task<List<ErrorLogDTO>> DisplayErrorLogsAsync()
        {
            ErrorLogs e = new ErrorLogs();
            ErrorLoggingService ls = new ErrorLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._logCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        public void DeleteLog(string id)
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            //try
            //{
                var objId = ObjectId.Parse(id);
                var doc = ls._logCollection.Find(x => x.Id == objId).SingleAsync();
                var bsonDoc = doc.ToBsonDocument();
                ls.DeleteErrorLog(bsonDoc);
                //return 1;
            //}
            //catch (MongoException e)
            //{
                //return 0;
            //}
        }
    }
}
