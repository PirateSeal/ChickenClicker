using ChickenTest;
using NUnit.Framework;

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

            Assert.That(farm.Houses._HenHouses.Capacity == Enum.HenHeouse.DefaultHenhouseLimit);
        }

        [Test]
        public void Check_Number_HH()
        {
            Farm farm = new Farm();

            for (int i = 0; i < 5; i++)
            {
                farm.Houses.AddHouse();
                Assert.That(farm.Houses._HenHouses.Count == i + 1);
            }

        }



        #endregion
    }
}
