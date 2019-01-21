#region Usings

using System.IO;
using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class SerializationTests
    {
        [Test]
        public void Farm_Serialization()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Builder>(1, 1);
            farm.Buildings.Build<ChickenStore>(1, 2);
            farm.Buildings.Build<Henhouse>(1, 3);
            farm.Buildings.Build<StorageEgg>(1, 4);
            farm.Buildings.Build<StorageSeed>(1, 5);
            farm.Buildings.Build<Henhouse>(1, 6);
            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyChicken(5, Chicken.Breed.Tier1);
            string path = Path.GetTempFileName();

            Serialization.Save(path, farm);
            Farm resultFarm = Serialization.Load(path);

            Assert.That(resultFarm.Money, Is.EqualTo(farm.Money));
            Assert.That(resultFarm.Buildings.BuildingList.Count, Is.EqualTo(farm.Buildings.BuildingList.Count));
            Assert.That(resultFarm.Buildings.ChickenCount(), Is.EqualTo(farm.Buildings.ChickenCount()));
            Assert.That(resultFarm.Buildings.FindStorage<StorageSeed>().
                Capacity, Is.EqualTo(farm.Buildings.FindStorage<StorageSeed>().
                Capacity));
            Assert.That(resultFarm.Player.Position.X, Is.EqualTo(farm.Player.Position.X));
            Assert.That(resultFarm.Player.Position.Y, Is.EqualTo(farm.Player.Position.Y));
        }
    }
}