namespace ChickenFarmer.Model
{
    public class StorageSeed : IStorage

    {
        public StorageSeed(BuildingCollection ctx, IStorageFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
            FarmOptions.DefaultStorageCapacity.TryGetValue(typeof(StorageSeed), out int capacity);
            Capacity = capacity;
            MaxCapacity = FarmOptions.DefaultSeedMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.SeedPrice;
        public IStorageFactory Factory { get; }

        public void Upgrade()
        {
            Lvl ++;
            MaxCapacity *= Lvl;
        }

        IBuildingFactory IBuilding.Factory => Factory;
    }
}