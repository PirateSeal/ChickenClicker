using System.IO;
using System.Xml.Linq;
using ChickenFarmer.Model;
using NUnit.Framework;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class SerializationTests
    {
        [Test]
        public void Farm_Serialization()
        {
            Farm farm = new Farm{Money = 5000};
            farm.Buildings.Build<Builder>(1,1);
            farm.Buildings.Build<ChickenStore>(1,2);
            farm.Buildings.Build<Henhouse>(1,3);
            farm.Buildings.Build<StorageEgg>(1,4);
            farm.Buildings.Build<StorageSeed>(1,5);
            farm.Buildings.Build<Henhouse>(1,6);
            farm.Buildings.FindBuilding<ChickenStore>(1,2).BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<ChickenStore>(1,2).BuyChicken(5,Chicken.Breed.Tier1);

            XElement xElement = farm.ToXml();
            string fileName = Path.GetTempFileName();
            xElement.Save(fileName);

            xElement = XElement.Load(fileName);
            Farm resultFarm = new Farm(xElement);

            Assert.That(resultFarm.Money, Is.EqualTo(farm.Money));
        }
    }
}
