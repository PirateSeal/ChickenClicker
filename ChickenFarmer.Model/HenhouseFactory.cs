namespace ChickenFarmer.Model
{
    public class HenhouseFactory : IBuildingFactory
    {
        public Building Create( BuildingCollection ctx, int xCoord, int yCoord )
        {
            return new Henhouse( ctx, xCoord, yCoord );
        }
    }
}