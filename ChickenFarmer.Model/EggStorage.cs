namespace ChickenFarmer.Model
{
    public class EggStorage : IStorage
    {
        public EggStorage(BuildingCollection ctx, IStorageFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            Factory = factory;
            PosVector = posVector;
            Capacity = FarmOptions.DefaultEggCapacity;
            MaxCapacity = FarmOptions.DefaultEggMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.EggValue;
        public IStorageFactory Factory { get; }

        public void Upgrade()
        {
            Lvl ++;
            MaxCapacity *= Lvl;
        }

        IBuildingFactory IBuilding.Factory => Factory;
    }
}