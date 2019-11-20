using System;
using System.Collections.Generic;
using System.Text;

namespace TrendyolCase.Data.Models
{
    public class Product
    {
        public Product(string title, decimal price, Category category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
