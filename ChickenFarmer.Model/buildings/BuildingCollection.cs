#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.Model
{
    public class BuildingCollection
    {
        public BuildingCollection(Farm ctx)
        {
            CtxFarm = ctx ?? throw new ArgumentNullException(nameof(ctx));
            BuildingList = new List<IBuilding>();
        }

        public Dictionary<Type, IBuildingFactory> BuildingFactories { get; } = new Dictionary<Type, IBuildingFactory>
        {
            { typeof(StorageEgg), new EggStorageFactory() }, { typeof(StorageSeed), new SeedStorageFactory() },
            { typeof(StorageVegetable), new VegetableStorageFactory() },
            { typeof(StorageMeat), new MeatStorageFactory() }, { typeof(Market), new BuilderFactory() },
            { typeof(Henhouse), new HenhouseFactory() }
        };

        public Farm CtxFarm { get; }
        public List<IBuilding> BuildingList { get; }

        public IStorage FindStorage<TStorageType>()
        {
            return BuildingList.Find(storage => storage is TStorageType) as IStorage;
        }

        public List<TBuildingType> GetBuildingInListByType<TBuildingType>() where TBuildingType : IBuilding
        {
            List<TBuildingType> buildingList = new List<TBuildingType>();
            foreach ( IBuilding building in BuildingList )
                if ( building.GetType() == typeof(TBuildingType) )
                    buildingList.Add(building is TBuildingType type ? type : default(TBuildingType));

            return buildingList;
        }

        public void Build<TBuildingType>(float xCoord, float yCoord) where TBuildingType : IBuilding
        {
            if ( xCoord <= 0 ) throw new ArgumentOutOfRangeException(nameof(xCoord));
            if ( yCoord <= 0 ) throw new ArgumentOutOfRangeException(nameof(yCoord));
            foreach ( IBuilding item in BuildingList )
                if ( Math.Abs(item.PosVector.X - xCoord) < 0.1f && Math.Abs(item.PosVector.Y - yCoord) < 0.1f )
                    throw new ArgumentException("Invalid Coordinates, change xCoord or yCoord");

            BuildingFactories.TryGetValue(typeof(TBuildingType), out IBuildingFactory factory);
            if ( factory == null )
                throw new InvalidOperationException("This building doesn't have a factory to create it");
            if ( !factory.IsEnabled )
                throw new InvalidOperationException("Factory not enabled. Max building limit reached !");
            IBuilding building = factory.Create(this, new Vector(xCoord, yCoord));

            BuildingList.Add(building);
        }

        public void Update()
        {
            foreach ( IBuilding building in BuildingList )
            {
                Henhouse item = building as Henhouse;
                item?.Update(); // "?" = check for null
            }
        }

        public TBuildingType FindBuilding<TBuildingType>(float xCoord, float yCoord)
            where TBuildingType : class, IBuilding
        {
            foreach ( IBuilding building in BuildingList )
                if ( Math.Abs(building.PosVector.X - xCoord) < 0.1f && Math.Abs(building.PosVector.Y - yCoord) < 0.1f &&
                     building is TBuildingType )
                    return building as TBuildingType;
            return null;
        }

        public int ChickenCount()
        {
            int sum = 0;
            foreach ( IBuilding building in BuildingList )
                if ( building is Henhouse house )
                    sum += house.ChickenCount;

            return sum;
        }

        public int DyingChickenCount()
        {
            int sum = 0;
            foreach ( IBuilding building in BuildingList )
                if ( building is Henhouse house )
                    sum += house.CountDyingChickens;

            return sum;
        }
    }
}