using DevInSales.Models;
using DevInSales.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Context;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }

    public DbSet<City> City { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Address> Address { get; set; }

    public DbSet<OrderProduct> Order_Product { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Delivery> Delivery { get; set; }
    public DbSet<CityPrice> CityPrice { get; set; }
    public DbSet<StatePrice> StatePrice { get; set; }
    public DbSet<ShippingCompany> ShippingCompany { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();
        product.HasKey(x => x.Id);
        product.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        product.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        product.Property(x => x.Suggested_Price).HasColumnName("suggested_price").HasColumnType("decimal").HasPrecision(18, 2).IsRequired();

        var category = modelBuilder.Entity<Category>();
        category.HasKey(x => x.Id);
        category.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        category.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        category.Property(x => x.Slug).HasColumnName("slug").HasColumnType("varchar(100)").IsRequired();

        modelBuilder.Entity<State>().HasData(StateSeed.Seed);

        modelBuilder.Entity<City>().HasData(CitySeed.Seed());

        modelBuilder.Entity<Address>().HasData(AddressSeed.Seed);

        modelBuilder.Entity<Category>().HasData(CategorySeed.Seed);

        modelBuilder.Entity<Profile>().HasData(ProfileSeed.Seed);

        modelBuilder.Entity<User>().HasData(UserSeed.Seed);

        modelBuilder.Entity<Product>().HasData(ProductSeed.Seed);

        modelBuilder.Entity<ShippingCompany>().HasData(ShippingCompanySeed.Seed);

        modelBuilder.Entity<StatePrice>().HasData(StatePriceSeed.Seed);

        modelBuilder.Entity<CityPrice>().HasData(CityPriceSeed.Seed);


        var order_product = modelBuilder.Entity<OrderProduct>();
        order_product.HasKey(x => x.Id);
        order_product.Property(x => x.Unit_Price).HasColumnName("unit_price").HasColumnType("decimal").IsRequired();
        order_product.Property(x => x.Amount).HasColumnName("amount").HasColumnType("int").IsRequired();

        var order = modelBuilder.Entity<Order>();
        order.HasKey(x => x.Id);
        order.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        order.Property(x => x.Date_Order).HasColumnName("date_order").HasColumnType("date").IsRequired();
        //order.Property(x => x.Shipping_Company).HasColumnName("shipping_Company").IsRequired();
        order.Property(x => x.Shipping_Company_Price).HasColumnName("shipping_company_price").HasColumnType("decimal").IsRequired();
        order.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);

        var delivery = modelBuilder.Entity<Delivery>();
        delivery.HasKey(x => x.Id);
        delivery.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        delivery.Property(x => x.Delivery_Forecast).HasColumnName("delivery_Forecast").HasColumnType("date").IsRequired();
        delivery.Property(x => x.Delivery_Date).HasColumnName("delivery_Date").HasColumnType("date");
        delivery.Property(x => x.Status).HasColumnName("status").HasColumnType("int").IsRequired();

        var state_price = modelBuilder.Entity<StatePrice>();
        state_price.HasKey(x => x.Id);
        state_price.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        state_price.Property(x => x.BasePrice).HasColumnName("base_price").HasColumnType("decimal").IsRequired();

        var shipping_company = modelBuilder.Entity<ShippingCompany>();
        shipping_company.HasKey(x => x.Id);
        shipping_company.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        shipping_company.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(255);

        var city_price = modelBuilder.Entity<CityPrice>();
        city_price.HasKey(x => x.Id);
        city_price.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        city_price.Property(x => x.BasePrice).HasColumnName("base_price").HasColumnType("decimal").IsRequired();

    }
}
