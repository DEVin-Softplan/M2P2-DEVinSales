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
    }

}


