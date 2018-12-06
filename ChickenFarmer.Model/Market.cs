#region Usings

#region Usings

using System;

#endregion

// ReSharper disable InvertIf

#endregion

namespace ChickenFarmer.Model
{
    public class Market : IBuilding
    {
        public BuildingCollection CtxCollection { get; set; }
        private Farm CtxFarm => CtxCollection.CtxFarm;
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }

        public Market(BuildingCollection ctx, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
        }

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if (CtxFarm.Money <= FarmOptions.UpgradeHouseCost * lvl ||
                 house.Lvl >= FarmOptions.DefaultMaxUpgrade)
                return;
            house.Upgrade();
            CtxFarm.Money -= FarmOptions.UpgradeHouseCost * (lvl + 1);
        }

        public void UpgradeStorage<TStorageType>() where TStorageType : IStorage
        {
            IStorage storage = CtxCollection.FindStorage<TStorageType>();

            if (storage.Lvl < FarmOptions.DefaultStorageMaxLevel)
            {
                CtxFarm.Money -= FarmOptions.DefaultStorageUpgradeCost * storage.Lvl + 1;
                storage.MaxCapacity *= 2;
                storage.Lvl++;
            }
            else
            {
                throw new ArgumentException("Invalid building type given",
                        nameof(TStorageType));
            }
        }

        public void BuyFood<TStorageType>(int amount) where TStorageType : IStorage
        {
            IStorage storage = CtxCollection.FindStorage<TStorageType>();

            if (CtxFarm.Money > storage.Value * amount)
            {
                CtxFarm.Money -= storage.Value * amount;
                storage.Capacity += amount;
            }
            else
            {
                throw new ArgumentException("Invalid type of food given", nameof(TStorageType));
            }
        }

        public void BuyChicken(int amount, Chicken.Breed breed)
        {
            int toPut = amount;
            foreach (IBuilding building in CtxFarm.Buildings.BuildingList)
                if (building is Henhouse house)
                    if (CtxFarm.Money > FarmOptions.DefaultChickenCost[(int)breed - 1])
                        do
                        {
                            if (toPut <= 0) return;
                            house.AddChicken(breed);
                            CtxFarm.Money -= FarmOptions.DefaultChickenCost[(int)breed - 1];
                            toPut--;
                        } while (!house.IsFull);
        }

        public static void Sellegg(Farm farm)
        {
            farm.Money += 2 * farm.Buildings.FindStorage<EggStorage>().Capacity;
            farm.Buildings.FindStorage<EggStorage>().Capacity = 0;
        }

        public void BuyHenhouse(float xCoord, float yCoord)
        {
            CtxCollection.BuildingFactories.TryGetValue(typeof(Henhouse),
                out IBuildingFactory factory);
            if (factory != null && (CtxFarm.Money > FarmOptions.DefaultHenHouseCost && factory.IsEnabled))
            {
                CtxFarm.Money -= FarmOptions.DefaultHenHouseCost;
                CtxFarm.Buildings.Build<Henhouse>(xCoord, yCoord);
            }
        }
    }
}