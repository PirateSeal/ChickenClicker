namespace ChickenFarmer.Model
{
    class Market
    {
        Farm farm;

        public Market(Farm ctx)
        {
            farm = ctx;
        }

        public void UpgradeHouse(Henhouse house)
        {

            foreach (var item in farm.Houses._HenHouses)
            {

            }
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
