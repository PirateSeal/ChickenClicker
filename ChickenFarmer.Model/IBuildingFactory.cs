namespace ChickenFarmer.Model
{
    internal interface IBuildingFactory
    {
        Building Create( BuildingCollection ctx, int xCoord, int yCoord );
    }
}