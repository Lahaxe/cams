using cams.model.Core;
using MongoDB.Bson;

namespace cams.MongoDBConnector.Core
{
    /// <summary>
    /// Defines paged collection for MongoDB requests.
    /// </summary>
    public class MongoDBPagedCollection : PagedCollection<BsonDocument>
    {
    }
}