#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class FarmTests
    {
        [Test]
        public void Create_Farm()
        {
            Farm farm = new Farm();

            Assert.That( farm.Money, Is.EqualTo( farm.Options.DefaultMoney ) );
            Assert.That( farm.Buildings.BuildingList.Count, Is.EqualTo(0) );
        }
    }
}