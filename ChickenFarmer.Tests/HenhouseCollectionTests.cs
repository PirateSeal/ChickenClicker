using ChickenFarmer.Model;
using NUnit.Framework;
using System;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class HenhouseCollectionTests
    {
        #region HH_Creation
        [Test]
        public void Check_HH_Default_Max_Capacity()
        {
            Farm farm = new Farm();
            farm.Houses.AddHouse();

            foreach (Henhouse item in farm.Houses.Henhouses)
            {
                Assert.That(item.Limit == Model.Enum.HenhouseCollection.defaultCapacity);
            }
        }

        [Test]
        public void Check_Number_HH()
        {
            Farm farm = new Farm();

            Assert.That(farm.Houses.Count() == 1);

            farm.Houses.AddHouse();
            Assert.That(farm.Houses.Count() == 2);

            farm.Houses.AddHouse();
            Assert.That(farm.Houses.Count() == 3);

            farm.Houses.AddHouse();
            Assert.That(farm.Houses.Count() == 4);

            Assert.Throws<InvalidOperationException>(() => farm.Houses.AddHouse());
        }
        #endregion
    }
}
