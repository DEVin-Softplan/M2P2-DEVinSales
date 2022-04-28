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
}