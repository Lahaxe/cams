using cams.model.Core;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.QueryParameters;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    public interface IMongoDBSession : ISession
    {
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

        BsonDocument Read(string collectionName, EntityBase entity);

        void Create(string collectionName, BsonDocument doc);

        void Delete(string collectionName, EntityBase entity);

        void Delete(string collectionName, IList<EntityBase> entities);
    }
}