#region Usings

using System;
using System.Reflection;
using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    public class StorageTests
    {
        [TestCase(150, typeof(StorageSeed))]
        [TestCase(150, typeof(StorageVegetable))]
        [TestCase(150, typeof(StorageMeat))]
        [TestCase(150, typeof(StorageEgg))]
        public void Buy_Food(int amount, Type type)
        {
            Type testsType = typeof(StorageTests);
            MethodInfo method = testsType.GetMethod(nameof(Buy_Food), BindingFlags.NonPublic | BindingFlags.Instance,
                null, new[] { typeof(int) }, null);
            method = method?.MakeGenericMethod(type);
            method?.Invoke(this, new object[] { amount });
        }

        private void Buy_Food<TStorageType>(int amount) where TStorageType : IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<ChickenStore>(1, 2);

            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyFood<TStorageType>(amount);
            IStorage storage = farm.Buildings.FindStorage<TStorageType>();
            Assert.That(storage.Capacity, Is.EqualTo(storage.Factory.DefaultCapacity + amount));
            Assert.That(farm.Money == 5000 - amount * storage.Value);
        }

        [TestCase(typeof(StorageSeed))]
        [TestCase(typeof(StorageVegetable))]
        [TestCase(typeof(StorageMeat))]
        [TestCase(typeof(StorageEgg))]
        public void Upgrade_All_Storages(Type type)
        {
            Type testsType = typeof(StorageTests);
            MethodInfo method = testsType.GetMethod(nameof(Upgrade_All_Storages),
                BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(int) }, null);
            method = method?.MakeGenericMethod(type);
            method?.Invoke(this, null);
        }

        private void Upgrade_All_Storages<TStorageType>() where TStorageType : class, IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<Builder>(1, 2);
            TStorageType storage = farm.Buildings.FindBuilding<TStorageType>(1, 1);
            FarmOptions.DefaultBuildingPrices.TryGetValue(typeof(TStorageType), out int price);

            farm.Buildings.FindBuilding<Builder>(1, 2).
                UpgradeBuilding(storage);
            Assert.That(farm.Money, Is.EqualTo(5000 - price * farm.Buildings.FindBuilding<TStorageType>(1, 1).
                                                   Lvl));
            Assert.That(storage.MaxCapacity, Is.EqualTo(20000));
        }

        [Test]
        public void Create_Storage_On_Farm_Creation()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<StorageSeed>(1, 1);

            Assert.That(farm.Buildings.FindStorage<StorageSeed>().
                Capacity, Is.EqualTo(0));
        }
    }
}