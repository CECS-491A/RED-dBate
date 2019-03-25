using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace KFC.Red.Dbate.Logging.Repositories
{
    /// <summary>
    /// File to connect to the Mongo Repository.
    /// </summary>
    public class MongoDBRepo
    {
        //The client that manage the connection
        public MongoClient _client;
        //The interface that manage the database
        public IMongoDatabase _database;

        public MongoDBRepo(string url, string database)
        {
            _client = new MongoClient(url);
            _database = _client.GetDatabase(database);
        }
    }
}
