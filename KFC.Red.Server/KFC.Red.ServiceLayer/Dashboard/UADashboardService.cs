using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Dashboard.Interface;
using KFC.Red.ServiceLayer.Logging;

namespace KFC.Red.ServiceLayer
{
    public class UADashboardService<T> : IUADashboardService
    {
        public MongoClient Client { get; set; }
        /// <summary>
        /// Built in mongodb method of the mongo database
        /// </summary>
        public IMongoDatabase db { get; set; }
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
        public UADashboardService(string collectionName)
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            db = Client.GetDatabase("Logging");
            _logCollection = db.GetCollection<T>(collectionName);
            Collection = collectionName;
        }
    }
}
