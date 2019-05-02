using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Dashboard.Interface;

namespace KFC.Red.ServiceLayer
{
    public class DashboardService<T> : IDashboardService
    {
        public MongoClient Client { get; set; }
        private readonly IMongoCollection<T> _logCollection;
        public IMongoDatabase documents { get; set; }
        private string Collection { get; set; }

        public DashboardService(string collectionName)
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            documents = Client.GetDatabase("Logging");
            _logCollection = documents.GetCollection<T>(collectionName);
            Collection = collectionName;
        }
    }
}
