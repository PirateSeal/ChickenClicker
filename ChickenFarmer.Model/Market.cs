using System;

namespace ChickenFarmer.Model
{
    public class Market
    {
        Farm farm;
        FarmOptions _options;

        public enum StorageType: byte
        {
            None = 0,
            Seed = 1,
            Vegetable = 2,
            Meat = 3,
            Egg = 4
        }

        public Market(Farm ctx, FarmOptions farmOptions)
        {
            _options = farmOptions;
            farm = ctx;
        }

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if (farm.Money > _options.UpgradeHouseCost * lvl && house.Lvl < _options.DefaultMaxUpgrade)
            {
                house.Upgrade();
                farm.Money -= _options.UpgradeHouseCost*lvl;
            }
   
        }

        public void UpgradeStorage(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Seed:
                    if (FarmStorage.SeedCapacityLevel < _options.DefaultStorageMaxLevel)
                    {
                        farm.Money -= _options.DefaultStorageUpgradeCost * (FarmStorage.SeedCapacityLevel + 1);
                        FarmStorage.SeedMaxCapacity *= 2;
                        FarmStorage.SeedCapacityLevel++;
                    }
                    break;
                case StorageType.Vegetable:
                    if (FarmStorage.VegetableCapacityLevel < _options.DefaultStorageMaxLevel)
                    {
                        farm.Money -= _options.DefaultStorageUpgradeCost * (FarmStorage.VegetableCapacityLevel + 1);
                        FarmStorage.VegetableMaxCapacity *= 2;
                        FarmStorage.VegetableCapacityLevel++;
                    }
                    break;
                case StorageType.Meat:
                    if (FarmStorage.MeatCapacityLevel < _options.DefaultStorageMaxLevel)
                    {
                        farm.Money -= _options.DefaultStorageUpgradeCost * (FarmStorage.MeatCapacityLevel + 1);
                        FarmStorage.MeatMaxCapacity *= 2;
                        FarmStorage.MeatCapacityLevel++;
                    }
                    break;
                case StorageType.Egg:
                    if (FarmStorage.EggCapacityLevel < _options.DefaultStorageMaxLevel)
                    {
                        farm.Money -= _options.DefaultStorageUpgradeCost * (FarmStorage.EggCapacityLevel + 1);
                        FarmStorage.EggMaxCapacity *= 2;
                        FarmStorage.EggCapacityLevel++;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid food argument given", nameof(StorageType));
            }
        }
        public void BuyFood(int amount, StorageType food)
        {
            switch (food)
            {
                case StorageType.Seed:
                    if (farm.Money > _options.SeedPrice * amount)
                    {
                        farm.Money -= _options.SeedPrice * amount;
                        FarmStorage.SeedCapacity += amount;
                    }
                    break;
                case StorageType.Vegetable:
                    if (farm.Money > _options.VegetablePrice * amount)
                    {
                        farm.Money -= _options.VegetablePrice * amount;
                        FarmStorage.VegetableCapacity += amount;
                    }
                    break;
                case StorageType.Meat:
                    if (farm.Money > _options.MeatPrice * amount)
                    {
                        farm.Money -= _options.MeatPrice * amount;
                        FarmStorage.MeatCapacity += amount;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid type of food given", nameof(StorageType));
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

        public void BuyHenhouse()
        {

            if (farm.Money > _options.DefaultHenHouseCost && farm.Houses.Count() < _options.DefaultCapacity)
            {
                farm.Money -= _options.DefaultHenHouseCost;
                farm.Houses.AddHouse();
            }
        }
        private Storage FarmStorage => farm.Storage;
    }
}
