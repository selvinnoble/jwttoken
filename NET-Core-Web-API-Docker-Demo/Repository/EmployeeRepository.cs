using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public EmployeeRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Employee> Add(Employee activeEmployee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, direction: ParameterDirection.Output);
            parameters.Add("@FirstName", activeEmployee.FirstName);
            parameters.Add("@LastName", activeEmployee.LastName);
            parameters.Add("@Email", activeEmployee.Email);
            parameters.Add("@Phone", activeEmployee.Phone);
            parameters.Add("@DepartmentId", activeEmployee.DepartmentId);
            parameters.Add("@Salary", activeEmployee.Salary);
            parameters.Add("@JoiningDate", activeEmployee.JoiningDate);
            parameters.Add("@IsActive", activeEmployee.Active);
            parameters.Add("@CreatedBy", activeEmployee.CreatedBy);

            await _connection.ExecuteAsync("EMPLOYEEINSERT", parameters, commandType: CommandType.StoredProcedure);
            return activeEmployee;
        }

        public async Task<Employee> Find(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<Employee>("EMPLOYEEGETBYID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Employee>> Get(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryAsync<Employee>("EMPLOYEEGETALL", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Remove(int id,  bool isDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@IsDelete", isDelete);
            return await _connection.ExecuteAsync("EMPLOYEEDELETE", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Employee> Update(Employee activeEmployee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", activeEmployee.EmployeeID);
            parameters.Add("@FirstName", activeEmployee.FirstName);
            parameters.Add("@LastName", activeEmployee.LastName);
            parameters.Add("@Email", activeEmployee.Email);
            parameters.Add("@Phone", activeEmployee.Phone);
            parameters.Add("@DepartmentId", activeEmployee.DepartmentId);
            parameters.Add("@Salary", activeEmployee.Salary);
            parameters.Add("@JoiningDate", activeEmployee.JoiningDate);
            parameters.Add("@IsActive", activeEmployee.Active);
            parameters.Add("@ModifiedBy", activeEmployee.ModifiedBy);

            await _connection.ExecuteAsync("EMPLOYEEUPDATE", parameters, commandType: CommandType.StoredProcedure);
            return activeEmployee;
        }
    }
}
