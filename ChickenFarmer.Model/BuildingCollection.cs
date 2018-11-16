#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class BuildingCollection
    {
        private readonly Dictionary<Type, IBuildingFactory> _buildingFactories;

        public BuildingCollection( Farm ctx )
        {
            CtxFarm = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            Buildings = new List<Building>();
            _buildingFactories = new Dictionary<Type, IBuildingFactory>
            {
                { typeof( Storage ), new StorageFactory() },
                { typeof( Henhouse ), new HenhouseFactory() }
            };
        }

        public Farm CtxFarm { get; }
        public List<Building> Buildings { get; }
        private FarmOptions Options => CtxFarm.Options;

        public Storage StorageBuilding
        {
            get
            {
                foreach ( var item in Buildings )
                {
                    var building = ( Storage ) item;
                    return building;
                }

                throw new InvalidOperationException( "No storage found, build one" );
            }
        }

        public Building Build<TBuildingType>( int xCoord, int yCoord )
            where TBuildingType : Building
        {
            if ( xCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(xCoord) );
            if ( yCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(yCoord) );
            foreach ( var item in Buildings )
                if ( item.XCoord == xCoord && item.YCoord == yCoord )
                    throw new ArgumentException( "Invalid Coordinates, change xCoord or yCoord" );

            if ( !CheckMaxBuildingTypeLimit<TBuildingType>() ) return null;

            _buildingFactories.TryGetValue( typeof( TBuildingType ), out var factory );
            if ( factory == null )
                throw new InvalidOperationException(
                    "This building doesn't have a factory to create it" );
            var building = factory.Create( this, xCoord, yCoord );

            Buildings.Add( building );
            return building;
        }

        public bool CheckMaxBuildingTypeLimit<TBuildingType>() where TBuildingType : Building
        {
            var count = 0;
            foreach ( var building in Buildings )
                if ( building is TBuildingType )
                    count ++;
            if ( typeof( TBuildingType ) == typeof( Storage ) && count == 1 ) return false;
            return count != Options.DefaultHenhouseCapacity;
        }

        public int CountNbrBuilding<TBuildingType>() where TBuildingType : Building
        {
            var count = 0;
            foreach ( var building in Buildings )
                if ( building is TBuildingType )
                    count ++;
            return count;
        }

        public void Update()
        {
            foreach ( Building building in Buildings )
            {
                var item = building as Henhouse;
                item?.Update(); // "?" = check for null
            }
        }

        public int ChickenCount()
        {
            return CtxFarm.Buildings.Buildings.OfType<Henhouse>()
                .Sum( house => house.ChickenCount );
        }
    }
}