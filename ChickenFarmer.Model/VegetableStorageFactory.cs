namespace ChickenFarmer.Model
{
    internal class VegetableStorageFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt++;
            return new VegetableStorage(ctx, posVector);
        }
        public void OnRemove(IBuilding building) { NbrBuilt--; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
    }
}