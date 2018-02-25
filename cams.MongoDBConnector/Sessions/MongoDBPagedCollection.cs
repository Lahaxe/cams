using cams.model.Core;
using MongoDB.Bson;

namespace cams.MongoDBConnector.Sessions
{
    public class MongoDBPagedCollection : PagedCollection<BsonDocument>
    {
    }
}