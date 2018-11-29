#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Storage : IBuilding
    {
        public enum StorageType
        {
            None = 0,
            Seeds = 1,
            Vegetables = 2,
            Meat = 3,
            Eggs = 4
        }
        public Storage(BuildingCollection ctx, Vector posVector, StorageType storageType)
        {
            CtxCollection = ctx ?? throw new ArgumentNullException(nameof(ctx));
            PosVector = posVector;
            StorageLevel = Options.DefaultStorageLevel;
            ResourceType = storageType;

            switch (storageType)
            {
                case StorageType.Seeds:
                    Capacity = Options.DefaultSeedCapacity;
                    MaxCapacity = Options.DefaultSeedMaxCapacity;
                    break;
                case StorageType.Vegetables:
                    Capacity = Options.DefaultVegetableCapacity;
                    MaxCapacity = Options.DefaultVegetableMaxCapacity;
                    break;
                case StorageType.Meat:
                    Capacity = Options.DefaultMeatCapacity;
                    MaxCapacity = Options.DefaultMeatMaxCapacity;
                    break;
                case StorageType.Eggs:
                    Capacity = Options.DefaultEggCapacity;
                    MaxCapacity = Options.DefaultEggMaxCapacity;
                    break;
                case StorageType.None:
                default:
                    throw new ArgumentException("Undefined type of storage", nameof(StorageType));
            }
        }

        public Vector PosVector { get; set; }

        public BuildingCollection CtxCollection { get; set; }

        public StorageType ResourceType { get; private set; }

        private FarmOptions Options => CtxCollection.CtxFarm.Options;

        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int StorageLevel { get; set; }

    }
}