namespace ChickenFarmer.Model
{
    public interface IBuildingFactory
    {
        IBuilding Create( BuildingCollection ctx, Vector posVector );
        void OnRemove(IBuilding building);
        int NbrBuilt { get; set; }
        bool IsEnabled { get; }
    }
}