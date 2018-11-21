namespace ChickenFarmer.Model
{
    public class StorageFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, Vector posVector )
        {
            return new Storage( ctx, posVector );
        }
    }
}