using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace KFC.Red.Dbate.Logging.Repositories
{
    class ErrorRepository
    {
        MongoDBRepo _repo = new MongoDBRepo("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true", "connectiontest");
        private const string _collectionName = "ErrorLogs";
        private readonly IMongoCollection<ErrorLogs> Collection;

        public ErrorRepository()
        {
            this.Collection = _repo.Db.GetCollection<ErrorLogs>(_collectionName);
        }

        public List<ErrorLogs> GetAll()
        {
            var query = this.Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        // Get an ErrorLogs by id
        public ErrorLogs Get(string id)
        {
            return this.Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }

    /*
        //Delete Errors by id
        public void Delete()
        {
            this.Collection.DeleteOne(FilterDefinition<ErrorLogs>."_id");
        }
        */

        public void DeleteAll()
        {
            this.Collection.DeleteManyAsync(FilterDefinition<ErrorLogs>.Empty);
        }

        public long CountLogs()
        {
            return this.Collection.EstimatedDocumentCount();
        }

        /*
        //retrieve's data
        public Retrieve()
        {
            await collection.Find(new BsonDocument()).ForEachAsync(x => Console.WriteLine(x));
        }
        */

    }
}
