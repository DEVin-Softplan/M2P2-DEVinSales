﻿namespace DevInSales.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
