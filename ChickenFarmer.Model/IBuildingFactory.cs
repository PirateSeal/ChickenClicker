namespace ChickenFarmer.Model
{
    public interface IBuildingFactory
    {
        IBuilding Create( BuildingCollection ctx, Vector posVector, Storage.StorageType storageType );
    }
}