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
                Id = bson.GetElement("_id").Value.AsObjectId.ToString()
            };
        }

        /// <summary>
        /// Converts an <see cref="EntityBase"/> to BSON document.
        /// </summary>
        /// <typeparam name="T">The type of entityBase object.</typeparam>
        /// <param name="entity">The <see cref="EntityBase"/> to convert.</param>
        /// <param name="bson">The converted document.</param>
        public static void ToBsonDocumentBase<T>(this T entity, ref BsonDocument bson)
            where T : EntityBase
        {
            if (entity == null)
            {
                bson = null;
                return;
            }

            if (bson == null)
            {
                bson = new BsonDocument();
            }

            var objId = new ObjectId();
            if (entity.Id != null && ObjectId.TryParse(entity.Id, out objId))
            {
                bson.Add("_id", objId);
            }
            else
            {
                bson.Add("_id", BsonNull.Value);
            }
        }
    }
}