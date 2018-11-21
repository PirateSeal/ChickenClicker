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

            Assert.That(henhouse.ChickenCount == 2);
        }

        [Test]
        public void Chicken_Starve_To_Death()
        {
            Farm farm = new Farm();
            var henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 1, 0);
            for (int i = 0; i < 2000; i++)
            {
                farm.Update();
            }

            Assert.That(henhouse.ChickenCount == 0);
        }

        [Test]
        public void Feed_All_chicken_In_One_Henhouse()
        {
            Farm farm = new Farm();
            var henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 5, 0);
            for (int i = 0; i < 85; i++)
            {
                farm.Update();
            }

            farm.Market.BuyFood(60,Market.StorageType.Seed);
            henhouse.FeedChicken();

            farm.Update();
            foreach (var item in farm.Houses.Henhouses)
            {
                Assert.That(item.CountDyingChickens == 0);
            }
        }
    }
}
