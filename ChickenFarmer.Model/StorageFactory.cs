namespace ChickenFarmer.Model
{
    public class StorageFactory : IBuildingFactory
    {
        public IBuilding Create( BuildingCollection ctx, Vector posVector, Storage.StorageType storageType)
        {
            return new Storage( ctx, posVector, storageType);
        }
    }
}