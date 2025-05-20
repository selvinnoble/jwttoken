using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public DepartmentRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Department> Add(Department activeDepartment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, direction: ParameterDirection.Output);
            parameters.Add("@Code", activeDepartment.Code);
            parameters.Add("@Name ", activeDepartment.Name);
            parameters.Add("@CreateBy", activeDepartment.CreatedBy);
            await _connection.ExecuteAsync("DepartmentINSERT", parameters, commandType: CommandType.StoredProcedure);
            return activeDepartment;
        }

        public async Task<Department> Find(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<Department>("DepartmentGETBYID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Department>> Get()
        {
            return await _connection.QueryAsync<Department>("DepartmentGETALL");
        }

        public async Task<int> Remove(int id, bool isDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@IsDelete", isDelete);
            return await _connection.ExecuteAsync("DEPARTMENTDELETEBYID", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Department> Update(Department activeDepartment)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", activeDepartment.Id);
                parameters.Add("@Code", activeDepartment.Code);
                parameters.Add("@Name", activeDepartment.Name);
                parameters.Add("@Active", activeDepartment.Active);
                parameters.Add("@ModifiedBy", activeDepartment.ModifiedBy);
                await _connection.ExecuteAsync("DEPARTMENTUPDATE", parameters, commandType: CommandType.StoredProcedure);
                return activeDepartment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
