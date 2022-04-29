using DevInSales.Freight.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInSales.Freight.Data.Mapping
{
    public class StateMapping : IEntityTypeConfiguration<StateModel>
    {
        public void Configure(EntityTypeBuilder<StateModel> builder)
        {
            builder.ToTable("state");
            builder.HasKey("Id");
            builder.HasMany(t => t.StatesPrices)
                   .WithOne(t => t.State);
        }
    }
}
