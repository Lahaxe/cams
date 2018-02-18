using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cams.MongoDBConnector.Sessions
{
    public class MongoDBSession : IMongoDBSession
    {
        private IMongoClient _client;

        private IMongoDatabase _database;

        public MongoDBSession()
        {
            var credentials = MongoCredential.CreateCredential(
                ConfigurationManager.AppSettings["DBName"],
                ConfigurationManager.AppSettings["DBUsername"],
                ConfigurationManager.AppSettings["DBPassword"]);

            var mongoClientSettings = new MongoClientSettings
            {
                Credential = credentials,
                Server = new MongoServerAddress(
                    ConfigurationManager.AppSettings["DBServerAddress"], 
                    int.Parse(ConfigurationManager.AppSettings["DBServerPort"]))
            };

            _client = new MongoClient(mongoClientSettings);
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public void Connect()
        {
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["DBName"]);
        }

        public IEnumerable<BsonDocument> Read(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var result = collection.Find(new BsonDocument()).ToListAsync();
            result.Wait();
            return result.Result;
        }

        public BsonDocument Read(string collectionName, string id)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var bsondoc = new BsonDocument();
            bsondoc.Add("id", BsonValue.Create(id));
            var result = collection.Find(bsondoc).FirstOrDefaultAsync();
            result.Wait();
            return result.Result;
        }
    }
}
