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
    class MongoDBRepo
    {
        //The client that manage the connection
        public MongoClient Client;
        //The interface that manage the database
        public IMongoDatabase Db;

        public MongoDBRepo(string url, string database)
        {
            this.Client = new MongoClient(url);
            // Comment out. (create database if it doenst exist already)
            this.Db = this.Client.GetDatabase(database);
        }
    }
}
