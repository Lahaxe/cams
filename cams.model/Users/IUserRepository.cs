using cams.model.Core;

namespace cams.model.Users
{
    public interface IUserRepository : IRepository
    {
        PagedCollection<User> GetUsers();

        User GetUser();
    }
}
