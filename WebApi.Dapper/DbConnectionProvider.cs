using System.Data;
using System.Data.SqlClient;

namespace WebApi.Dapper
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly string connectionString;

        public DbConnectionProvider(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DapperTechTalkConnectionString"];
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
