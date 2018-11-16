namespace ChickenFarmer.Model
{
    public class StorageFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, int xCoord, int yCoord )
        {
            return new Storage( ctx, xCoord, yCoord );
        }
    }
}