using cams.model.Users;
using cams.MongoDBConnector.Core;
using MongoDB.Bson;

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
    }
}