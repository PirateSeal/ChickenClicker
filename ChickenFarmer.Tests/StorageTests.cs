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
            farm.Buildings.Build<Storage>( 1, 1 ,Storage.StorageType.Seeds);

            Assert.That(farm.Buildings.FindStorageByType(Storage.StorageType.Seeds).Capacity == 1000);
        }

        [TestCase(150, Storage.StorageType.Seeds)]
        [TestCase(150, Storage.StorageType.Vegetables)]
        [TestCase(150, Storage.StorageType.Meat)]
        public void Buy_Food(int amount, Storage.StorageType storageType)
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>( 1, 1 ,storageType);

            switch (storageType)
            {
                case Storage.StorageType.Seeds:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Buildings.FindStorageByType(Storage.StorageType.Seeds).Capacity == farm.Options.DefaultSeedCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.SeedPrice));
                    break;
                case Storage.StorageType.Vegetables:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).Capacity == farm.Options.DefaultVegetableCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.VegetablePrice));
                    break;
                case Storage.StorageType.Meat:
                    farm.Market.BuyFood(amount, storageType);
                    Assert.That(farm.Buildings.FindStorageByType(Storage.StorageType.Meat).Capacity == farm.Options.DefaultMeatCapacity + amount);
                    Assert.That(farm.Money == (5000 - amount * farm.Options.MeatPrice));
                    break;
                default:
                    Assert.Throws<ArgumentException>(() => farm.Market.BuyFood(150, storageType));
                    break;
            }
        }

        [TestCase(Storage.StorageType.Seeds)]
        [TestCase(Storage.StorageType.Vegetables)]
        [TestCase(Storage.StorageType.Meat)]
        [TestCase(Storage.StorageType.Eggs)]
        public void Upgrade_All_Storages(Storage.StorageType storageType)
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Storage>( 1, 1 , storageType);
            Storage storage = farm.Buildings.FindStorageByType(storageType);


            switch (storageType)
            {
                case Storage.StorageType.Seeds:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.StorageLevel))));
                    Assert.That(storage.MaxCapacity == 20000);
                    break;
                case Storage.StorageType.Vegetables:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.StorageLevel))));
                    Assert.That(storage.MaxCapacity == 20000);
                    break;
                case Storage.StorageType.Meat:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.StorageLevel))));
                    Assert.That(storage.MaxCapacity == 20000);
                    break;
                case Storage.StorageType.Eggs:
                    farm.Market.UpgradeStorage(storageType);
                    Assert.That(farm.Money == (5000 - (farm.Options.DefaultStorageUpgradeCost * (storage.StorageLevel))));
                    Assert.That(storage.MaxCapacity == 10000);
                    break;
                default:
                    Assert.Throws<ArgumentException>(() => farm.Market.UpgradeStorage(storageType));
                    break;
            }
        }
    }
}
