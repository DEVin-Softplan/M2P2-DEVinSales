using DevInSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInSales.Mapping
{
    public class ShippingCompanyMapping : IEntityTypeConfiguration<ShippingCompany>
    {
        public void Configure(EntityTypeBuilder<ShippingCompany> builder)
        {
            builder.ToTable("shipping_company");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.HasMany(t => t.StatesPrices)
                   .WithOne(t => t.ShippingCompany);
        }
    }
}
