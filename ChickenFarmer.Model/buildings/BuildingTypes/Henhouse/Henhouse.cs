#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class Henhouse : IBuilding, IInteractible
    {
        public Henhouse(BuildingCollection ctx, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctx ?? throw new ArgumentNullException(nameof( ctx ));
            PosVector = posVector;
            Racks = new List<IRack> { new RackSeed(this) };
            Factory = factory;
            MaxCapacity = FarmOptions.DefaultHenHouseLimit;
            Lvl = 0;
            Chikens = new List<Chicken>(MaxCapacity * Lvl);
            Vector interactionZonePos = new Vector(posVector.X + 20, PosVector.Y + 96);
            InteractionZone = new InteractionZone(interactionZonePos, 15, 15);
        }

        public Henhouse(BuildingCollection ctx, IBuildingFactory factory, XElement xElement)
        {
            CtxCollection = ctx;
            Factory = factory;

            PosVector = new Vector(( float ) xElement?.Attribute(nameof( PosVector.X )),
                                   ( float ) xElement?.Attribute(nameof( PosVector.Y )));

            Lvl = ( int ) xElement?.Attribute(nameof( Lvl ));

            Chikens = xElement?.Element(nameof( Chikens ))?.Elements().Select(xmlC => new Chicken(this, xmlC)).ToList();

            IRack RackElementToIRack(XElement rack)
            {
                switch (rack.Name.LocalName)
                {
                    case"RackSeed":
                        return new RackSeed(this, rack);
                    case"RackVegetable":
                        return new RackVegetable(this, rack);
                    case"RackMeat":
                        return new RackMeat(this, rack);
                    default:
                        throw new NotSupportedException($"Unsupported element type: {rack.Name}");
                }
            }

            Racks = xElement?.Element(nameof( Racks ))?.Elements().Select(RackElementToIRack).ToList();
        }

        public List<IRack> Racks { get; }
        public List<Chicken> Chikens { get; }

        public int ChickenCount => Chikens.Count;
        public int MaxCapacity { get; set; }

        public bool IsFull => ChickenCount == MaxCapacity;

        public IEnumerable<Chicken> DyingChickens => Chikens.Where(c => c.Hunger <= 25);
        public IEnumerable<Chicken> DiedChickens => Chikens.Where(c => c.Hunger <= 0);

        public XElement ToXml()
        {
            return new XElement("Henhouse", new XAttribute(nameof( PosVector.X ), PosVector.X),
                                new XAttribute(nameof( PosVector.Y ), PosVector.Y),
                                new XAttribute(nameof( MaxCapacity ), MaxCapacity), new XAttribute(nameof( Lvl ), Lvl),
                                new XElement(nameof( Chikens ), Chikens.Select(chicken => chicken.ToXml())),
                                new XElement(nameof( Racks ), Racks.Select(rack => rack.ToXml())));
        }

        public Vector PosVector { get; set; }
        public BuildingCollection CtxCollection { get; set; }

        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }

        public void Upgrade()
        {
            Lvl ++;
            MaxCapacity *= Lvl;
        }

        public InteractionZone InteractionZone { get; set; }

        public bool CheckIfInside(InteractionZone interactionZone) { return true; }

        private static float ToFeed(IEnumerable<Chicken> collection)
        {
            return collection.Sum(chicken => 100f - chicken.Hunger);
        }

        public void FeedAllChicken()
        {
            if ( CtxCollection.FindStorage<StorageSeed>().Capacity >= ToFeed(Chikens) )
                foreach ( Chicken chicken in Chikens )
                    chicken.ChickenFeed();
        }

        public void FeedAllDyingChicken()
        {
            if ( CtxCollection.FindStorage<StorageSeed>().Capacity < ToFeed(DyingChickens) ) return;
            foreach ( Chicken chicken in DyingChickens ) chicken.ChickenFeed();
        }

        public void AddChicken(Chicken.Breed breed) { Chikens.Add(new Chicken(this, breed)); }

        public void FillRack<TRackType>(int amount) where TRackType : IRack
        {
            Racks.Find(rack => rack is TRackType).Fill(amount);
        }

        public void UpgradeRack<TRackType>() where TRackType : IRack { Racks.Find(rack => rack is TRackType).Upgrade(); }

        public void Update()
        {
            foreach ( Chicken chicken in Chikens ) chicken.Update();
            if ( !CheckIfAllDyingAreFed() ) CleanupDiedChicken();
        }

        private bool CheckIfAllDyingAreFed() { return DyingChickens.All(chicken => !(chicken.Hunger <= 25)); }

        private void CleanupDiedChicken()
        {
            foreach ( Chicken chicken in DiedChickens.ToList() )
            {
                chicken.Die();
                Chikens.Remove(chicken);
            }
        }
    }
}