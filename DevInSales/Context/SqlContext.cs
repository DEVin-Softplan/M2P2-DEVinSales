using DevInSales.Models;
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

        var state = modelBuilder.Entity<State>();
        state.HasKey(x => x.Id);
        state.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        state.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        state.Property(x => x.Initials).HasColumnName("initials").HasColumnType("varchar(2)").IsRequired();

        var city = modelBuilder.Entity<City>();
        city.HasKey(x => x.Id);
        city.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        city.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
        city.Property(x => x.State_Id).HasColumnName("state_id").HasColumnType("int").IsRequired();
        
        var address = modelBuilder.Entity<Address>();
        address.HasKey(x => x.Id);
        address.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        address.Property(x => x.Street).HasColumnName("street").HasColumnType("varchar(200)").IsRequired();
        address.Property(x => x.Complement).HasColumnName("complement").HasColumnType("varchar(200)");
        address.Property(x => x.CEP).HasColumnName("CEP").HasColumnType("varchar(9)").IsRequired();
        address.Property(x => x.Number).HasColumnName("number").HasColumnType("int").IsRequired();
        address.Property(x => x.City_Id).HasColumnName("city_id").HasColumnType("int").IsRequired();
          
    }

}


