using System;
using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    public class BuildingCollection
    {
        Farm _ctx;
        FarmOptions _options;
        List<Building> _buildings;

        public BuildingCollection(Farm ctx, FarmOptions options)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _buildings = new List<Building>();
        }

        public Henhouse AddHouse(int xCoord, int yCoord)
        {
            if (_buildings.Count == _options.DefaultCapacity) { throw new InvalidOperationException("Can't add a new henhouse, max limit reached"); }

            Henhouse newHouse = new Henhouse(this, _options, xCoord, yCoord, _options.DefaultHenhouseBuildTime);
            _buildings.Add(newHouse);
            return newHouse;
        }

        public Farm CtxFarm => _ctx;
    }
}