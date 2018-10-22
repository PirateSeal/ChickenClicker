using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmer.Model
{
    class Market
    {
        Farm farm;

        public Market(Farm ctx)
        {
            farm = ctx;
        }

        public void UpgradeHouse(Henhouse house )
        {
            
            foreach (var item in farm.Houses._HenHouses)
            {

            }
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
