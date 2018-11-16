#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class BuildingCollectionTests
    {
        [Test]
        public void Check_HH_Default_Max_Capacity()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<Storage>( 5, 5 );

            farm.Buildings.Build<Henhouse>( 1, 1 );

            Assert.That( farm.Buildings.Buildings.Count, Is.EqualTo( 2 ) );
        }

        [Test]
        public void Check_Max_Number_HH()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<Storage>( 5, 5 );

            farm.Buildings.Build<Henhouse>( 1, 1 );
            farm.Buildings.Build<Henhouse>( 2, 2 );
            farm.Buildings.Build<Henhouse>( 3, 3 );
            farm.Buildings.Build<Henhouse>( 4, 1 );

            Assert.That( farm.Buildings.Buildings.Count, Is.EqualTo( 5 ) );
            Assert.That( farm.Buildings.CountNbrBuilding<Henhouse>(), Is.EqualTo( 4 ) );

            var hh = farm.Buildings.Build<Henhouse>( 6, 6 );
            Assert.That( hh, Is.Null );
        }
    }
}