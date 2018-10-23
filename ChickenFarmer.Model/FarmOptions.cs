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




        public FarmOptions()
        {
            _defaultMoney = 100;
            _defaultCapacity = 4;
            _defaultHenhouseLimit = 10;
            _upgradeHouseCost = new int[] { 10, 20, 30, 40 };
            _defaultLayByMinute = 0;
            _defaultChickenCost = new int[] { 10, 20, 30, 40 };
            _defaultHenHouseCost = 150;
        }

        public int DefaultMoney
        {
            get { return _defaultMoney; }
            set { _defaultMoney = value; }
        }

        public int DefaultCapacity
        {
            get { return _defaultCapacity; }
            set { _defaultCapacity = value; }
        }

        public int DefaultHenHouseLimit
        {
            get { return _defaultCapacity; }
            set { _defaultHenhouseLimit = value; }
        }

        public int[] UpgradeHouseCost
        {
            get { return _upgradeHouseCost; }
            set { _upgradeHouseCost = value; }
        }

        public int DefaultLayByMinute
        {
            get { return _defaultLayByMinute; }
            set { _defaultLayByMinute = value; }
        }

        public int[] DefaultChickenCost
        {
            get { return _defaultChickenCost; }
            set { _defaultChickenCost = value; }
        }

        public int DefaultHenHouseCost
        {
            get { return _defaultHenHouseCost; }
            set { _defaultHenHouseCost = value; }
        }


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
