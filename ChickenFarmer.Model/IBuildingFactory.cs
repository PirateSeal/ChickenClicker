namespace ChickenFarmer.Model
{
    interface IBuildingFactory
    {
        int XCoord { get; }
        int YCoord { get; }
        int Buildtime { get; }
    }
}
