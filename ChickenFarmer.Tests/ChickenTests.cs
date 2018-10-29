using ChickenFarmer.Model;
using NUnit.Framework;
using System;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class ChickenTests
    {
        [Test]
        public void Create_Chicken()
        {
            Farm farm = new Farm();
            var henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 1, 0);

            Assert.That(henhouse.ChickenCount == 1);
        }

        [Test]
        public void Chicken_Starve_To_Death()
        {
            Farm farm = new Farm();
            var henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 1, 0);
            for (int i = 0; i < 101; i++)
            {
                farm.update();
            }

            Assert.That(henhouse.ChickenCount == 0);
        }

        [Test]
        public void Feed_All_chicken()
        {
            Farm farm = new Farm();
            var henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 5, 0);
            for (int i = 0; i < 85; i++)
            {
                farm.update();
            }

            Console.WriteLine(farm.ChickenToFeed);
            farm.Market.BuyFood(60);
            farm.FeedAllChicken();

            farm.update();
            Console.WriteLine(farm.ChickenToFeed);
            foreach (var item in farm.Houses.Henhouses)
            {
                Assert.That(item.CountDyingChickens == 0);
            }
        }
    }
}
