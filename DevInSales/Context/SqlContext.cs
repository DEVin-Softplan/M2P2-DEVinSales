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
        // método para realizar a configuração das entidades com o FluentAPI
    }
    }