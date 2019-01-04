namespace ChickenFarmer.Model
{
    internal class SeedStorageFactory : IStorageFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new StorageSeed(ctx, this, posVector);
        }

        public void OnRemove(IBuilding building) { NbrBuilt --; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
        public int DefaultCapacity
        {
            get
            {
                FarmOptions.DefaultStorageCapacity.TryGetValue(typeof(StorageMeat), out int capacity);
                return capacity;
            }
        }
    }
}