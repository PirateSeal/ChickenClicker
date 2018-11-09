namespace ChickenFarmer.Model
{
    interface IBuildingFactory
    {
        int XCoord { get; }
        int YCoord { get; }
        int Buildtime { get; }
        void Build(int builtime, int xCoord, int yCoord, Building.MainPurpose mainPurpose);
    }
}
