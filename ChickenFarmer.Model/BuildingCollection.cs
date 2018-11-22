#region Usings

using System;
using System.Collections.Generic;

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
            this.Build<Henhouse>(150f, 250f);
            this.Build<Storage>(250f, 250f);
        }

        public Farm CtxFarm { get; }
        public List<Building> Buildings { get; }
        private FarmOptions Options => CtxFarm.Options;

        public Storage StorageBuilding
        {
            get
            {
                foreach ( Building item in Buildings )
                {
                    if (item.GetType() == typeof(Storage))
                    {
                        Storage building = (Storage)item;
                        return building;
                    }
                }
              
                 throw new InvalidOperationException( "No storage found, build one" );
            }
        }


        public List<TBuildingType> GetBuildingInList<TBuildingType>() where TBuildingType : Building
        {
            List<TBuildingType> buildingList = new List<TBuildingType>();
            foreach ( Building building in Buildings )
                if ( building.GetType() == typeof( TBuildingType ) )
                    buildingList.Add( building as TBuildingType );

            return buildingList;
        }

        public Building Build<TBuildingType>( float xCoord, float yCoord )
            where TBuildingType : Building
        {
            if ( xCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(xCoord) );
            if ( yCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(yCoord) );
            foreach ( Building item in Buildings )
                if ( Math.Abs( item.PosVector.X - xCoord ) < 0.1f &&
                     Math.Abs( item.PosVector.Y - yCoord ) < 0.1f )
                    throw new ArgumentException( "Invalid Coordinates, change xCoord or yCoord" );

            if ( !CheckMaxBuildingTypeLimit<TBuildingType>() ) return null;

            _buildingFactories.TryGetValue( typeof( TBuildingType ), out IBuildingFactory factory );
            if ( factory == null )
                throw new InvalidOperationException(
                    "This building doesn't have a factory to create it" );
            Building building = factory.Create( this, new Vector( xCoord, yCoord ) );

            Buildings.Add( building );
            return building;
        }

        public bool CheckMaxBuildingTypeLimit<TBuildingType>() where TBuildingType : Building
        {
            int count = 0;
            foreach ( Building building in Buildings )
                if ( building is TBuildingType )
                    count ++;
            if ( typeof( TBuildingType ) == typeof( Storage ) && count == 1 ) return false;
            return count != Options.DefaultHenhouseCapacity;
        }

        public int CountNbrBuilding<TBuildingType>() where TBuildingType : Building
        {
            int count = 0;
            foreach ( Building building in Buildings )
                if ( building is TBuildingType )
                    count ++;
            return count;
        }

        public void Update()
        {
            foreach ( Building building in Buildings )
            {
                Henhouse item = building as Henhouse;
                item?.Update(); // "?" = check for null
            }
        }

        public TBuildingType FindBuilding<TBuildingType>( float xCoord, float yCoord )
            where TBuildingType : Building
        {
            foreach ( Building building in Buildings )
                if ( Math.Abs( building.PosVector.X - xCoord ) < 0.1f &&
                     Math.Abs( building.PosVector.Y - yCoord ) < 0.1f && building is TBuildingType )
                    return ( TBuildingType ) building;
            return null;
        }

        public int ChickenCount()
        {
            int sum = 0;
            foreach ( Building building in CtxFarm.Buildings.Buildings )
                if ( building is Henhouse house )
                    sum += house.ChickenCount;

            return sum;
        }
    }
}