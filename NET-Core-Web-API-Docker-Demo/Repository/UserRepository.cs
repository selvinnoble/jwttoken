using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public UserRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<User> Add(User activeUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id",0,  direction:ParameterDirection.Output);
            parameters.Add("@Name", activeUser.Name);
            parameters.Add("@Username", activeUser.Username);
            parameters.Add("@Active", activeUser.Active);
            parameters.Add("@RoleId", activeUser.RoleId);
            parameters.Add("@IsEmployee", activeUser.IsEmployee);
            parameters.Add("@EmployeeId", activeUser.EmployeeId);
            parameters.Add("@IsAdminUser", activeUser.IsAdmin);
            parameters.Add("@Password", activeUser.Password);
            parameters.Add("@CreatedDate", activeUser.CreatedDate = DateTime.Now);
            parameters.Add("@CreatedBy", activeUser.CreatedBy);
            await _connection.ExecuteAsync("USERINSERT", parameters, commandType: CommandType.StoredProcedure);
            return activeUser;
        }

        public async Task<User> Find(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<User>("USERGETBYID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<User>> Get()
        {
         
                return await _connection.QueryAsync<User>("USERGETALL");
        }

        public async Task<User> LoginAction(User activeUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Username", activeUser.Username);
            parameters.Add("@Password", activeUser.Password);

            //await _connection.ExecuteAsync("UserGetUNPASS", parameters, commandType: CommandType.StoredProcedure);
            return await _connection.QueryFirstOrDefaultAsync<User>("UserGetUNPASS", parameters, commandType: CommandType.StoredProcedure);
            //return activeUser;
        }

        public async Task<int> Remove(int id, bool isDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@IsDelete", isDelete);
            return await _connection.ExecuteAsync("USERDELETE", parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<User> Update(User activeUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", activeUser.Id);
            parameters.Add("@Name", activeUser.Name);
            parameters.Add("@Username", activeUser.Username);
            parameters.Add("@Active", activeUser.Active);
            parameters.Add("@RoleId", activeUser.RoleId);
            parameters.Add("@IsEmployee", activeUser.IsEmployee);
            parameters.Add("@EmployeeId", activeUser.EmployeeId);
            parameters.Add("@IsAdminUser", activeUser.IsAdmin);
            parameters.Add("@Password", activeUser.Password);
            parameters.Add("@ModifiedDate", activeUser.ModifiedDate = DateTime.Now);
            parameters.Add("@ModifiedBy", activeUser.ModifiedBy);

            await _connection.ExecuteAsync("USERUPDATE", parameters, commandType: CommandType.StoredProcedure);
            return activeUser;
        }

        public async Task<User> UserGetUNPASS(string username, string password)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@username", username);
            parmeters.Add("@password", password);
            return await _connection.QueryFirstOrDefaultAsync<User>("UserGetUNPASS", parmeters, commandType: CommandType.StoredProcedure);
        }
    }
}
