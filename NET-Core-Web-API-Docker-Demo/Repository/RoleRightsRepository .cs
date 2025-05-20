using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class RoleRightsRepository : IRoleRightsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;

        public RoleRightsRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Task<RoleRights> Add(RoleRights activeRoleRights)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuList>> Find(int RoleId)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@RoleId", RoleId);
            return await _connection.QueryAsync<MenuList>("GETMENULIST", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RoleRights>> Get()
        {
            return await _connection.QueryAsync<RoleRights>("RoleRightsGETALL");
        }

        public async Task<IEnumerable<MenuList>> GetMenuListByLId(int RoleId, int MLId)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@RoleId", RoleId);
            parmeters.Add("@MLId", MLId);
            return await _connection.QueryAsync<MenuList>("GETMENULISTBYMLID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public Task<int> Remove(int id, bool isDelete)
        {
            throw new NotImplementedException();
        }

        public Task<RoleRights> Update(RoleRights activeRoleRights)
        {
            throw new NotImplementedException();
        }
    }
}
