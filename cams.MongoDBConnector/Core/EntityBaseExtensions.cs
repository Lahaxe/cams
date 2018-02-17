using cams.model.Core;
using MongoDB.Bson;

namespace cams.MongoDBConnector.Core
{
    /// <summary>
    /// Defines converters for <see cref="EntityBase"/>.
    /// </summary>
    internal static class EntityBaseExtensions
    {
        /// <summary>
        /// Converts a BSON document to <see cref="EntityBase"/>.
        /// </summary>
        /// <typeparam name="T">The type of entityBase object.</typeparam>
        /// <param name="bson">The document to convert.</param>
        /// <returns>The converted object.</returns>
        public static T ToEntityBase<T>(this BsonDocument bson)
            where T : EntityBase, new()
        {
            if (bson == null)
            {
                return null;
            }

            return new T
            {
                Id = bson.GetElement("id").Value.AsString
            };
        }
    }
}