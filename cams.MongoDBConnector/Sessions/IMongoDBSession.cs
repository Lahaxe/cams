using cams.model.Core;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.QueryParameters;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    /// <summary>
    /// Defines a MongoDB session.
    /// </summary>
    public interface IMongoDBSession : ISession
    {
        void CreateCollection(string name);

        void DeleteCollection(string name);

        /// <summary>
        /// Gets a <see cref="MongoDBPagedCollection"/> from database.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="paging">The paging parameters.</param>
        /// <param name="sorting">The sorting parameters.</param>
        /// <param name="filtering">The filtering parameters.</param>
        /// <returns>The requested page.</returns>
        MongoDBPagedCollection Read(string collectionName,
                                    MongoDBPagingParameters paging,
                                    SortDefinition<BsonDocument> sorting,
                                    FilterDefinition<BsonDocument> filtering = null);

        /// <summary>
        /// Gets the document corresponding to a given filter.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The filtering parameters.</param>
        /// <returns>The requested document.</returns>
        BsonDocument Read(string collectionName, BsonDocument bsonDocument);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">Document to create.</param>
        void Create(string collectionName, BsonDocument bsonDocument);

        BsonDocument Update(string collectionName, 
                            FilterDefinition<BsonDocument> filtering,
                            UpdateDefinition<BsonDocument> update);

        /// <summary>
        /// Deletes a document.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The bson to delete.</param>
        void Delete(string collectionName, BsonDocument bsonDocument);

        /// <summary>
        /// Deletes a list of documents.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="bsonDocument">The bson documents to delete.</param>
        void Delete(string collectionName, IList<BsonDocument> bsonDocuments);
    }
}