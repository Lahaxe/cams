using cams.model.Core;
using System.Collections.Generic;

namespace cams.model.Users
{
    /// <summary>
    /// Defines the interface for user repository.
    /// </summary>
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Get a list of <see cref="User"/>.
        /// </summary>
        /// <returns>The pagined list of <see cref="User"/>.</returns>
        PagedCollection<User> GetUsers();

        /// <summary>
        /// Get a <see cref="User"/> by Id.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The requested <see cref="User"/>.</returns>
        User GetUser(string id);

        /// <summary>
        /// Creates an <see cref="User"/>.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user.</returns>
        User CreateUser(User user);

        /// <summary>
        /// Deletes an <see cref="User"/>.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        void DeleteUser(string id);

        /// <summary>
        /// Deletes <see cref="User"/>.
        /// </summary>
        /// <param name="ids">List of user identifiers.</param>
        void DeleteUsers(IList<string> ids);
    }
}
