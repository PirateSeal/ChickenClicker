namespace ChickenFarmer.Model
{
    internal class ChickenStore : IBuilding
    {
        public ChickenStore(BuildingCollection ctxCollection, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctxCollection;
            Factory = factory;
            PosVector = posVector;
        }
        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }
        public void Upgrade() { Lvl++; }

        public void BuyFood<TStorageType>(int amount) where TStorageType : IStorage
        {
            Market.BuyFood<TStorageType>(amount);
        }

        public void BuyChicken(int amount, Chicken.Breed breed)
        {
            Market.BuyChicken(amount,breed);
        }

        public void SellEggs() => Market.Sellegg();
    }
}
