﻿#region Usings

#region Usings

using System;

#endregion

// ReSharper disable InvertIf

#endregion

namespace ChickenFarmer.Model
{
    public class Market : IBuilding
    {
        public Market(BuildingCollection ctx, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
        }

        private Farm CtxFarm => CtxCollection.CtxFarm;
        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }

        public void UpgradeHouse(Henhouse house)
        {
            int lvl = house.Lvl;
            if ( CtxFarm.Money <= FarmOptions.UpgradeHouseCost * lvl || house.Lvl >= FarmOptions.DefaultMaxUpgrade )
                return;
            house.Upgrade();
            CtxFarm.Money -= FarmOptions.UpgradeHouseCost * (lvl + 1);
        }

        public void UpgradeStorage<TStorageType>() where TStorageType : IStorage
        {
            IStorage storage = CtxCollection.FindStorage<TStorageType>();

            if ( storage.Lvl < FarmOptions.DefaultStorageMaxLevel )
            {
                CtxFarm.Money -= FarmOptions.DefaultStorageUpgradeCost * storage.Lvl + 1;
                storage.MaxCapacity *= 2;
                storage.Lvl ++;
            }
            else
            {
                throw new ArgumentException("Invalid building type given", nameof(TStorageType));
            }
        }

        public void UpgradeHenhouseRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            IRack upgradedRack = henhouse?.Racks.Find(rack => rack is TRackType) ??
                                 throw new ArgumentNullException("Rack is null", nameof(upgradedRack));
            if ( CtxFarm.Money >= upgradedRack.UpgrageCost )
            {
                CtxFarm.Money -= upgradedRack.UpgrageCost;
                henhouse.UpgradeRack<TRackType>();
            }
        }

        public void BuyFood<TStorageType>(int amount) where TStorageType : IStorage
        {
            IStorage storage = CtxCollection.FindStorage<TStorageType>();

            if ( CtxFarm.Money > storage.Value * amount )
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
            foreach ( IBuilding building in CtxFarm.Buildings.BuildingList )
                if ( building is Henhouse henhouse )
                    if ( CtxFarm.Money > FarmOptions.DefaultChickenCost[( int ) breed - 1] )
                        do
                        {
                            if ( toPut <= 0 ) return;
                            henhouse.AddChicken(breed);
                            CtxFarm.Money -= FarmOptions.DefaultChickenCost[( int ) breed - 1];
                            toPut --;
                        } while (!henhouse.IsFull);
        }

        public static void Sellegg(Farm farm)
        {
            farm.Money += 2 * farm.Buildings.FindStorage<EggStorage>().
                              Capacity;
            farm.Buildings.FindStorage<EggStorage>().
                Capacity = 0;
        }

        public void BuyRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            if ( typeof(VegetableRack).IsAssignableFrom(typeof(TRackType)) &&
                 CtxFarm.Money > FarmOptions.DefaultVegetableRackPrice )
                henhouse.Racks.Add(new VegetableRack(henhouse));
            else if ( typeof(MeatRack).IsAssignableFrom(typeof(TRackType)) &&
                      CtxFarm.Money > FarmOptions.DefaultMeatRackPrice )
                henhouse.Racks.Add(new MeatRack(henhouse));
        }

        public void BuyHenhouse(float xCoord, float yCoord)
        {
            CtxCollection.BuildingFactories.TryGetValue(typeof(Henhouse), out IBuildingFactory factory);
            if ( factory != null && CtxFarm.Money > FarmOptions.DefaultHenHouseCost && factory.IsEnabled )
            {
                CtxFarm.Money -= FarmOptions.DefaultHenHouseCost;
                CtxFarm.Buildings.Build<Henhouse>(xCoord, yCoord);
            }
        }
    }
}