using cams.model.Core;
using cams.model.QueryParameters.Fields;
using cams.model.QueryParameters.Filters;
using cams.model.QueryParameters.Pages;
using cams.model.QueryParameters.Sorts;
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
        /// <param name="lang">The language.</param>
        /// <param name="paging">The paging parameters.</param>
        /// <param name="sorting">The sorting parameters.</param>
        /// <param name="filtering">The filtering parameters.</param>
        /// <param name="fielding">The fielding parameters.</param>
        /// <returns>The pagined list of <see cref="User"/>.</returns>
        PagedCollection<User> GetUsers(string lang,
                                       PagingParameters paging,
                                       SortingParameters sorting,
                                       FilteringParameters filtering,
                                       FieldingParameters fielding);

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
        /// Updates an <see cref="User"/>.
        /// </summary>
        /// <param name="user">The user to update.</param>
        void PatchUser(User user);

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