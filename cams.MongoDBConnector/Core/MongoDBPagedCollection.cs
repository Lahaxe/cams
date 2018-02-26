using cams.model.Core;
using MongoDB.Bson;

namespace cams.MongoDBConnector.Core
{
    public class MongoDBPagedCollection : PagedCollection<BsonDocument>
    {
    }
}