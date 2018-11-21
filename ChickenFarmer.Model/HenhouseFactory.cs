namespace ChickenFarmer.Model
{
    public class HenhouseFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, Vector posVector )
        {
            return new Henhouse( ctx, posVector );
        }
    }
}