using System.Data;

namespace WebApi.Dapper
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}