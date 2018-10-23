namespace ChickenFarmer.Model
{
    public class Market
    {
        Farm farm;

        public Market(Farm ctx)
        {
            farm = ctx;
        }

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if(farm.Money < Enum.HenHouse.UpgradeHouseCost[lvl + 1] && lvl < Enum.HenHouse.UpgradeHouseCost.Length )
            {
                farm.Houses.UpgradeHouse(house);
            }
           


            //verif argent joueur  + verif max lvl + drécrediter joueur + ajouter lvl 
           
        }

        public bool BuyChicken(Henhouse house, int amount, int breed)
        {
            for (int i = 0; i < amount; i++)
            {

                if (house.Chikens.Count <= house.Chikens.Capacity && Enum.Market.DefaultChickenCost[breed] <= farm.Money)
                {


                    farm.Money -= Enum.Market.DefaultChickenCost[breed];
                    farm.Houses.AddChicken(house, breed);
                   
                }
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
