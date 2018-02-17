using cams.model.Core;
using MongoDB.Bson;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    public interface IMongoDBSession : ISession
    {
        IEnumerable<BsonDocument> Read(string collectionName);
    }
}
