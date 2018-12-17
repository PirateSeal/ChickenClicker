namespace ChickenFarmer.Model
{
    public class VegetableStorage : IStorage
    {
        public VegetableStorage(BuildingCollection ctx, IStorageFactory factory,
            Vector                                 posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
            Capacity = FarmOptions.DefaultVegetableCapacity;
            MaxCapacity = FarmOptions.DefaultVegetableMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }

        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.VegetablePrice;
        public IStorageFactory Factory { get; }
        IBuildingFactory IBuilding.Factory => Factory;
    }
}