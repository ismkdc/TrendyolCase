using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendyolCase.Data.Models;

namespace TrendyolCase.Business.Extensions
{
    public static class CampaignExtensions
    {
        public static decimal Apply(this Campaign campaign, IEnumerable<(Product product, int quantity)> products)
        {
            //if item quantitiy lower than campaign rule dont apply discount
            if (campaign.MinItemCount > products.Sum(x => x.quantity))
                return 0.0M;

            return campaign.DiscountType switch
            {
                DiscountType.Rate => (decimal)campaign.Amount * products.Sum(x => x.product.Price * x.quantity),
                DiscountType.Amount => (decimal)campaign.Amount,
                _ => 0.0M,
            };
        }
    }
}
