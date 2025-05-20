
namespace nijapmsapi
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> Get();
        Task<User> UserGetUNPASS(string username, string password);
        Task<User> Find(int id);
        Task<User> Add(User activeUser);
        Task<User> Update(User activeUser);
        Task<User> LoginAction(User activeUser);
        Task<int> Remove(int id, bool isDelete);

    }
}
