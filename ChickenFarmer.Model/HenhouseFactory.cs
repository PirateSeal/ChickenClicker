namespace ChickenFarmer.Model
{
    public class HenhouseFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt++;
            return new Henhouse(ctx, this, posVector);
        }

        public void OnRemove(IBuilding building) { NbrBuilt--; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(4);
    }
}