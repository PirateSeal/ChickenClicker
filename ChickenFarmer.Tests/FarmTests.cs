using ChickenFarmer.Model;
using NUnit.Framework;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class FarmTests
    {
        [Test]
        public void Create_Farm()
        {
            Farm farm = new Farm();

            Assert.That(farm.Storage.SeedCapacity == 1000);
            Assert.That(farm.Money == 100);
            Assert.That(farm.TotalEgg == 0);
            Assert.That(farm.Houses.Henhouses.Count == 1);
            Assert.That(farm.Chickencount == 1);
        }

    }
}
