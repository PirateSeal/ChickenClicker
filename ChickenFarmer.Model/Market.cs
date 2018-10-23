using System;

namespace ChickenFarmer.Model
{
    public class Market
    {
        Farm farm;
        FarmOptions _options;

        public Market(Farm ctx)
        {
            _options = new FarmOptions();
            farm = ctx;
        }

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if(farm.Money < _options.UpgradeHouseCost[lvl + 1] && lvl < _options.UpgradeHouseCost.Length )
            {
                farm.Houses.UpgradeHouse(house);
            }
            //verif argent joueur  + verif max lvl + drécrediter joueur + ajouter lvl 
        }

        public bool BuyChicken(Henhouse house, int amount, int breed)
        {
            for (int i = 0; i < amount; i++)
            {

                if (house.Chikens.Count <= house.Chikens.Capacity && _options.DefaultChickenCost[breed] <= farm.Money)
                {


                    farm.Money -= _options.DefaultChickenCost[breed];
                    farm.Houses.AddChicken(house, breed);
                }
                else { return false; }
            }
            return true;
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
