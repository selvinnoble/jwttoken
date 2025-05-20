namespace nijapmsapi
{
    public interface IRoleRightsRepository
    {
        Task<IEnumerable<RoleRights>> Get();
        Task<IEnumerable<MenuList>> Find(int id);
        Task<IEnumerable<MenuList>> GetMenuListByLId(int RoleId, int MLId);
        Task<RoleRights> Add(RoleRights activeRoleRights);
        Task<RoleRights> Update(RoleRights activeRoleRights);
        Task<int> Remove(int id, bool isDelete);
    }
}
