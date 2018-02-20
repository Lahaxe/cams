using cams.model.Core;

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
    }
}
