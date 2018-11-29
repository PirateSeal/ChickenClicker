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
            BuildingList = new List<IBuilding>();
            _buildingFactories = new Dictionary<Type, IBuildingFactory>
            {
                { typeof( Storage ), new StorageFactory() },
                { typeof( Henhouse ), new HenhouseFactory() }
            };
        }

        public Farm CtxFarm { get; }
        public List<IBuilding> BuildingList { get; }
        private FarmOptions Options => CtxFarm.Options;

        public Storage FindStorageByType(Storage.StorageType storageType)
        {
            foreach (Storage item in BuildingList.OfType<Storage>())
            {
                if (item.ResourceType == storageType)
                {
                    return item;
                }
            }

            throw new InvalidOperationException("No storage found, build one");
        }


        public List<TBuildingType> GetBuildingInListByType<TBuildingType>() where TBuildingType : IBuilding
        {
            List<TBuildingType> buildingList = new List<TBuildingType>();
            foreach ( IBuilding building in BuildingList )
                if ( building.GetType() == typeof( TBuildingType ) )
                    buildingList.Add( building is TBuildingType type ? type : default(TBuildingType));

            return buildingList;
        }

        public IBuilding Build<TBuildingType>( float xCoord, float yCoord, Storage.StorageType storageType = Storage.StorageType.None)
            where TBuildingType : IBuilding
        {
            if ( xCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(xCoord) );
            if ( yCoord <= 0 ) throw new ArgumentOutOfRangeException( nameof(yCoord) );
            foreach ( IBuilding item in BuildingList )
                if ( Math.Abs( item.PosVector.X - xCoord ) < 0.1f &&
                     Math.Abs( item.PosVector.Y - yCoord ) < 0.1f )
                    throw new ArgumentException( "Invalid Coordinates, change xCoord or yCoord" );

            if ( !CheckMaxBuildingTypeLimit<TBuildingType>() ) return null;

            _buildingFactories.TryGetValue( typeof( TBuildingType ), out IBuildingFactory factory );
            if ( factory == null )
                throw new InvalidOperationException(
                    "This building doesn't have a factory to create it" );
            IBuilding building = factory.Create( this, new Vector( xCoord, yCoord ), storageType);

            BuildingList.Add( building );
            return building;
        }

        public bool CheckMaxBuildingTypeLimit<TBuildingType>() where TBuildingType : IBuilding
        {
            int count = 0;
            foreach ( IBuilding building in BuildingList )
                if ( building is TBuildingType )
                    count ++;
            //if ( typeof( TBuildingType ) == typeof( Storage ) && count == 1 ) return false;
            return count != Options.DefaultHenhouseCapacity;
        }

        public int CountNbrBuilding<TBuildingType>() where TBuildingType : IBuilding
        {
            int count = 0;
            foreach ( IBuilding building in BuildingList )
                if ( building is TBuildingType )
                    count ++;
            return count;
        }

        public void Update()
        {
            foreach ( IBuilding building in BuildingList )
            {
                Henhouse item = building as Henhouse;
                item?.Update(); // "?" = check for null
            }
        }

        public TBuildingType FindBuilding<TBuildingType>( float xCoord, float yCoord )
            where TBuildingType : class, IBuilding
        {
            foreach ( IBuilding building in BuildingList )
                if ( Math.Abs( building.PosVector.X - xCoord ) < 0.1f &&
                     Math.Abs( building.PosVector.Y - yCoord ) < 0.1f && building is TBuildingType )
                    return building as TBuildingType;
            return null;
        }

        public int ChickenCount()
        {
            int sum = 0;
            foreach ( IBuilding building in CtxFarm.Buildings.BuildingList )
                if ( building is Henhouse house )
                    sum += house.ChickenCount;

            return sum;
        }
    }
}