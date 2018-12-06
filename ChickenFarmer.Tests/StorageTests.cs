using ChickenFarmer.Model;
using NUnit.Framework;
using System;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class StorageTests
    {
        [Test]
        public void Create_Storage_On_Farm_Creation()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<SeedStorage>(1, 1);

            Assert.That(farm.Buildings.FindStorage<SeedStorage>().Capacity, Is.EqualTo(1000));
        }

        /*[TestCase(150, SeedStorage)]
        [TestCase(150, VegetableStorage)]
        [TestCase(150, MeatStorage)]
        public void Buy_Food<TStorageType>(int amount) where TStorageType : IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<Market>(1, 2);

            if (typeof(TStorageType) == typeof(IStorage))
            {
                farm.Buildings.FindBuilding<Market>(1, 2).BuyFood<TStorageType>(amount);
                Assert.That(farm.Buildings.FindStorage<TStorageType>().Capacity == FarmOptions.DefaultSeedCapacity + amount);
                Assert.That(farm.Money == (5000 - amount * FarmOptions.SeedPrice));
            }
            else Assert.Throws<ArgumentException>(() => farm.Buildings.FindBuilding<Market>(1, 2).BuyFood<TStorageType>(150));
        }

        [TestCase(SeedStorage)]
        [TestCase(VegetableStorage)]
        [TestCase(MeatStorage)]
        [TestCase(EggStorage)]
        public void Upgrade_All_Storages<TStorageType>() where TStorageType : class, IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<Market>(1, 2);

            if (typeof(TStorageType) == typeof(IStorage))
            {
                farm.Buildings.FindBuilding<Market>(1, 2).UpgradeStorage<TStorageType>();
                Assert.That(farm.Money == 5000 - FarmOptions.DefaultStorageUpgradeCost * farm.Buildings.FindBuilding<TStorageType>(1, 1).Lvl);
                Assert.That(farm.Buildings.FindBuilding<TStorageType>(1, 1).MaxCapacity == 20000);
            }
            else Assert.Throws<ArgumentException>(() => farm.Buildings.FindBuilding<Market>(1, 2).UpgradeStorage<TStorageType>());
        }*/
    }
}
