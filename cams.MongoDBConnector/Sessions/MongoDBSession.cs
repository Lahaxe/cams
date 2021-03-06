﻿using cams.model.Core;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.QueryParameters;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace cams.MongoDBConnector.Sessions
{
    /// <summary>
    /// Defines a MongoDB session.
    /// </summary>
    public class MongoDBSession : IMongoDBSession
    {
        /// <summary>
        /// The MongoDB client.
        /// </summary>
        private IMongoClient _client;

        /// <summary>
        /// The MongoDB database.
        /// </summary>
        private IMongoDatabase _database;

        /// <summary>
        /// Initialize a new instance of <see cref="MongoDBSession"/>.
        /// </summary>
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

        /// <summary>
        /// Disposes the MongoDB session.
        /// </summary>
        public void Dispose() => GC.SuppressFinalize(this);

        /// <summary>
        /// Connects to the MongoDB database.
        /// </summary>
        public void Connect()
        {
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["DBName"]);
        }

        /// <summary>
        /// Creates a new collection.
        /// </summary>
        /// <param name="name">Name of the new collection.</param>
        public void CreateCollection(string name)
        {
            if (_database.GetCollection<BsonDocument>(name) == null)
            {
                _database.CreateCollection(name);
            }
        }

        /// <summary>
        /// Deletes a collection.
        /// </summary>
        /// <param name="name">Name of the collection.</param>
        public void DeleteCollection(string name)
        {
            if (_database.GetCollection<BsonDocument>(name) != null)
            {
                _database.DropCollection(name);
            }
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

        /// <summary>
        /// Gets the document corresponding to a given filter.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The filtering parameters.</param>
        /// <returns>The requested document.</returns>
        public BsonDocument Read(string collectionName, BsonDocument bsonDocument)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var result = collection.Find(bsonDocument).FirstOrDefaultAsync();
            result.Wait();
            return result.Result;
        }

        // TODO
        public void Create(string collectionName, BsonDocument doc)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOneAsync(doc).Wait();
        }

        /// <summary>
        /// Deletes a document.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The bson to delete.</param>
        public void Delete(string collectionName, BsonDocument bsonDocument)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var result = collection.DeleteManyAsync(bsonDocument);
            result.Wait();
        }

        /// <summary>
        /// Deletes a list of documents.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The bson documents to delete.</param>
        public void Delete(string collectionName, IList<BsonDocument> bsonDocuments)
        {
            foreach (var bson in bsonDocuments)
            {
                Delete(collectionName, bson);
            }
        }
    }
}