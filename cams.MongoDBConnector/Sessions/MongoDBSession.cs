using cams.model.Core;
using cams.MongoDBConnector.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;

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

        public MongoDBPagedCollection Read(string collectionName, MongoDBPagingParameters paging, SortDefinition<BsonDocument> sorting)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            var query = collection.Find(new BsonDocument());

            var totalTask = query.Count();
            if (sorting != null)
            {
                query = query.Sort(sorting);
            }
            var itemsTask = query.Skip(paging.Skip).Limit(paging.Limit).ToList();

            return new MongoDBPagedCollection
            {
                Items = itemsTask,
                TotalNumberOfItems = totalTask,
                PageIndex = 0,
                PageSize = 0,
                TotalNumberOfPages = 0
            };
        }

        public BsonDocument Read(string collectionName, EntityBase entity)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            BsonDocument bson = null;
            entity.ToBsonDocumentBase(ref bson);
            var result = collection.Find(bson).FirstOrDefaultAsync();
            result.Wait();
            return result.Result;
        }

        public void Create(string collectionName, BsonDocument doc)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOneAsync(doc).Wait();
        }

        public void Delete(string collectionName, EntityBase entity)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            BsonDocument bson = null;
            entity.ToBsonDocumentBase(ref bson);
            var result = collection.DeleteManyAsync(bson);
            result.Wait();
        }

        public void Delete(string collectionName, IList<EntityBase> entities)
        {
            foreach (var entity in entities)
            {
                Delete(collectionName, entity);
            }
        }
    }
}