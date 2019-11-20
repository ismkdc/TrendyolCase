using System;
using System.Collections.Generic;
using System.Text;

namespace TrendyolCase.Data.Models
{
    public class Category
    {
        public Category(string title, Category parent = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            Parent = parent;
        }
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public Category Parent { get; set; }
    }
}
