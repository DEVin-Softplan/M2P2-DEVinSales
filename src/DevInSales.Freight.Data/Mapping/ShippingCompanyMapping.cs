using DevInSales.Freight.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInSales.Freight.Data.Mapping
{
    public class ShippingCompanyMapping : IEntityTypeConfiguration<ShippingCompanyModel>
    {
        public void Configure(EntityTypeBuilder<ShippingCompanyModel> builder)
        {
            builder.ToTable("shipping_company");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .HasColumnType("varchar")
                .HasMaxLength(255);
        }
    }
}
