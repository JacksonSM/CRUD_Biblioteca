using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Biblioteca.Infrastructure.Database;
public sealed class DbSession : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    public DbSession(IConfiguration configuration)
    {
        Connection = new SqlConnection(configuration["ConnectionString"]);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}