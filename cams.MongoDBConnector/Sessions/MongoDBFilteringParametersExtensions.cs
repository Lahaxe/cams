using cams.model.QueryParameters.Filters;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cams.MongoDBConnector.Sessions
{
    internal static class MongoDBFilteringParametersExtensions
    {
        public static FilterDefinition<BsonDocument> ToFilterDefinition(this FilteringParameters filtering)
        {
            if (filtering == null)
            {
                return null;
            }

            return filtering.Filter.ToFilterDefinition();
        }
    }
}