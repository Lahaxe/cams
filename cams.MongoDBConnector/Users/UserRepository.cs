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
        public UserRepository(IMongoDBSessionFactory factory)
            : base(factory)
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
        /// <param name="id">The user identifier.</param>
        /// <returns>The requested <see cref="User"/>.</returns>
        public User GetUser(string id)
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            var result = Session.Read("users", new EntityBase { Id = id });

            if (result == null || result.IsBsonNull)
            {
                throw new UserNotFoundException();
            }

            return result.ToUser();
        }

        /// <summary>
        /// Creates an <see cref="User"/>.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user.</returns>
        public User CreateUser(User user)
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            // Creates the user
            BsonDocument doc = null;
            user.ToBsonDocument(ref doc);
            doc.Remove("_id");
            Session.Create("users", doc);

            // Read the created user
            return GetUser(doc.GetElement("_id").Value.AsObjectId.ToString());
        }

        /// <summary>
        /// Deletes an <see cref="User"/>.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public void DeleteUser(string id)
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            Session.Delete("users", new EntityBase { Id = id });
        }

        /// <summary>
        /// Deletes <see cref="User"/>.
        /// </summary>
        /// <param name="ids">List of user identifiers.</param>
        public void DeleteUsers(IList<string> ids)
        {
            if (Session == null)
            {
                throw new Exception("Session is null");
            }

            IList<EntityBase> entities = new List<EntityBase>();
            foreach (var id in ids)
            {
                entities.Add(new EntityBase { Id = id });
            }

            Session.Delete("users", entities);
        }
    }
}