namespace ChickenFarmer.Model
{
    public class StorageFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, Vector posVector, Storage.StorageType storageType)
        {
            return new Storage( ctx, posVector, storageType);
        }
    }
}