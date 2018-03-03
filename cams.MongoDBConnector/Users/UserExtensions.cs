using cams.model.Users;
using cams.MongoDBConnector.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace cams.MongoDBConnector.Users
{
    /// <summary>
    /// Defines converters for <see cref="User"/>.
    /// </summary>
    internal static class UserExtensions
    {
        /// <summary>
        /// Converts a BSON document to <see cref="User"/>.
        /// </summary>
        /// <param name="bson">The document to convert.</param>
        /// <returns>The converted object.</returns>
        public static User ToUser(this BsonDocument bson)
        {
            if (bson == null)
            {
                return null;
            }

            // Initialize base class
            var user = bson.ToEntityBase<User>();

            // Read data from bson
            user.Name = bson.GetElement("name").Value.AsString;

            return user;
        }

        /// <summary>
        /// Converts an <see cref="User"/> to BSON document.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to convert.</param>
        /// <param name="bson">The converted document.</param>
        /// <param name="insertNull">Flag indicating if null value should be insert.</param>
        public static void ToBsonDocument(this User user, ref BsonDocument bson, bool insertNull = true)
        {
            user.ToBsonDocumentBase(ref bson);

            if (user.Name != null)
            {
                bson.Add("name", user.Name);
            }
            else if (insertNull)
            {
                bson.Add("name", BsonNull.Value);
            }
        }

        public static UpdateDefinition<BsonDocument> ToUpdateBsonDocument(this User user, bool insertNull = true)
        {
            var changeList = new List<UpdateDefinition<BsonDocument>>();
            if (user.Name != null)
            {
                changeList.Add(Builders<BsonDocument>.Update.Set("name", user.Name));
            }
            else if (insertNull)
            {
                changeList.Add(Builders<BsonDocument>.Update.Set("name", BsonNull.Value));
            }

            return Builders<BsonDocument>.Update.Combine(changeList);
        }

        /// <summary>
        /// Converts a list of <see cref="BsonDocument"/> to a list of <see cref="User"/>.
        /// </summary>
        /// <param name="bsons">List to convert.</param>
        /// <returns>The converted list.</returns>
        public static IEnumerable<User> ToUserList(this IEnumerable<BsonDocument> bsons)
        {
            var result = new List<User>();
            bsons.ToList().ForEach(bson => result.Add(bson.ToUser()));

            return result;
        }
    }
}