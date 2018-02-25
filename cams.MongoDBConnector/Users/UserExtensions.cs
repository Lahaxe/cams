using cams.model.Users;
using cams.MongoDBConnector.Core;
using MongoDB.Bson;
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
        public static void ToBsonDocument(this User user, ref BsonDocument bson)
        {
            user.ToBsonDocumentBase(ref bson);

            bson.Add("name", user.Name);
        }

        public static IEnumerable<User> ToUserList(this IEnumerable<BsonDocument> bsons)
        {
            var result = new List<User>();
            bsons.ToList().ForEach(bson => result.Add(bson.ToUser()));

            return result;
        }
    }
}