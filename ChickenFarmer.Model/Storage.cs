namespace ChickenFarmer.Model
{
    public class Storage
    {
        readonly Farm _ctx;
        FarmOptions _options;
        int _seedCapacity;
        int _seedMaxCapacity;
        int _seedCapacityLevel;
        int _vegetableCapacity;
        int _vegetableMaxCapacity;
        int _vegetableCapacityLevel;
        int _meatCapacity;
        int _meatMaxCapacity;
        int _meatCapacityLevel;
        int _eggCapacity;
        int _eggMaxCapacity;
        int _eggCapacityLevel;


        public Storage(Farm ctx, FarmOptions farmOptions)
        {
            _ctx = ctx;
            _options = farmOptions;

            _seedCapacity = _options.DefaultSeedCapacity;
            _seedMaxCapacity = _options.DefaultSeedMaxCapacity;
            _seedCapacityLevel = _options.DefaultStorageLevel;

            _vegetableCapacity = _options.DefaultVegetableCapacity;
            _vegetableMaxCapacity = _options.DefaultVegetableMaxCapacity;
            _vegetableCapacityLevel = _options.DefaultStorageLevel;

            _meatCapacity = _options.DefaultMeatCapacity;
            _meatMaxCapacity = _options.DefaultMeatMaxCapacity;
            _meatCapacityLevel = _options.DefaultStorageLevel;

            _eggCapacity = _options.DefaultEggCapacity;
            _eggMaxCapacity = _options.DefaultEggMaxCapacity;
            _eggCapacityLevel = _options.DefaultStorageLevel;
        }

        public int TotalFoodMaxCapacity => _seedMaxCapacity + _vegetableMaxCapacity + _meatMaxCapacity;

        #region Seed Properties
        public int SeedCapacity { get => _seedCapacity; set => _seedCapacity = value; }
        public int SeedMaxCapacity { get => _seedMaxCapacity; set => _seedMaxCapacity = value; }
        public int SeedCapacityLevel { get => _seedCapacityLevel; set => _seedCapacityLevel = value; }
        #endregion

        #region Vegetable Properties
        public int VegetableCapacity { get => _vegetableCapacity; set => _vegetableCapacity = value; }
        public int VegetableMaxCapacity { get => _vegetableMaxCapacity; set => _vegetableMaxCapacity = value; }
        public int VegetableCapacityLevel { get => _vegetableCapacityLevel; set => _vegetableCapacityLevel = value; }
        #endregion

        #region Meat Properties
        public int MeatCapacity { get => _meatCapacity; set => _meatCapacity = value; }
        public int MeatMaxCapacity { get => _meatMaxCapacity; set => _meatMaxCapacity = value; }
        public int MeatCapacityLevel { get => _meatCapacityLevel; set => _meatCapacityLevel = value; }
        #endregion

        #region Egg Properties
        public int TotalEggs { get => _eggCapacity; set => _eggCapacity = value; }
        public int EggMaxCapacity { get => _eggMaxCapacity; set => _eggMaxCapacity = value; }
        public int EggCapacityLevel { get => _eggCapacityLevel; set => _eggCapacityLevel = value; }
        #endregion
    }
}
