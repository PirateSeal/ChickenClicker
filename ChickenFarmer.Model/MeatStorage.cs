namespace ChickenFarmer.Model
{
    public class MeatStorage : IStorage
    {
        public MeatStorage(BuildingCollection ctx, IStorageFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
            Capacity = FarmOptions.DefaultMeatCapacity;
            MaxCapacity = FarmOptions.DefaultMeatMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        IBuildingFactory IBuilding.Factory => Factory;

        public void Upgrade()
        {
            Lvl ++;
            MaxCapacity *= Lvl;
        }

        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.MeatPrice;
        public IStorageFactory Factory { get; }
    }
}