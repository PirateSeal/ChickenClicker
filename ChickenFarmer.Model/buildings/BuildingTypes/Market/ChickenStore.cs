#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class ChickenStore : IBuilding
    {
        public ChickenStore(BuildingCollection ctxCollection, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctxCollection;
            Factory = factory;
            PosVector = posVector;
        }

        public ChickenStore(BuildingCollection ctxCollection, IBuildingFactory factory, XElement xElement)
        {
            CtxCollection = ctxCollection;
            Factory = factory;

            PosVector = new Vector(( float ) xElement?.Attribute(nameof(PosVector.X)),
                ( float ) xElement?.Attribute(nameof(PosVector.Y)));

            Lvl = ( int ) xElement?.Attribute(nameof(Lvl));
        }

        public XElement ToXml()
        {
            return new XElement("ChickenStore", new XAttribute(nameof(PosVector.X), PosVector.X),
                new XAttribute(nameof(PosVector.Y), PosVector.Y), new XAttribute(nameof(Lvl), Lvl));
        }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }
        public void Upgrade() { Lvl ++; }

        public void BuyFood<TStorageType>(int amount) where TStorageType : IStorage
        {
            Market.BuyFood<TStorageType>(amount);
        }

        public void BuyChicken(int amount, Chicken.Breed breed) { Market.BuyChicken(amount, breed); }

        public void SellEggs() { Market.Sellegg(); }
    }
}