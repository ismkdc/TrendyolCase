using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendyolCase.Business.Extensions;
using TrendyolCase.Data.Models;

namespace TrendyolCase.Business.Services
{
    public class ShoppingCart
    {
        #region private variables
        private static List<(Product product, int quantity)> _products;
        #endregion

        #region ctor
        public ShoppingCart() => _products = new List<(Product product, int quantity)>();
        #endregion

        #region props
        private decimal TotalPrice => _products.Sum(x => x.product.Price * x.quantity);
        private decimal CampaignDiscount { get; set; }
        private decimal CouponDiscount { get; set; }
        #endregion

        #region methods
        public void AddItem(Product product, int quantity)
        {
            var existingProduct = _products.SingleOrDefault(x => x.product.Id == product.Id);
            //if product is existing increase quantitiy
            if (existingProduct != default((Product product, int quantity)))
                existingProduct.quantity += quantity;
            else
                _products.Add((product, quantity));
        }
        public void ApplyCoupon(Coupon coupon) => CouponDiscount += coupon.Apply(TotalPrice - CampaignDiscount);
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            CampaignDiscount += campaigns.Max(c => c.Apply(
                _products.Where(x => x.product.Category == c.Category)));
        }
        public decimal GetTotalAmount() => TotalPrice;
        public decimal GetTotalAmountAfterDiscounts() => TotalPrice - CampaignDiscount - CouponDiscount;
        public decimal GetCouponDiscount() => CouponDiscount;
        public decimal GetCampaignDiscount() => CampaignDiscount;
        public int GetNumberOfDeliveries() => _products.DistinctBy(x => x.product.Category.Id).Count();
        public int GetNumberOfProducts() => _products.DistinctBy(x => x.product.Id).Count();
        public double GetDeliveryCost(DeliveryCostCalculator deliveryCostCalculator) => deliveryCostCalculator.CalucateFor(this);
        public string Print(DeliveryCostCalculator deliveryCostCalculator)
        {
            var sb = new StringBuilder();
            foreach (var pair in _products.GroupBy(x => x.product.Category))
            {
                sb.AppendLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                sb.AppendLine($"CategoryName: {pair.Key.Title}");
                sb.AppendLine("------------------------------------");

                foreach (var product in pair)
                {
                    sb.AppendLine($"ProductName: {product.product.Title}");
                    sb.AppendLine($"Quantity: {product.quantity}");
                    sb.AppendLine($"UnitPrice: {product.product.Price}");
                    sb.AppendLine("<><><><><><><><><><><><><><><><><><>");
                }
                sb.AppendLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            sb.AppendLine($"TotalPrice: {GetTotalAmount()}");
            sb.AppendLine($"CouponDiscount: {GetCouponDiscount()}");
            sb.AppendLine($"CampaignDiscount: {GetCampaignDiscount()}");
            sb.AppendLine($"TotalPrice(After discounts): {GetTotalAmountAfterDiscounts()}");
            sb.AppendLine($"DeliveryCost: {GetDeliveryCost(deliveryCostCalculator)}");
            return sb.ToString();
        }
        #endregion
    }
}
