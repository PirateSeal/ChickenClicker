namespace ChickenFarmer.Model
{
    internal class EggStorageFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new EggStorage(ctx, posVector);
        }

        public void OnRemove(IBuilding building) { NbrBuilt --; }

        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
    }
}