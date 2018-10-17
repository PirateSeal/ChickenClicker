using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenTest
{
    public class Enum
    {
        public struct Farm
        {
            public static int DefaultMoney = 100;
        }

        public struct HenHeouse
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
