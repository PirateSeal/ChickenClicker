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
            if (farm.Money > _options.UpgradeHouseCost[lvl] && lvl < _options.UpgradeHouseCost.Length)
            {
                farm.Houses.UpgradeHouse(house);
                farm.Money -= _options.UpgradeHouseCost[lvl];
            }
        }

        public bool BuyChicken(Henhouse house, int amount, int breed)
        {
            for (int i = 0; i < amount; i++)
            {
                if (house.Chikens.Count < house.Limit && _options.DefaultChickenCost[breed] <= farm.Money)
                {
                    farm.Money -= _options.DefaultChickenCost[breed];
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

        public void BuyFood(int amount)
        {
            if (farm.Money > _options.FoodPrice * amount)
            {
                farm.Money -= _options.FoodPrice * amount;
                farm.FoodStock += amount;
            }
        }

        public void BuyHenhouse()
        {

            if (farm.Money > _options.DefaultHenHouseCost && farm.Houses.Count() < _options.DefaultCapacity)
            {
                farm.Money -= _options.DefaultHenHouseCost;
                farm.Houses.AddHouse();
            }
        }
    }
}
