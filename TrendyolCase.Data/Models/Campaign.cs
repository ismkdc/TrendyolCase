using System;
using System.Collections.Generic;
using System.Text;

namespace TrendyolCase.Data.Models
{
    public class Campaign
    {
        public Campaign(Category category, double amount, int minItemCount, DiscountType discountType)
        {
            Id = Guid.NewGuid();
            Category = category;
            Amount = amount;
            MinItemCount = minItemCount;
            DiscountType = discountType;
        }
        public Guid Id { get; private set; }
        public Category Category { get; set; }
        public double Amount { get; set; }
        public int MinItemCount { get; set; }
        public DiscountType DiscountType { get; set; }

    }
}
