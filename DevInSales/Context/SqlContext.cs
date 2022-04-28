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


        modelBuilder.Entity<State>().HasData(
          new State
          {
              Id = 11,
              Name = "Rond�nia",
              Initials = "RO"
          },
          new State
          {
              Id = 12,
              Name = "Acre",
              Initials = "AC"
          },
          new State
          {
              Id = 13,
              Name = "Amazonas",
              Initials = "AM"
          },
          new State
          {
              Id = 14,
              Name = "Roraima",
              Initials = "RR"
          },
          new State
          {
              Id = 15,
              Name = "Par�",
              Initials = "PA"
          },
          new State
          {
              Id = 16,
              Name = "Amap�",
              Initials = "AP"
          },
          new State
          {
              Id = 17,
              Name = "Tocantins",
              Initials = "TO"
          },
          new State
          {
              Id = 21,
              Name = "Maranh�o",
              Initials = "MA"
          },
          new State
          {
              Id = 22,
              Name = "Piau�",
              Initials = "PI"
          },
          new State
          {
              Id = 23,
              Name = "Cear�",
              Initials = "CE"
          },
          new State
          {
              Id = 24,
              Name = "Rio Grande do Norte",
              Initials = "RN"
          },
          new State
          {
              Id = 25,
              Name = "Paraíba",
              Initials = "PB"
          },
          new State
          {
              Id = 26,
              Name = "Pernanmbuco",
              Initials = "PE"
          },
          new State
          {
              Id = 27,
              Name = "Alagoas",
              Initials = "AL"
          },
          new State
          {
              Id = 28,
              Name = "Sergipe",
              Initials = "SE"
          },
          new State
          {
              Id = 29,
              Name = "Bahia",
              Initials = "BA"
          },
          new State
          {
              Id = 31,
              Name = "Minas Gerais",
              Initials = "MG"
          },
          new State
          {
              Id = 32,
              Name = "Espirito Santo",
              Initials = "ES"
          },
          new State
          {
              Id = 33,
              Name = "Rio de Janeiro",
              Initials = "RJ"
          },
          new State
          {
              Id = 35,
              Name = "São Paulo",
              Initials = "SP"
          },
          new State
          {
              Id = 41,
              Name = "Paran�",
              Initials = "PR"
          },
          new State
          {
              Id = 42,
              Name = "Santa Catarina",
              Initials = "SC"
          },
          new State
          {
              Id = 43,
              Name = "Rio Grande do Sul",
              Initials = "RS"
          },
          new State
          {
              Id = 50,
              Name = "Mato Grosso do Sul",
              Initials = "MS"
          },
          new State
          {
              Id = 51,
              Name = "Mato Grosso",
              Initials = "MT"
          },
          new State
          {
              Id = 52,
              Name = "Goias",
              Initials = "GO"
          },
          new State
          {
              Id = 53,
              Name = "Distrito Federal",
              Initials = "DF"
          });
          
    }

}


