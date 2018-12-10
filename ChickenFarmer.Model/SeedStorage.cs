namespace ChickenFarmer.Model
{
    public class SeedStorage : IStorage

    {
        public SeedStorage(BuildingCollection ctx, IStorageFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
            Capacity = FarmOptions.DefaultSeedCapacity;
            MaxCapacity = FarmOptions.DefaultSeedMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }

        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.SeedPrice;
        public IStorageFactory Factory { get; }
        IBuildingFactory IBuilding.Factory => Factory;
    }
}