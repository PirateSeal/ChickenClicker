using System;

namespace ChickenFarmer.Model
{
    public class Storage:Building
    {
        readonly BuildingCollection _ctx;
        FarmOptions _options;
        private int _xCoord;
        private int _yCoord;
        private int _buildtime;

        public Storage(BuildingCollection ctx, FarmOptions options, int xCoord, int yCoord, int buildtime) : base(ctx, options, xCoord, yCoord, buildtime)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _xCoord = xCoord;
            _yCoord = yCoord;
            _buildtime = buildtime;

            SeedCapacity = _options.DefaultSeedCapacity;
            SeedMaxCapacity = _options.DefaultSeedMaxCapacity;
            SeedCapacityLevel = _options.DefaultStorageLevel;

            VegetableCapacity = _options.DefaultVegetableCapacity;
            VegetableMaxCapacity = _options.DefaultVegetableMaxCapacity;
            VegetableCapacityLevel = _options.DefaultStorageLevel;

            MeatCapacity = _options.DefaultMeatCapacity;
            MeatMaxCapacity = _options.DefaultMeatMaxCapacity;
            MeatCapacityLevel = _options.DefaultStorageLevel;

            TotalEggs = _options.DefaultEggCapacity;
            EggMaxCapacity = _options.DefaultEggMaxCapacity;
            EggCapacityLevel = _options.DefaultStorageLevel;
        }

        public int TotalFoodMaxCapacity => SeedMaxCapacity + VegetableMaxCapacity + MeatMaxCapacity;

        #region Seed Properties
        public int SeedCapacity { get; set; }
        public int SeedMaxCapacity { get; set; }
        public int SeedCapacityLevel { get; set; }
        #endregion

        #region Vegetable Properties
        public int VegetableCapacity { get; set; }
        public int VegetableMaxCapacity { get; set; }
        public int VegetableCapacityLevel { get; set; }
        #endregion

        #region Meat Properties
        public int MeatCapacity { get; set; }
        public int MeatMaxCapacity { get; set; }
        public int MeatCapacityLevel { get; set; }
        #endregion

        #region Egg Properties
        public int TotalEggs { get; }
        public int EggMaxCapacity { get; set; }
        public int EggCapacityLevel { get; set; }
        #endregion
    }
}
