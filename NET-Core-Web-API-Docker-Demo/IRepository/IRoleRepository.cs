
namespace nijapmsapi
{
    public interface IRoleRepository
    {

        Task<IEnumerable<Role>> Get();
        Task<Role> Find(int RoleId);
        Task<Role> Add(User activeUser);
        Task<Role> Update(User activeUser);
        Task<int> Remove(int id);

    }
}
