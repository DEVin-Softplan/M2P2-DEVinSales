using DevInSales.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Config
{
    public static class DbContextHelper
    {
        public static DbContextOptions<SqlContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new DbContextOptionsBuilder<SqlContext>()
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("ServerConnection"))).Options;

        }
    }
}
