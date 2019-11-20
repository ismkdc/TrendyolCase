using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendyolCase.Data.Models;

namespace TrendyolCase.Business.Extensions
{
    public static class CouponExtensions
    {
        public static decimal Apply(this Coupon coupon, decimal totalPrice)
        {
            //if totalprice lower than coupon rule dont apply discount
            if (coupon.MinPurchase > totalPrice)
                return 0.0M;

            return coupon.DiscountType switch
            {
                DiscountType.Rate => (decimal)coupon.Amount * totalPrice,
                DiscountType.Amount => (decimal)coupon.Amount,
                _ => 0.0M,
            };
        }
    }
}
