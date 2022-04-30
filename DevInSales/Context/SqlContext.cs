using DevInSales.Models;
using DevInSales.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Context;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }
    
    public DbSet<City> City { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Address> Address { get; set; }
    
    public DbSet<Order_Product> Order_Product { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Delivery> Delivery { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();
        product.HasKey(x => x.Id);
        product.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        product.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        product.Property(x => x.Suggested_Price).HasColumnName("suggested_price").HasColumnType("decimal").IsRequired();

        var category = modelBuilder.Entity<Category>();
        category.HasKey(x => x.Id);
        category.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        category.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        category.Property(x => x.Slug).HasColumnName("slug").HasColumnType("varchar(100)").IsRequired();

        modelBuilder.Entity<State>().HasData(
         StateSeed.Seed);
         
        var order_product = modelBuilder.Entity<Order_Product>();
        order_product.HasKey(x => x.Id);
        order_product.Property(x => x.Orders).HasColumnName("order_id").IsRequired();
        order_product.Property(x => x.Products).HasColumnName("product_id").IsRequired();
        order_product.Property(x => x.Unit_Price).HasColumnName("unit_price").HasColumnType("decimal").IsRequired();
        order_product.Property(x => x.Amount).HasColumnName("amount").HasColumnType("int").IsRequired();

        var order = modelBuilder.Entity<Order>();
        order.HasKey(x => x.Id);
        order.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        order.Property(x => x.User).HasColumnName("user_id").IsRequired();
        order.Property(x => x.Seller).HasColumnName("seller_id").IsRequired();
        order.Property(x => x.Date_Order).HasColumnName("date_order").HasColumnType("date").IsRequired();
        order.Property(x => x.Shipping_Company).HasColumnName("shipping_Company").IsRequired();
        order.Property(x => x.Shipping_Company_Price).HasColumnName("shipping_company_price").HasColumnType("decimal").IsRequired();

        var delivery = modelBuilder.Entity<Delivery>();
        delivery.HasKey(x => x.Id);
        delivery.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        delivery.Property(x => x.Order).HasColumnName("order_id").IsRequired();
        delivery.Property(x => x.Address).HasColumnName("address_id").IsRequired();
        delivery.Property(x => x.Delivery_Forecast).HasColumnName("delivery_Forecast").HasColumnType("date").IsRequired();
        delivery.Property(x => x.Delivery_Date).HasColumnName("delivery_Date").HasColumnType("date");
        delivery.Property(x => x.Status).HasColumnName("status").HasColumnType("int").IsRequired();

    }
}
