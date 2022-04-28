using DevInSales.Models;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Context;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<Order_Product> Order_Product { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Delivery> Delivery { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Order_Product>();
        product.HasKey(x => x.Id);
        product.Property(x => x.Order_Id).HasColumnName("order_id").HasColumnType("int").IsRequired();
        product.Property(x => x.Product_Id).HasColumnName("product_id").HasColumnType("int").IsRequired();
        product.Property(x => x.Unit_Price).HasColumnName("unit_price").HasColumnType("float").IsRequired();
        product.Property(x => x.Amount).HasColumnName("amount").HasColumnType("int").IsRequired();
  
        modelBuilder.Entity<Order>()
            .Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        modelBuilder.Entity<Order>()
            .Property(x => x.User_Id)
            .HasColumnName("user_id")
            .IsRequired();

        modelBuilder.Entity<Order>()
           .Property(x => x.Seller_Id)
           .HasColumnName("seller_id")
           .IsRequired();

        modelBuilder.Entity<Order>()
           .Property(x => x.Date_Order)
           .HasColumnName("date_order")
           .IsRequired();

        modelBuilder.Entity<Order>()
           .Property(x => x.Shipping_Company)
           .HasColumnName("shipping_Company")
           .HasMaxLength(50)
           .IsRequired();

        modelBuilder.Entity<Order>()
           .Property(x => x.Shipping_Company_Price)
           .HasColumnName("shipping_company_price")
           .IsRequired();


    }

}
