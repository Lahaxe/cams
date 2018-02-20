using cams.model.Core;
using MongoDB.Bson;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    public interface IMongoDBSession : ISession
    {
        IEnumerable<BsonDocument> Read(string collectionName);

        BsonDocument Read(string collectionName, EntityBase entity);

        void Create(string collectionName, BsonDocument doc);
    }
}
