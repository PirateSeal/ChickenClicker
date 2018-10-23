namespace ChickenFarmer.Model
{
    public class Enum
    {
        public struct Farm
        {
            public static int DefaultMoney = 100;
        }

        public struct HenhouseCollection
        {
            public static int defaultCapacity = 4;
        }

        public struct HenHouse
        {
            public static int DefaultHenhouseLimit = 10;
            public static int[] UpgradeHouseCost = new int[] { 10, 20, 30, 40 };
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

        public struct Chicken
        {
            public static int DefaultLayByMinute = 0;
        }

        public struct Market
        {
            public static int[] DefaultChickenCost = new int[] { 10, 20, 30, 40};
            public static int DefaultHenhouseCost = 150;

        }

    }
}
