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
            FarmOptions farmOptions = new FarmOptions();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            int Lvl = henhouse.Lvl;

            farm.Money = 5000;
            farm.Market.UpgradeHouse(henhouse);

            Assert.That(henhouse.Lvl > Lvl);
            Assert.That(farm.Money == (5000 - farmOptions.UpgradeHouseCost[0]));
        }

        [Test]
        public void Buy_Chicken()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();
            Henhouse henhouse = farm.Houses.Henhouses[0];

            farm.Money = 5000;
            farm.Market.BuyChicken(henhouse, 9, 0);

            Assert.That(henhouse.ChickenCount == 10);
            Assert.That(farm.Money == (5000 - (farmOptions.DefaultChickenCost[0] * 9)));
        }

        [Test]
        public void Buy_Chicken_Without_Enough_Money()
        {
            Farm farm = new Farm();
            Henhouse henhouse = farm.Houses.Henhouses[0];
            int initChicken = farm.Houses.Henhouses[0].ChickenCount;

            farm.Money = 2;
            farm.Market.BuyChicken(henhouse, 5, 0);

            Assert.That(farm.Houses.Henhouses[0].ChickenCount == initChicken);
        }

        [Test]
        public void Buy_Too_Much_Chicken()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();
            var henhouse = farm.Houses.Henhouses[0];
            int initChicken = henhouse.ChickenCount;

            farm.Money = 5000;
            farm.Market.BuyChicken(henhouse, 20, 0);
            int endChicken = henhouse.ChickenCount;

            Assert.That(henhouse.ChickenCount == henhouse.Limit);
            Assert.That(farm.Money == (5000 - (farmOptions.DefaultChickenCost[0] * (endChicken - initChicken) ) ) );
        }

        [Test]
        public void Sell_Eggs()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();

            farm.TotalEgg = 5000;
            farm.Money = 0;
            farm.Market.Sellegg(farm);

            Assert.That(farm.Money == 10000);
            Assert.That(farm.TotalEgg == 0);
        }
        
        [Test]
        public void Buy_Henhouse()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();
            int nbrHenhouse = farm.Houses.Count();

            farm.Money = 5000;
            farm.Market.BuyHenhouse();

            Assert.That(farm.Money == (5000 - farmOptions.DefaultHenHouseCost));
            Assert.That(farm.Houses.Count() > nbrHenhouse);
            Assert.That(farm.Houses.Count() == 2);
        }

        [Test]
        public void Cant_Buy_Henhouse_With_NoMoney()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();
            int nbrHenhouse = farm.Houses.Count();

            farm.Money = 125;
            farm.Market.BuyHenhouse();

            Assert.That(farm.Money == 125);
            Assert.That(farm.Houses.Count() == nbrHenhouse);
        }
    }
}
