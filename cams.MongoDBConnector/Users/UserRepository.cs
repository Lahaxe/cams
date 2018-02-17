using cams.model.Core;
using cams.model.Users;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Users
{
    /// <summary>
    /// Defines the mongodb user repository.
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Create a new instance of <see cref="UserRepository"/>.
        /// </summary>
        /// <param name="factory">The mongodb session factory.</param>
        public UserRepository(IMongoDBSessionFactory factory):
            base(factory)
        {

        }

        /// <summary>
        /// Get a list of <see cref="User"/>.
        /// </summary>
        /// <returns>The pagined list of <see cref="User"/>.</returns>
        public PagedCollection<User> GetUsers()
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            var result = Session.Read("users");

            var users = new List<User>();
            foreach (BsonDocument doc in result)
            {
                users.Add(doc.ToUser());
            }

            return new PagedCollection<User>
            {
                Items = users,
                TotalNumberOfItems = users.Count,
                PageIndex = 1,
                PageSize = users.Count,
                TotalNumberOfPages = 1
            };
        }

        /// <summary>
        /// Get a <see cref="User"/> by Id.
        /// </summary>
        /// <returns>The requested <see cref="User"/>.</returns>
        public User GetUser()
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            // TODO
            return new User();
        }
    }
}
