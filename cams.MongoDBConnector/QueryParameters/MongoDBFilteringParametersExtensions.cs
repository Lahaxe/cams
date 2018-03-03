using cams.model.QueryParameters.Filters;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cams.MongoDBConnector.QueryParameters
{
    /// <summary>
    /// Defines converters for <see cref="FilteringParameters"/>.
    /// </summary>
    internal static class MongoDBFilteringParametersExtensions
    {
        /// <summary>
        /// Converts a <see cref="FilteringParameters"/> to MongoDB filters.
        /// </summary>
        /// <param name="filtering">The filtering parameters to convert.</param>
        /// <returns>The MongoDB filters.</returns>
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