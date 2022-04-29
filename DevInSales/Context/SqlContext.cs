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
        var order_product = modelBuilder.Entity<Order_Product>();
        order_product.HasKey(x => x.Id);
        order_product.Property(x => x.Order_Id).HasColumnName("order_id").HasColumnType("int").IsRequired();
        order_product.Property(x => x.Product_Id).HasColumnName("product_id").HasColumnType("int").IsRequired();
        order_product.Property(x => x.Unit_Price).HasColumnName("unit_price").HasColumnType("decimal").IsRequired();
        order_product.Property(x => x.Amount).HasColumnName("amount").HasColumnType("int").IsRequired();

        var order = modelBuilder.Entity<Order>();
        order.HasKey(x => x.Id);
        order.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        order.Property(x => x.User_Id).HasColumnName("user_id").HasColumnType("int").IsRequired();
        order.Property(x => x.Seller_Id).HasColumnName("seller_id").HasColumnType("int").IsRequired();
        order.Property(x => x.Date_Order).HasColumnName("date_order").HasColumnType("date").IsRequired();
        order.Property(x => x.Shipping_Company).HasColumnName("shipping_Company").HasColumnType("varchar(50)").IsRequired();
        order.Property(x => x.Shipping_Company_Price).HasColumnName("shipping_company_price").HasColumnType("varchar(50)").IsRequired();

        var delivery = modelBuilder.Entity<Delivery>();
        delivery.HasKey(x => x.Id);
        delivery.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        delivery.Property(x => x.Order_Id).HasColumnName("order_id").HasColumnType("int").IsRequired();
        delivery.Property(x => x.Address_Id).HasColumnName("address_id").HasColumnType("int").IsRequired();
        delivery.Property(x => x.Delivery_Forecast).HasColumnName("delivery_Forecast").HasColumnType("date").IsRequired();
        delivery.Property(x => x.Delivery_Date).HasColumnName("delivery_Date").HasColumnType("date");
        delivery.Property(x => x.Status).HasColumnName("status").HasColumnType("int").IsRequired();

    }
}
