namespace ChickenFarmer.Model
{
    public class Builder : IBuilding
    {
        public Builder(BuildingCollection ctxCollection, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctxCollection;
            Factory = factory;
            PosVector = posVector;
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }
        public void Upgrade() { Lvl ++; }

        public void BuyBuilding<TBuildingType>(float xCoord, float yCoord) where TBuildingType : IBuilding
        {
            Market.BuyBuilding<TBuildingType>(xCoord, yCoord);
        }

        public void UpgradeBuilding<TBuildingType>(TBuildingType building) where TBuildingType : IBuilding
        {
            Market.UpgradeBuilding(building);
        }

        public void BuyRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            Market.BuyRack<TRackType>(henhouse);
        }

        public void UpgradeRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            Market.UpgradeHenhouseRack<TRackType>(henhouse);
        }
    }
}