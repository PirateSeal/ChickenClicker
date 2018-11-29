#region Usings

#region Usings

using System;

#endregion

// ReSharper disable InvertIf

#endregion

namespace ChickenFarmer.Model
{
    public class Market
    {
        public Market(Farm farm)
        {
            CtxFarm = farm ?? throw new ArgumentNullException(nameof(farm));
        }

        private Farm CtxFarm { get; }
        private FarmOptions Options => CtxFarm.Options;

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if (CtxFarm.Money <= Options.UpgradeHouseCost * lvl ||
                 house.Lvl >= Options.DefaultMaxUpgrade)
                return;
            house.Upgrade();
            CtxFarm.Money -= Options.UpgradeHouseCost * (lvl + 1);
        }

        public void UpgradeStorage(Storage.StorageType storageType)
        {
            switch (storageType)
            {
                case Storage.StorageType.Seeds:
                    if (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Seeds).StorageLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Seeds).StorageLevel + 1);
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Seeds).MaxCapacity *= 2;
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Seeds).StorageLevel++;
                    }

                    break;
                case Storage.StorageType.Vegetables:
                    if (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).StorageLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).StorageLevel + 1);
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).MaxCapacity *= 2;
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).StorageLevel++;
                    }

                    break;
                case Storage.StorageType.Meat:
                    if (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Meat).StorageLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Meat).StorageLevel + 1);
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Meat).MaxCapacity *= 2;
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Meat).StorageLevel++;
                    }

                    break;
                case Storage.StorageType.Eggs:
                    if (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Eggs).StorageLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Eggs).StorageLevel + 1);
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Eggs).MaxCapacity *= 2;
                        CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Eggs).StorageLevel++;
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid food argument given",
                        nameof(Storage.StorageType));
            }
        }

        public void BuyFood(int amount, Storage.StorageType food)
        {
            switch (food)
            {
                case Storage.StorageType.Seeds:
                    {
                        if (CtxFarm.Money > Options.SeedPrice * amount)
                        {
                            CtxFarm.Money -= Options.SeedPrice * amount;
                            CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Seeds).Capacity += amount;
                        }

                        break;
                    }
                case Storage.StorageType.Vegetables:
                    {
                        if (CtxFarm.Money > Options.VegetablePrice * amount)
                        {
                            CtxFarm.Money -= Options.VegetablePrice * amount;
                            CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Vegetables).Capacity += amount;
                        }

                        break;
                    }
                case Storage.StorageType.Meat:
                    {
                        if (CtxFarm.Money > Options.MeatPrice * amount)
                        {
                            CtxFarm.Money -= Options.MeatPrice * amount;
                            CtxFarm.Buildings.FindStorageByType(Storage.StorageType.Meat).Capacity += amount;
                        }

                        break;
                    }
                default:
                    throw new ArgumentException("Invalid type of food given", nameof(Storage.StorageType));
            }
        }

        public void BuyChicken(int amount, Chicken.Breed breed)
        {
            int toPut = amount;
            foreach (IBuilding building in CtxFarm.Buildings.BuildingList)
                if (building is Henhouse house)
                    if (CtxFarm.Money > Options.DefaultChickenCost[(int)breed - 1])
                        do
                        {
                            if (toPut <= 0) return;
                            house.AddChicken(breed);
                            CtxFarm.Money -= Options.DefaultChickenCost[(int)breed - 1];
                            toPut--;
                        } while (!house.IsFull);
        }

        public static void Sellegg(Farm farm)
        {
            farm.Money += 2 * farm.Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity;
            farm.Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity = 0;
        }

        public void BuyHenhouse(int xCoord, int yCoord)
        {
            if (CtxFarm.Money > Options.DefaultHenHouseCost &&
                 CtxFarm.Buildings.CheckMaxBuildingTypeLimit<Henhouse>())
            {
                CtxFarm.Money -= Options.DefaultHenHouseCost;
                CtxFarm.Buildings.Build<Henhouse>(xCoord, yCoord);
            }
        }
    }
}