namespace ChickenFarmer.Model
{
    public class FarmOptions
    {
        int _defaultMoney;
        int _defaultCapacity;
        int _defaultHenhouseLimit;
        int _upgradeHouseCost;
        int _defaultLayByMinute;
        int[] _defaultChickenCost;
        int _defaultHenHouseCost;
        int _defaultStorageUpgradeCost;

        int _defaultEggCapacity;
        readonly int _defaultEggMaxCapacity;

        readonly int _defaultFoodConsumption;
        readonly int _defaultStorageLevel;
        readonly int _defaultStorageMaxLevel;

        readonly int _defaultSeedPrice;
        readonly int _defaultVegetablePrice;
        readonly int _defaultMeatPrice;

        readonly int _defaultSeedCapacity;
        readonly int _defaultSeedMaxCapacity;
        readonly int _defaultVegetableCapacity;
        readonly int _defaultVegetableMaxCapacity;
        readonly int _defaultMeatCapacity;
        readonly int _defaultMeatMaxCapacity;
        readonly int _defaultMaxUpgrade;

        public FarmOptions()
        {
            _defaultMoney = 100;
            _defaultCapacity = 4;
            _defaultHenhouseLimit = 10;
            _upgradeHouseCost = 10;
            _defaultMaxUpgrade = 4;
            _defaultLayByMinute = 0;
            _defaultChickenCost = new int[] { 10, 20, 30, 40 };
            _defaultHenHouseCost = 150;
            _defaultFoodConsumption = 2;
            _defaultStorageLevel = 0;
            _defaultStorageMaxLevel = 3;
            _defaultStorageUpgradeCost = 250;

            _defaultSeedPrice = 3;
            _defaultVegetablePrice = 5;
            _defaultMeatPrice = 10;

            _defaultEggCapacity = 0;
            _defaultEggMaxCapacity = 5000;
            _defaultSeedCapacity = 1000;
            _defaultVegetableCapacity = 0;
            _defaultMeatCapacity = 0;
            _defaultSeedMaxCapacity = 10000;
            _defaultVegetableMaxCapacity = 10000;
            _defaultMeatMaxCapacity = 10000;
        }

        public int DefaultMoney
        {
            get => _defaultMoney;
            set => _defaultMoney = value;
        }

        public int DefaultCapacity
        {
            get => _defaultCapacity;
            set => _defaultCapacity = value;
        }

        public int DefaultHenHouseLimit
        {
            get => _defaultHenhouseLimit;
            set => _defaultHenhouseLimit = value;
        }

        public int UpgradeHouseCost
        {
            get => _upgradeHouseCost;
            set => _upgradeHouseCost = value;
        }

        public int DefaultLayByMinute
        {
            get => _defaultLayByMinute;
            set => _defaultLayByMinute = value;
        }

        public int[] DefaultChickenCost
        {
            get => _defaultChickenCost;
            set => _defaultChickenCost = value;
        }

        public int DefaultHenHouseCost
        {
            get => _defaultHenHouseCost;
            set => _defaultHenHouseCost = value;
        }

        public int SeedPrice => _defaultSeedPrice;
        public int VegetablePrice => _defaultVegetablePrice;
        public int MeatPrice => _defaultMeatPrice;


        public int DefaultFoodConsumption => _defaultFoodConsumption;
        public int DefaultStorageLevel => _defaultStorageLevel;
        public int DefaultStorageMaxLevel => _defaultStorageMaxLevel;
        public int DefaultStorageUpgradeCost => _defaultStorageUpgradeCost;

        public int DefaultSeedCapacity => _defaultSeedCapacity;
        public int DefaultSeedMaxCapacity => _defaultSeedMaxCapacity;

        public int DefaultVegetableCapacity => _defaultVegetableCapacity;
        public int DefaultVegetableMaxCapacity => _defaultVegetableMaxCapacity;

        public int DefaultMeatCapacity => _defaultMeatCapacity;
        public int DefaultMeatMaxCapacity => _defaultMeatMaxCapacity;

        public int DefaultEggCapacity => _defaultEggCapacity;
        public int DefaultEggMaxCapacity => _defaultEggMaxCapacity;

        public int DefaultMaxUpgrade => _defaultMaxUpgrade;
    }
}
