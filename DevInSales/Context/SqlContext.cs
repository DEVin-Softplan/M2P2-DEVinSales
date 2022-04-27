using DevInSales.Models;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Context;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }


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
    }
} 