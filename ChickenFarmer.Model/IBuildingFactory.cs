namespace ChickenFarmer.Model
{
    public interface IBuildingFactory
    {
        Building Create( BuildingCollection ctx, Vector posVector, Storage.StorageType storageType );
    }
}