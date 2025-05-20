using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace nijapmsapi
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        private readonly string dbConnection;
        private readonly SqlConnection _connection;
        public GradeRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Grade> Add(Grade activeGrade)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, direction: ParameterDirection.Output);
            parameters.Add("@Code", activeGrade.Code);
            parameters.Add("@Name ", activeGrade.Name);
            parameters.Add("@CreateBy", activeGrade.CreatedBy);
            await _connection.ExecuteAsync("GRADEINSERT", parameters, commandType: CommandType.StoredProcedure);
            return activeGrade;
        }

        public async Task<Grade> Find(int id)
        {
            var parmeters = new DynamicParameters();
            parmeters.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<Grade>("GRADEGETBYID", parmeters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Grade>> Get()
        {
            return await _connection.QueryAsync<Grade>("GRADEGETALL");
        }

        public async Task<int> Remove(int id, bool isDelete)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@IsDelete", isDelete);
            return await _connection.ExecuteAsync("GRADEDELETEBYID", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Grade> Update(Grade activeGrade)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", activeGrade.Id);
            parameters.Add("@Code", activeGrade.Code);
            parameters.Add("@Name", activeGrade.Name);
            parameters.Add("@Active", activeGrade.Active);
            parameters.Add("@ModifiedBy", activeGrade.ModifiedBy);
            await _connection.ExecuteAsync("GRADEUPDATE", parameters, commandType: CommandType.StoredProcedure);
            return activeGrade;
        }
    }
}
