using System;

namespace ChickenFarmer.Model
{
    public class Building : IBuildingFactory
    {
        BuildingCollection _ctx;
        FarmOptions _options;
        int _xCoord;
        int _yCoord;
        int _buildtime;

        public enum MainPurpose
        {
            none = 0,
            Henhouse = 1,
            Storage = 2
        }

        public Building(BuildingCollection ctx, FarmOptions options, int xCoord, int yCoord, int buildtime)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _xCoord = xCoord;
            _yCoord = yCoord;
            _buildtime = buildtime;
        }

        public void Build(int xCoord, int yCoord, int BuildTime, MainPurpose MainPurpose)
        {

        }
        public int XCoord { get => _xCoord; set => _xCoord = value; }
        public int YCoord { get => _yCoord; set => _yCoord = value; }
        public int Buildtime { get => _buildtime; set => _buildtime = value; }

    }
}
