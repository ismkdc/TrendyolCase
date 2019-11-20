using NUnit.Framework;
using TrendyolCase.Business.Services;
using TrendyolCase.Data.Models;

namespace TrendyolCase.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTotalAmountTest()
        {
            var fruits = new Category("fruits");
            var apple = new Product("apple", 5M, fruits);

            var cart = new ShoppingCart();
            cart.AddItem(apple, 2);

            Assert.AreEqual(10, cart.GetTotalAmount());
        }

        [Test]
        public void CalculateCampaignDiscount()
        {
            var fruits = new Category("fruits");
            var apple = new Product("apple", 5M, fruits);

            var campaign1 = new Campaign(fruits, 10, 2, DiscountType.Amount);

            var cart = new ShoppingCart();
            cart.AddItem(apple, 2);
            cart.ApplyDiscounts(campaign1);

            Assert.AreEqual(10, cart.GetCampaignDiscount());
        }

        [Test]
        public void CalculateCouponDiscount()
        {
            var fruits = new Category("fruits");
            var apple = new Product("apple", 5M, fruits);

            var coupon1 = new Coupon(1M, 0.1, DiscountType.Rate);

            var cart = new ShoppingCart();
            cart.AddItem(apple, 2);
            cart.ApplyCoupon(coupon1);

            Assert.AreEqual(1, cart.GetCouponDiscount());
        }

        [Test]
        public void CalculateTotalPriceAfterDiscounts()
        {
            var fruits = new Category("fruits");
            var apple = new Product("apple", 5M, fruits);

            var campaign1 = new Campaign(fruits, 5, 2, DiscountType.Amount);
            var coupon1 = new Coupon(1M, 0.1, DiscountType.Rate);

            var cart = new ShoppingCart();
            cart.AddItem(apple, 2);
            cart.ApplyDiscounts(campaign1);
            cart.ApplyCoupon(coupon1);

            Assert.AreEqual(4.5, cart.GetTotalAmountAfterDiscounts());
        }
    }
}