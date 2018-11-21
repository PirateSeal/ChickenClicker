namespace ChickenFarmer.Model
{
    internal interface IBuildingFactory
    {
        Building Create( BuildingCollection ctx, Vector posVector );
    }
}