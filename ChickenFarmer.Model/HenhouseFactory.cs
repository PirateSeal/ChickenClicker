namespace ChickenFarmer.Model
{
    public class HenhouseFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, Vector posVector , Storage.StorageType storageType = Storage.StorageType.None)
        {
            return new Henhouse( ctx, posVector );
        }
    }
}