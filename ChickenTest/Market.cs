using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenTest
{
    class Market
    {
        Farm _ctx;

        public Market(Farm ctx)
        {
            _ctx = ctx;
        }

        public bool BuyChicken(Farm farm,Henhouse house ,int amount, int breed)
            {
                if (house.Chikens.Count < house.Limit && amount*Enum.Market.DefaultChickenCost[breed] <= farm.Money)
                {

                    for (int i = 0; i < amount; i++)
                    {
                        farm.Money += (-10);
                        farm.Chickencount++;
                        farm.Houses.AddChicken(house,breed);
                    }

                return true;
                }
            return false;
           }


        public void Sellegg(Farm farm)
        {
            int money = 2 * farm.TotalEgg;
            farm.TotalEgg = 0;
            farm.Money += money;


        }

        internal void BuyHenhouse(Farm farm)
        {
            farm.Houses.AddHouse();
            int money = 2 * farm.TotalEgg;
        }
    }
}
