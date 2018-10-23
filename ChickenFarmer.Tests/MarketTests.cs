using ChickenFarmer.Model;
using NUnit.Framework;
using System;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class MarketTests
    {
        [Test]
        public void Upgrade_Henhouse()
        {
            Farm farm = new Farm();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.UpgradeHouse(henhouse);

            Assert.That(henhouse.Lvl == 2);
        }

        [Test]
        public void Buy_Chicken()
        {
            Farm farm = new Farm();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 10, 0);

            Assert.That(henhouse.ChickenCount == 10);
            Console.WriteLine(henhouse.ChickenCount + " : " + 10);
            Assert.That(farm.Money == (5000 - (Model.Enum.Market.DefaultChickenCost[0] * 10)));
        }

        [Test]
        public void Buy_Chicken_Without_Enough_Money()
        {
            Farm farm = new Farm();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            farm.Money = 2;

            Assert.That(farm.Market.BuyChicken(henhouse, 10, 0) == false);
        }

        [Test]
        public void Buy_Too_Much_Chicken()
        {
            Farm farm = new Farm();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            farm.Money = 5000;

            farm.Market.BuyChicken(henhouse, 20, 0);

            Assert.That(henhouse.ChickenCount == 20);
            Console.WriteLine(henhouse.ChickenCount + " : " + 20);
            Assert.That(farm.Money == (5000 - (Model.Enum.Market.DefaultChickenCost[0] * 20)));
        }
    }
}
