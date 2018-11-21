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
        public enum StorageType : byte
        {
            Seed = 0,
            Vegetable = 1,
            Meat = 2,
            Egg = 3
        }

        public Market(Farm farm)
        {
            CtxFarm = farm ?? throw new ArgumentNullException(nameof(farm));
        }

        private Farm CtxFarm { get; }
        private Storage FarmStorage => CtxFarm.Buildings.StorageBuilding;
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

        public void UpgradeStorage(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Seed:
                    if (FarmStorage.SeedCapacityLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (FarmStorage.SeedCapacityLevel + 1);
                        FarmStorage.SeedMaxCapacity *= 2;
                        FarmStorage.SeedCapacityLevel++;
                    }

                    break;
                case StorageType.Vegetable:
                    if (FarmStorage.VegetableCapacityLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (FarmStorage.VegetableCapacityLevel + 1);
                        FarmStorage.VegetableMaxCapacity *= 2;
                        FarmStorage.VegetableCapacityLevel++;
                    }

                    break;
                case StorageType.Meat:
                    if (FarmStorage.MeatCapacityLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (FarmStorage.MeatCapacityLevel + 1);
                        FarmStorage.MeatMaxCapacity *= 2;
                        FarmStorage.MeatCapacityLevel++;
                    }

                    break;
                case StorageType.Egg:
                    if (FarmStorage.EggCapacityLevel < Options.DefaultStorageMaxLevel)
                    {
                        CtxFarm.Money -= Options.DefaultStorageUpgradeCost *
                                         (FarmStorage.EggCapacityLevel + 1);
                        FarmStorage.EggMaxCapacity *= 2;
                        FarmStorage.EggCapacityLevel++;
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid food argument given",
                        nameof(StorageType));
            }
        }

        public void BuyFood(int amount, StorageType food)
        {
            switch (food)
            {
                case StorageType.Seed:
                    if (CtxFarm.Money > Options.SeedPrice * amount)
                    {
                        CtxFarm.Money -= Options.SeedPrice * amount;
                        FarmStorage.SeedCapacity += amount;
                    }

                    break;
                case StorageType.Vegetable:
                    if (CtxFarm.Money > Options.VegetablePrice * amount)
                    {
                        CtxFarm.Money -= Options.VegetablePrice * amount;
                        FarmStorage.VegetableCapacity += amount;
                    }

                    break;
                case StorageType.Meat:
                    if (CtxFarm.Money > Options.MeatPrice * amount)
                    {
                        CtxFarm.Money -= Options.MeatPrice * amount;
                        FarmStorage.MeatCapacity += amount;
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid type of food given",
                        nameof(StorageType));
            }
        }

        public void BuyChicken(int amount, Chicken.Breed breed)
        {
            int toPut = amount;
            foreach (Building building in CtxFarm.Buildings.Buildings)
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
            farm.Money += 2 * farm.Buildings.StorageBuilding.TotalEggs;
            farm.Buildings.StorageBuilding.TotalEggs = 0;
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