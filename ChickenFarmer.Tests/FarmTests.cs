using ChickenFarmer.Model;
using NUnit.Framework;

namespace ChickenFarmer.Tests
{
    [TestFixture]
    class FarmTests
    {
        #region Farm_Creation

        [Test]
        public void Farm_Check_Default_Money()
        {
            Farm farm = new Farm();
            FarmOptions farmOptions = new FarmOptions();

            Assert.That(farm.Money == farmOptions.DefaultMoney);
        }

        [Test]
        public void Farm_Check_Default_Egg()
        {
            Farm farm = new Farm();

            Assert.That(farm.TotalEgg == 0);
        }

        #endregion

        #region Farm_Edit
        [Test]
        public void Add_Money()
        {
            Farm farm = new Farm();

            farm.Money = 5000;

            Assert.That(farm.Money == 5000);
        }
        #endregion
    }
}
