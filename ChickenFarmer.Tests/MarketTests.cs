#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class MarketTests
    {
        [Test]
        public void Buy_Chicken()
        {
            Farm farm = new Farm { Money = 50000 };
            farm.Buildings.Build<Henhouse>( 1, 1 );
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>( 1, 1 );

            farm.Market.BuyChicken( 9, Chicken.Breed.Tier1 );

            Assert.That( house.ChickenCount, Is.EqualTo( 9 ) );
            Assert.That( farm.Money ==
                         50000 - farm.Options.DefaultChickenCost[( int ) Chicken.Breed.Tier1 - 1] *
                         9 );
        }

        [Test]
        public void Buy_Chicken_Without_Enough_Money()
        {
            Farm farm = new Farm { Money = 2 };
            farm.Buildings.Build<Henhouse>( 1, 1 );

            farm.Market.BuyChicken( 5, Chicken.Breed.Tier1 );

            Assert.That( farm.Buildings.ChickenCount(), Is.EqualTo( 0 ) );
        }

        [Test]
        public void Buy_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Market.BuyHenhouse( 1, 1 );

            Assert.That( farm.Money, Is.EqualTo( 5000 - farm.Options.DefaultHenHouseCost ) );
            Assert.That( farm.Buildings.Buildings.Count, Is.EqualTo( 1 ) );
            Assert.That( farm.Buildings.CountNbrBuilding<Henhouse>(), Is.EqualTo( 1 ) );
        }

        [Test]
        public void Buy_Too_Much_Chicken()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Henhouse>( 1, 1 );

            farm.Market.BuyChicken( 15, Chicken.Breed.Tier1 );

            Assert.That( farm.Buildings.ChickenCount(), Is.EqualTo( 10 ) );
            Assert.That( farm.Money,
                Is.EqualTo( 5000 - 10 *
                            farm.Options.DefaultChickenCost[( int ) Chicken.Breed.Tier1 - 1] ) );
        }

        [Test]
        public void Cant_Buy_Henhouse_With_NoMoney()
        {
            Farm farm = new Farm { Money = 15 };

            farm.Market.BuyHenhouse( 1, 1 );

            Assert.That(farm.Money,Is.EqualTo(15));
            Assert.That(farm.Buildings.Buildings.Count, Is.EqualTo(0));
        }

        [Test]
        public void Sell_Eggs()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<Storage>( 1, 1 );
            farm.Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity= 500;

            Market.Sellegg(farm);

            Assert.That(farm.Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity,Is.EqualTo(0));
            Assert.That(farm.Money,Is.EqualTo(1100));
        }

        [Test]
        public void Upgrade_Henhouse()
        {
            Farm farm = new Farm { Money = 50000 };
            farm.Buildings.Build<Henhouse>(1, 1);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 1);
            int lvl = farm.Buildings.FindBuilding<Henhouse>(1, 1).Lvl;

            farm.Market.UpgradeHouse(house);

            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 1).Lvl > lvl);
            Assert.That(farm.Money,
                Is.EqualTo(50000 - farm.Options.UpgradeHouseCost * house.Lvl));
        }
    }
}