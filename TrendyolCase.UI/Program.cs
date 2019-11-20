using System;
using TrendyolCase.Business.Services;
using TrendyolCase.Data.Models;

namespace TrendyolCase.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //lets add some examples
            var cart = new ShoppingCart();
            var deliveryCostCalculator = new DeliveryCostCalculator(2, 5, 3);

            var fruits = new Category("fruits");
            var cars = new Category("cars");

            var apple = new Product("apple", 5M, fruits);
            var orange = new Product("orange", 7M, fruits);

            var tofas = new Product("tofas", 5000m, cars);

            var campaign1 = new Campaign(fruits, 10, 2, DiscountType.Amount);
            var campaign2 = new Campaign(fruits, 0.9, 2, DiscountType.Rate);

            var coupon1 = new Coupon(1000M, 0.1, DiscountType.Rate);

            cart.AddItem(orange, 1);
            cart.AddItem(apple, 1);
            cart.AddItem(tofas, 2);

            cart.ApplyDiscounts(campaign1, campaign2);
            cart.ApplyCoupon(coupon1);
            
            //print all things
            Console.WriteLine(cart.Print(deliveryCostCalculator));
            Console.ReadKey();
        }
    }
}
