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
        [TestCase(150, typeof(SeedStorage))]
        [TestCase(150, typeof(VegetableStorage))]
        [TestCase(150, typeof(MeatStorage))]
        [TestCase(150, typeof(EggStorage))]
        public void Buy_Food(int amount, Type type)
        {
            Type testsType = typeof(StorageTests);
            MethodInfo method = testsType.GetMethod(nameof(Buy_Food),
                BindingFlags.NonPublic | BindingFlags.Instance, null,
                new[] { typeof(int) }, null);
            method = method?.MakeGenericMethod(type);
            method?.Invoke(this, new object[] { amount });
        }

        private void Buy_Food<TStorageType>(int amount)
            where TStorageType : IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<Market>(1, 2);

            farm.Buildings.FindBuilding<Market>(1, 2).
                BuyFood<TStorageType>(amount);
            IStorage storage = farm.Buildings.FindStorage<TStorageType>();
            Assert.That(storage.Capacity,
                Is.EqualTo(storage.Factory.DefaultCapacity + amount));
            Assert.That(farm.Money == 5000 - amount * storage.Value);
        }

        [TestCase(typeof(SeedStorage))]
        [TestCase(typeof(VegetableStorage))]
        [TestCase(typeof(MeatStorage))]
        [TestCase(typeof(EggStorage))]
        public void Upgrade_All_Storages(Type type)
        {
            Type testsType = typeof(StorageTests);
            MethodInfo method = testsType.GetMethod(
                nameof(Upgrade_All_Storages),
                BindingFlags.NonPublic | BindingFlags.Instance, null,
                new[] { typeof(int) }, null);
            method = method?.MakeGenericMethod(type);
            method?.Invoke(this, null);
        }

        private void Upgrade_All_Storages<TStorageType>()
            where TStorageType : class, IStorage
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<TStorageType>(1, 1);
            farm.Buildings.Build<Market>(1, 2);

            if ( typeof(TStorageType) == typeof(IStorage) )
            {
                farm.Buildings.FindBuilding<Market>(1, 2).
                    UpgradeStorage<TStorageType>();
                Assert.That(farm.Money == 5000 -
                            FarmOptions.DefaultStorageUpgradeCost * farm.
                                Buildings.FindBuilding<TStorageType>(1, 1).
                                Lvl);
                Assert.That(farm.Buildings.FindBuilding<TStorageType>(1, 1).
                                MaxCapacity == 20000);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => farm.Buildings.
                    FindBuilding<Market>(1, 2).
                    UpgradeStorage<TStorageType>());
            }
        }

        [Test]
        public void Create_Storage_On_Farm_Creation()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<SeedStorage>(1, 1);

            Assert.That(farm.Buildings.FindStorage<SeedStorage>().
                Capacity, Is.EqualTo(1000));
        }
    }
}