using cams.model.QueryParameters.Sorts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cams.MongoDBConnector.QueryParameters
{
    /// <summary>
    /// Defines converters for <see cref="SortingParameters"/>.
    /// </summary>
    internal static class MongoDBSortingParametersExtensions
    {
        /// <summary>
        /// Converts sorting parameters to MongoDB sort definition.
        /// </summary>
        /// <param name="sorting">The sorting parameters to convert.</param>
        /// <returns>The converted MongoDB sorting parameters.</returns>
        public static SortDefinition<BsonDocument> ToSortDefinition(this SortingParameters sorting)
        {
            if (sorting == null)
            {
                return null;
            }

            var builder = Builders<BsonDocument>.Sort;
            SortDefinition<BsonDocument> result = null;

            foreach (var sort in sorting.Sorts)
            {
                if (result == null)
                {
                    if (sort.Direction == SortingDirection.Ascending)
                    {
                        result = builder.Ascending(sort.Attribute);
                    }
                    else
                    {
                        result = builder.Descending(sort.Attribute);
                    }
                }
                else
                {
                    if (sort.Direction == SortingDirection.Ascending)
                    {
                        result = result.Ascending(sort.Attribute);
                    }
                    else
                    {
                        result = result.Descending(sort.Attribute);
                    }
                }
            }

            return result;
        }
    }
}