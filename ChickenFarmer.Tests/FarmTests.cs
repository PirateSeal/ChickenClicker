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
            var farm = new Farm();
            farm.Buildings.Build<Storage>( 1, 2 );

            Assert.That( farm.Buildings.Buildings.Count, Is.EqualTo( 1 ) );
        }
    }
}