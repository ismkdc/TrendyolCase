using System;
using System.Collections.Generic;
using System.Text;

namespace TrendyolCase.Data.Models
{
    public class Coupon
    {
        public Coupon(decimal minPurchase, double amount, DiscountType discountType)
        {
            Id = Guid.NewGuid();
            MinPurchase = minPurchase;
            Amount = amount;
            DiscountType = discountType;
        }
        public Guid Id { get; private set; }
        public double Amount { get; set; }
        public decimal MinPurchase { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}
