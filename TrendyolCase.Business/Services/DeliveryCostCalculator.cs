using System;
using System.Collections.Generic;
using System.Text;

namespace TrendyolCase.Business.Services
{
    public class DeliveryCostCalculator
    {
        #region props
        private double CostPerDelivery { get; set; }
        private double CostPerProduct { get; set; }
        private double FixedCost { get; set; }
        #endregion

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }

        //Formula is ( CostPerDelivery * NumberOfDeliveries ) + (CostPerProduct * NumberOfProducts) + Fixed Cost
        public double CalucateFor(ShoppingCart cart) => (CostPerDelivery * cart.GetNumberOfDeliveries())
            + (CostPerProduct * cart.GetNumberOfProducts())
            + FixedCost;
    }
}
