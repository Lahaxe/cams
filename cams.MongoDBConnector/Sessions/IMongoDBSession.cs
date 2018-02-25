﻿using cams.model.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    public interface IMongoDBSession : ISession
    {
        MongoDBPagedCollection Read(string collectionName, MongoDBPagingParameters paging, SortDefinition<BsonDocument> sorting);

        BsonDocument Read(string collectionName, EntityBase entity);

        void Create(string collectionName, BsonDocument doc);

        void Delete(string collectionName, EntityBase entity);

        void Delete(string collectionName, IList<EntityBase> entities);
    }
}