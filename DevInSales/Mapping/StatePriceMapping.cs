using DevInSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInSales.Mapping
{
    public class StatePriceMapping : IEntityTypeConfiguration<StatePrice>
    {
        public void Configure(EntityTypeBuilder<StatePrice> builder)
        {
            builder.ToTable("state_price");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.BasePrice)
                   .HasColumnType("decimal(16,2)")
                   .HasMaxLength(16);
            builder.HasOne(t => t.State)
                .WithMany(t => t.StatesPrices)
                .HasForeignKey(t=> t.StateId);

            builder.HasOne(t => t.ShippingCompany)
                .WithMany(t => t.StatesPrices)
                .HasForeignKey(t=> t.ShippingCompanyId);
        }    }
}

