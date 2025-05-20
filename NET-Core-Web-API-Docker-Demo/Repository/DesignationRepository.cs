using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public DesignationRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Designation> Add(Designation activeDesignation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, direction: ParameterDirection.Output);
            parameters.Add("@Code", activeDesignation.Code);
            parameters.Add("@Name ", activeDesignation.Name);
            parameters.Add("@CreateBy", activeDesignation.CreatedBy);
            await _connection.ExecuteAsync("DESIGNATIONINSERT", parameters, commandType: CommandType.StoredProcedure);
            return activeDesignation;
        }

        public async Task<Designation> Find(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<Designation>("DESIGNATIONGETBYID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Designation>> Get()
        {
            return await _connection.QueryAsync<Designation>("DESIGNATIONGETALL");
        }

        public async Task<int> Remove(int id, bool isDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@IsDelete", isDelete);
            return await _connection.ExecuteAsync("DESIGNATIONDELETE", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Designation> Update(Designation activeDesignation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", activeDesignation.Id);
            parameters.Add("@Code", activeDesignation.Code);
            parameters.Add("@Name", activeDesignation.Name);
            parameters.Add("@Active", activeDesignation.Active);
            parameters.Add("@ModifiedBy", activeDesignation.ModifiedBy);
            await _connection.ExecuteAsync("DESIGNATIONUPDATE", parameters, commandType: CommandType.StoredProcedure);
            return activeDesignation;
        }
    }
}
