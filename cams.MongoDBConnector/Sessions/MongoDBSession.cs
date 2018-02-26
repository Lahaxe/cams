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

        /// <summary>
        /// Gets a <see cref="MongoDBPagedCollection"/> from database.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="paging">The paging parameters.</param>
        /// <param name="sorting">The sorting parameters.</param>
        /// <param name="filtering">The filtering parameters.</param>
        /// <returns>The requested page.</returns>
        public MongoDBPagedCollection Read(string collectionName,
            MongoDBPagingParameters paging,
            SortDefinition<BsonDocument> sorting,
            FilterDefinition<BsonDocument> filtering = null)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            var query = collection.Find(filtering ?? FilterDefinition<BsonDocument>.Empty);

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