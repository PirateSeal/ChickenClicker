namespace ChickenFarmer.Model
{
    public interface IBuildingFactory
    {
        int NbrBuilt { get; set; }
        bool IsEnabled { get; }
        IBuilding Create(BuildingCollection ctx, Vector posVector);
        void      OnRemove(IBuilding        building);
    }
}