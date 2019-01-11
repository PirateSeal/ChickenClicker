using ChickenFarmer.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class RacksTests
    {
        [Test]
        public void Init_On_Creation()
        {
            Farm farm = new Farm();

            farm.Buildings.Build<Henhouse>(1, 1);
            Henhouse henhouse = farm.Buildings.FindBuilding<Henhouse>(1, 1);

            Assert.That(henhouse.Racks.Count, Is.EqualTo(1));
        }

        [TestCase(150, typeof(RackSeed))]
        [TestCase(150, typeof(RackVegetable))]
        [TestCase(150, typeof(RackMeat))]
        public void Fill_Rack(int amount, Type rackType)
        {
            Type testsType = typeof(RacksTests);
            MethodInfo method = testsType.GetMethod(nameof(Fill_Rack),
                BindingFlags.NonPublic | BindingFlags.Instance, null,
                new[] { typeof(int) }, null);
            method = method?.MakeGenericMethod(rackType);
            method?.Invoke(this, new object[] { amount });
        }

        [Test]
        private void Fill_Rack<TRackType>(int amount) where TRackType : IRack
        {

            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageSeed>(1, 1);
            farm.Buildings.Build<StorageVegetable>(1, 2);
            farm.Buildings.Build<StorageMeat>(1, 3);
            farm.Buildings.Build<Builder>(1, 5);
            foreach (IBuilding building in farm.Buildings.BuildingList)
                if (building is IStorage storage)
                    storage.Capacity = amount;
            farm.Buildings.Build<Henhouse>(1, 4);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 4);
            Builder builder = farm.Buildings.FindBuilding<Builder>(1, 5);

            builder.BuyRack<TRackType>(house);
            house.FillRack<TRackType>(amount);

            if (typeof(TRackType) == typeof(RackSeed))
            {
                Assert.That(farm.Buildings.FindStorage<StorageSeed>().Capacity, Is.EqualTo(0));
                Assert.That(house.Racks.Find(rack => rack is RackSeed).Capacity, Is.EqualTo(150));
            }
            else if (typeof(TRackType) == typeof(RackVegetable))
            {
                Assert.That(farm.Buildings.FindStorage<StorageVegetable>().Capacity, Is.EqualTo(0));
                Assert.That(house.Racks.Find(rack => rack is RackVegetable).Capacity, Is.EqualTo(150));
            }
            else if (typeof(TRackType) == typeof(RackMeat))
            {
                Assert.That(farm.Buildings.FindStorage<StorageMeat>().Capacity, Is.EqualTo(0));
                Assert.That(house.Racks.Find(rack => rack is RackMeat).Capacity, Is.EqualTo(150));
            }
        }
    }
}
