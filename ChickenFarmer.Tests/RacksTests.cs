//using ChickenFarmer.Model;
//using NUnit.Framework;
//using System;
//using System.Reflection;

//namespace ChickenFarmer.Tests
//{
//    [TestFixture]
//    internal class RacksTests
//    {
//        [Test]
//        public void Init_On_Creation()
//        {
//            Farm farm = new Farm();

//            farm.Buildings.Build<Henhouse>(1, 1);
//            Henhouse henhouse = farm.Buildings.FindBuilding<Henhouse>(1, 1);

//            Assert.That(henhouse.Racks.Count, Is.EqualTo(3));
//            //Assert.That(henhouse.Racks.Find(rack => rack is SeedRack).Lvl, Is.EqualTo(1));
//            Assert.That(henhouse.Racks.Find(rack => rack is VegetableRack).Lvl, Is.EqualTo(0));
//            Assert.That(henhouse.Racks.Find(rack => rack is RackMeat).Lvl, Is.EqualTo(0));

//            Assert.That(henhouse.Racks.Find(rack => rack is SeedRack).CtxHenhouse, Is.EqualTo(henhouse));
//            Assert.That(henhouse.Racks.Find(rack => rack is SeedRack).Capacity, Is.EqualTo(0));
//            Assert.That(henhouse.Racks.Find(rack => rack is SeedRack).MaxCapacity, Is.EqualTo(500));
//        }

//        [TestCase(150, typeof(SeedRack))]
//        [TestCase(150, typeof(VegetableRack))]
//        [TestCase(150, typeof(RackMeat))]
//        public void Fill_Rack(int amount, Type rackType)
//        {
//            Type testsType = typeof(RacksTests);
//            MethodInfo method = testsType.GetMethod(nameof(Fill_Rack),
//                BindingFlags.NonPublic | BindingFlags.Instance, null,
//                new[] { typeof(int) }, null);
//            method = method?.MakeGenericMethod(rackType);
//            method?.Invoke(this, new object[] { amount });
//        }

//        [Test]
//        private void Fill_Rack<TRackType>(int amount) where TRackType : IRack
//        {
//            Farm farm = new Farm();
//            farm.Buildings.Build<SeedStorage>(1, 1);
//            farm.Buildings.Build<VegetableStorage>(1, 2);
//            farm.Buildings.Build<MeatStorage>(1, 3);

//            farm.Buildings.FindStorage<SeedStorage>().
//                Capacity = amount;
//            farm.Buildings.Build<Henhouse>(1, 2);
//            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 2);

//            house.FillRack<SeedRack>(amount);

//            Assert.That(farm.Buildings.FindStorage<SeedStorage>().Capacity, Is.EqualTo(0));
//            Assert.That(house.Racks.Find(rack => rack is SeedRack).Capacity, Is.EqualTo(150));
//        }
//    }
//}
