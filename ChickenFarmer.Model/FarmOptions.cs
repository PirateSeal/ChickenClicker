namespace ChickenFarmer.Model
{
    public class FarmOptions
    {
        int _defaultMoney;
        int _defaultCapacity;
        int _defaultHenhouseLimit;
        int[] _upgradeHouseCost;
        int _defaultLayByMinute;
        int[] _defaultChickenCost;
        int _defaultHenHouseCost;
        int _defaultFoodStock;
        int _foodPrice;
        int _defaultFoodConsumption;




        public FarmOptions()
        {
            _defaultMoney = 100;
            _defaultCapacity = 4;
            _defaultHenhouseLimit = 10;
            _upgradeHouseCost = new int[] { 10, 20, 30, 40 };
            _defaultLayByMinute = 0;
            _defaultChickenCost = new int[] { 10, 20, 30, 40 };
            _defaultHenHouseCost = 150;
            _defaultFoodStock = 0;
            _foodPrice = 3;
            _defaultFoodConsumption = 2;
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

        public int[] UpgradeHouseCost
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

        public int DefaultFoodStock => _defaultFoodStock;
        public int FoodPrice => _foodPrice;
        public int DefaultFoodConsumption => _defaultFoodConsumption;

        /*
        public struct Chicken
        {
            public struct chickenRace1
            {
                public static int DefaultLayByMinute = 10;
            }
            public struct chickenRace2
            {
                public static int DefaultLayByMinute = 20;
            }
            public struct chickenRace3
            {
                public static int DefaultLayByMinute = 30;
            }
            public struct chickenRace4
            {
                public static int DefaultLayByMinute = 40;
            }
        }
         */

    }
}
