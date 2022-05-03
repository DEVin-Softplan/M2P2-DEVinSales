using DevInSales.Models;

public class ProductSeed
{
    public static List<Product> Seed { get; set; } = new List<Product>() { new Product()
    {
        Id = 1,
        Name = "Curso de C Sharp",
        CategoryId = 1,
        Suggested_Price = 259.99M
    }, new Product()
    {
        Id = 2,
        Name = "Curso de Java",
        CategoryId = 1,
        Suggested_Price = 249.99M
    }, new Product()
    {
        Id = 3,
        Name = "Curso de Delphi",
        CategoryId = 1,
        Suggested_Price = 189.99M
    }, new Product()
    {
        Id = 4,
        Name = "Curso de React",
        CategoryId = 1,
        Suggested_Price = 289.99M
    }, new Product()
    {
        Id = 5,
        Name = "Curso de HTML5 e CSS3",
        CategoryId = 1,
        Suggested_Price = 139.99M
    }, new Product()
    {
        Id = 6,
        Name = "Curso de JavaScript",
        CategoryId = 1,
        Suggested_Price = 219.99M
    }, new Product()
    {
        Id = 7,
        Name = "Curso de Angular",
        CategoryId = 1,
        Suggested_Price = 199.99M
    }, new Product()
    {
        Id = 8,
        Name = "Curso de Ruby",
        CategoryId = 1,
        Suggested_Price = 319.99M
    }, new Product()
    {
        Id = 9,
        Name = "Curso de Kotlin",
        CategoryId = 1,
        Suggested_Price = 289.99M
    }, new Product()
    {
        Id = 10,
        Name = "Curso de Python",
        CategoryId = 1,
        Suggested_Price = 229.99M
    }
    };
}
