#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class ChickenTests
    {
        [Test]
        public void Chicken_Starve_To_Death()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>(1, 1, Storage.StorageType.Seeds);
            farm.Buildings.Build<Storage>(1, 3, Storage.StorageType.Eggs);
            farm.Market.BuyHenhouse(1, 2);

            farm.Market.BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 2000; i ++) farm.Update();

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(0));
        }

        [Test]
        public void Create_Chicken()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>(1, 2, Storage.StorageType.Seeds);
            farm.Market.BuyHenhouse(1, 4);

            farm.Market.BuyChicken(5, Chicken.Breed.Tier1);

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(5));
            Assert.That(farm.Money,
                Is.EqualTo(5000 - (farm.Options.DefaultChickenCost[0] * 5 +
                                   farm.Options.DefaultHenHouseCost)));
        }

        [Test]
        public void Feed_All_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>(1, 1,Storage.StorageType.Seeds);
            farm.Buildings.Build<Storage>(1, 3,Storage.StorageType.Eggs);
            farm.Buildings.Build<Henhouse>(1, 2);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 2);

            farm.Market.BuyFood(500, Storage.StorageType.Seeds);
            farm.Market.BuyChicken(5, Chicken.Breed.Tier1);
            for (int i = 0; i < 85; i ++) farm.Update();

            house.FeedAllChicken();

            foreach ( Chicken chicken in house.Chikens )
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            Assert.That(farm.Buildings.
                FindStorageByType(Storage.StorageType.Seeds).
                Capacity, Is.Not.EqualTo(500));
        }

        [Test]
        public void Feed_All_Dying_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>(1, 1,Storage.StorageType.Seeds);
            farm.Buildings.Build<Storage>(1, 3,Storage.StorageType.Eggs);
            farm.Buildings.Build<Henhouse>(1, 2);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 2);

            farm.Market.BuyFood(500, Storage.StorageType.Seeds);
            farm.Market.BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 850; i ++) farm.Update();

            house.FeedAllDyingChicken();

            foreach ( Chicken chicken in house.Chikens )
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            Assert.That(house.CountDyingChickens, Is.EqualTo(0));
            Assert.That(farm.Buildings.
                FindStorageByType(Storage.StorageType.Seeds).
                Capacity, Is.Not.EqualTo(500));
        }
    }
}