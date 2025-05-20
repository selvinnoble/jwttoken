using Dapper;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public RoleRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Task<Role> Add(User activeUser)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _connection.QueryAsync<Role>("ROLEGETALL");
        }

        public Task<int> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(User activeUser)
        {
            throw new NotImplementedException();
        }
    }
}
