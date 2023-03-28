using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Storage.Dapper
{
    public class MarketplaceDapperContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
        public MarketplaceDapperContext(IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            Connection?.Close();
            Connection?.Dispose();
        }
    }
}
