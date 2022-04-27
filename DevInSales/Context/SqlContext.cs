using DevInSales.Models;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Context;

public class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<order_product> order_product { get; set; }
    public DbSet<order> Order { get; set; }
    public DbSet<delivery> delivery { get; set; }
}