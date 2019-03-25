using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace KFC.Red.Dbate.Logging.Repositories
{
    class ErrorCollection
    {
        //Initialized the mongo db repository
        internal MongoDBRepo _repo = new MongoDBRepo("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true", "connectiontest");
        //Defines the collectio name used by project
        private const string _collectionName = "ErrorLogs";
        //Contains all document inside the collection
        private readonly IMongoCollection<ErrorLogs> _collection;


        public ErrorCollection()
        {
            _collection = _repo._database.GetCollection<ErrorLogs>(_collectionName);
        }

        /// <summary>
        /// List out the error logs
        /// </summary>
        /// <returns></returns>
        public List<ErrorLogs> GetAll()
        {
            var query = _collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        /// <summary>
        /// Get an error log by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ErrorLogs Get(string id)
        {
            return _collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }

        /// <summary>
        /// Delete one error log
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _collection.DeleteOne(new BsonDocument { { "_id", new ObjectId(id) } });
        }

        /// <summary>
        /// Delete all the error logs
        /// </summary>
        public void DeleteAll()
        {
            _collection.DeleteManyAsync(FilterDefinition<ErrorLogs>.Empty);
        }

        /// <summary>
        /// Count the amount of logs
        /// </summary>
        /// <returns></returns>
        public long CountLogs()
        {
            return _collection.EstimatedDocumentCount();
        }

    }
}
