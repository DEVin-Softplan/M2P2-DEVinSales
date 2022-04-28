using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevInSales.Freight.Data.Context
{
    public class FreightContext:DbContext
    {
        public FreightContext(DbContextOptions<FreightContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FreightContext).Assembly);
        }
    }
}
