using ChickenFarmer.Model;
using NUnit.Framework;
using System;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class StorageTests
    {
        [Test]
        public void Create_Storage_On_Farm_Creation()
        {
            Farm farm = new Farm();

            Assert.That(farm.Storage.SeedCapacity == 1000);
        }

        [TestCase(150, Market.StorageType.Seed)]
        [TestCase(150, Market.StorageType.Vegetable)]
        [TestCase(150, Market.StorageType.Meat)]
        [TestCase(150, Market.StorageType.None)]
        public void Buy_Food(int amount, Market.StorageType storageType)
        {
            Farm farm = new Farm { Money = 5000 };

            switch (storageType)
            {
                case Market.StorageType.Seed:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Storage.SeedCapacity == farm.Options.DefaultSeedCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.SeedPrice));
                    break;
                case Market.StorageType.Vegetable:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Storage.VegetableCapacity == farm.Options.DefaultVegetableCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.VegetablePrice));
                    break;
                case Market.StorageType.Meat:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Storage.MeatCapacity == farm.Options.DefaultMeatCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.MeatPrice));
                    break;
                default:
                    Assert.Throws<ArgumentException>(() => farm.Market.BuyFood(150, storageType));
                    break;
            }
        }

        [TestCase(Market.StorageType.Seed)]
        [TestCase(Market.StorageType.Vegetable)]
        [TestCase(Market.StorageType.Meat)]
        [TestCase(Market.StorageType.Egg)]
        [TestCase(Market.StorageType.None)]
        public void Upgrade_All_Storages(Market.StorageType storageType)
        {
            Farm farm = new Farm { Money = 5000 };
            Storage storage = farm.Storage;


            switch (storageType)
            {
                case Market.StorageType.Seed:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.SeedCapacityLevel))));
                    Assert.That(storage.SeedMaxCapacity == 20000);
                    break;
                case Market.StorageType.Vegetable:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.VegetableCapacityLevel))));
                    Assert.That(storage.VegetableMaxCapacity == 20000);
                    break;
                case Market.StorageType.Meat:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.MeatCapacityLevel))));
                    Assert.That(storage.MeatMaxCapacity == 20000);
                    break;
                case Market.StorageType.Egg:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.EggCapacityLevel))));
                    Assert.That(storage.EggMaxCapacity == 10000);
                    break;
                default:
                    Assert.Throws<ArgumentException>(() => farm.Market.UpgradeStorage(storageType));
                    break;
            }
        }
    }
}
