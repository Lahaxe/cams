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
        /// <returns>The requested <see cref="User"/>.</returns>
        User GetUser();
    }
}
