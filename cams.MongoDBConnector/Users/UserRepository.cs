using cams.model.Core;
using cams.model.Users;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Users
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IMongoDBSessionFactory factory):
            base(factory)
        {

        }

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
