#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class Builder : IBuilding ,IInteractible
    {
        public Builder(BuildingCollection ctxCollection, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctxCollection;
            Factory = factory;
            PosVector = posVector;
            Vector interactionZonePos = new Vector(posVector.X + 80, PosVector.Y + 130);
            EntryZone = new InteractionZone(interactionZonePos, 20, 50);

            FarmOptions.SpawnPos.TryGetValue(typeof(Builder), out var value);
            LeaveZone = new InteractionZone(value, 75, 75);      
        }

        public Builder(BuildingCollection ctxCollection, IBuildingFactory factory, XElement xElement)
        {
            CtxCollection = ctxCollection;
            Factory = factory;

            PosVector = new Vector(( float ) xElement?.Attribute(nameof( PosVector.X )),
                                   ( float ) xElement?.Attribute(nameof( PosVector.Y )));

            Lvl = ( int ) xElement?.Attribute(nameof( Lvl ));
        }


        public InteractionZone EntryZone { get; set; }
        public InteractionZone LeaveZone { get; set; }


        public XElement ToXml()
        {
            return new XElement("Builder", new XAttribute(nameof( PosVector.X ), PosVector.X),
                                new XAttribute(nameof( PosVector.Y ), PosVector.Y), new XAttribute(nameof( Lvl ), Lvl));
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

        public void BuyRack<TRackType>(Henhouse henhouse) where TRackType : IRack { Market.BuyRack<TRackType>(henhouse); }

        public void UpgradeRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            Market.UpgradeHenhouseRack<TRackType>(henhouse);
        }
    }
}