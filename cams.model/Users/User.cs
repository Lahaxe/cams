using cams.model.Core;

namespace cams.model.Users
{
    /// <summary>
    /// Defines an user.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// Gets or sets the User role.
        /// </summary>
        //public UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the User name.
        /// </summary>
        public string Name { get; set; }
    }
}
