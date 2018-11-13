using System;
using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    public class BuildingCollection
    {
        private readonly FarmOptions _options;

        public enum MainPurpose
        {
            None = 0,
            Henhouse = 1,
            Storage = 2
        }

        public BuildingCollection(Farm ctx, FarmOptions options)
        {
            CtxFarm = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            Buildings = new List<Building>();
        }

        public Building Build(int xCoord, int yCoord, int buildtime, MainPurpose mainPurpose)
        {
            if (!CheckMaxBuildingTypeLimit<1>()) return null;
            Building building = null;
            if (mainPurpose == MainPurpose.Henhouse)
                building = new Henhouse(this, _options, xCoord, yCoord, _options.DefaultHenhouseBuildTime);
            else if (mainPurpose == MainPurpose.Storage)
                building = new Storage(this, _options, xCoord, yCoord, _options.DefaultHenhouseBuildTime);
            else
                throw new ArgumentException("Wrong type of building given", nameof(mainPurpose));
            Buildings.Add(building);
            return building;
        }

        public int BuildingTypeCount<T>()
        {
            var count = 0;
            foreach (var building in Buildings)
                if (typeof(T) == building.GetType())
                    count++;

            return count;
        }

        private bool CheckMaxBuildingTypeLimit<T>()
        {
            var count = 0;
            foreach (var building in Buildings)
                if (typeof(T) == building.GetType())
                    count++;
            if (count == _options.DefaultHenhouseCapacity) return false;
            throw new ArgumentException("Wrong argument given", nameof(T));
        }

        public void AddChicken(Henhouse house, int breed)
        {
            foreach (var item in Buildings)
                if (item == house)
                    house.AddChicken(breed);
        }

        public void Update()
        {
            foreach (var building in Buildings)
            {
                Henhouse item = building as Henhouse;
                item.Update();
            }
        }

        public int ChickenCount()
        {
            var count = 0;
            foreach (var building in Buildings)
            {
                var item = (Henhouse) building;
                count += item.ChickenCount;
            }

            return count;
        }


        public Farm CtxFarm { get; }

        public List<Building> Buildings { get; }

        public Storage StorageBuilding
        {
            get
            {
                foreach (var item in Buildings)
                {
                    var building = (Storage) item;
                    return building;
                }

                throw new MissingFieldException("No storage found, build one");
            }
        }
    }
}