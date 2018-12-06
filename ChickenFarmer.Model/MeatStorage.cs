namespace ChickenFarmer.Model
{
    public class MeatStorage : IStorage
    {
        public MeatStorage(BuildingCollection ctx, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Capacity = FarmOptions.DefaultMeatCapacity;
            MaxCapacity = FarmOptions.DefaultMeatMaxCapacity;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.MeatPrice;
    }
}