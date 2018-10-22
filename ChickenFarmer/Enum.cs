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
        }

        public struct Chicken
        {
            public static int DefaultLayByMinute = 0;
        }

        public struct Market
        {
            public static int[] DefaultChickenCost = new int[] { 10, 20, 30, 40 };
            public static int DefaultHenhouseCost = 150;

        }

    }
}
