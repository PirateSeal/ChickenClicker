namespace ChickenFarmer.Model
{
    public class FarmOptions
    {
        public FarmOptions( )
        {
            DefaultPlayerMaxSpeed = 1;
            DefaultMoney = 100;
            DefaultHenhouseCapacity = 4;
            DefaultStorageCapacity = 1;
            DefaultHenHouseLimit = 10;
            UpgradeHouseCost = 10;
            DefaultMaxUpgrade = 4;
            DefaultLayByMinute = 0;
            DefaultChickenCost = new[] { 10, 20, 30, 40 };

            DefaultHenHouseCost = 150;
            DefaultHenhouseBuildTime = 20;

            DefaultFoodConsumption = 0.1f;
            DefaultStorageLevel = 0;
            DefaultStorageMaxLevel = 3;
            DefaultStorageUpgradeCost = 250;

            SeedPrice = 3;
            VegetablePrice = 5;
            MeatPrice = 10;

            DefaultEggCapacity = 0;
            DefaultEggMaxCapacity = 5000;
            DefaultSeedCapacity = 1000;
            DefaultVegetableCapacity = 0;
            DefaultMeatCapacity = 0;
            DefaultSeedMaxCapacity = 10000;
            DefaultVegetableMaxCapacity = 10000;
            DefaultMeatMaxCapacity = 10000;
        }

        private int DefaultStorageCapacity { get; }

        public int DefaultMoney { get; }

        public int DefaultHenHouseLimit { get; }

        public int UpgradeHouseCost { get; }

        private int DefaultLayByMinute { get; }

        public int[] DefaultChickenCost { get; }

        public int DefaultHenHouseCost { get; }

        public int SeedPrice { get; }
        public int VegetablePrice { get; }
        public int MeatPrice { get; }

        public float DefaultFoodConsumption { get; }
        public int DefaultStorageLevel { get; }
        public int DefaultStorageMaxLevel { get; }
        public int DefaultStorageUpgradeCost { get; }

        public int DefaultSeedCapacity { get; }
        public int DefaultSeedMaxCapacity { get; }

        public int DefaultVegetableCapacity { get; }
        public int DefaultVegetableMaxCapacity { get; }

        public int DefaultMeatCapacity { get; }
        public int DefaultMeatMaxCapacity { get; }

        public int DefaultEggCapacity { get; }
        public int DefaultEggMaxCapacity { get; }

        public int DefaultMaxUpgrade { get; }

        public int DefaultHenhouseCapacity { get; }

        private int DefaultHenhouseBuildTime { get; }
        public float DefaultPlayerMaxSpeed { get; private set; }
    }
}