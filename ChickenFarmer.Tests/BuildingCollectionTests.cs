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
        public void Check_HH_And_Storage_Creation()
        {
            Farm farm = new Farm();
            farm.Buildings.Build<Storage>( 5, 5 );

            farm.Buildings.Build<Henhouse>( 1, 1 );

            Assert.That( farm.Buildings.Buildings.Count, Is.EqualTo( 2 ) );

            Assert.That( farm.Buildings.FindBuilding<Storage>(5,5), Is.TypeOf<Storage>() );
            Assert.That( farm.Buildings.FindBuilding<Storage>(5,5).PosVector, Is.EqualTo(new Vector(5,5)) );

            Assert.That( farm.Buildings.FindBuilding<Henhouse>(1,1), Is.TypeOf<Henhouse>() );
            Assert.That( farm.Buildings.FindBuilding<Henhouse>(1,1).PosVector, Is.EqualTo(new Vector(1,1)) );

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

            Building hh = farm.Buildings.Build<Henhouse>( 6, 6 );
            Assert.That( hh, Is.Null );
        }
    }
}