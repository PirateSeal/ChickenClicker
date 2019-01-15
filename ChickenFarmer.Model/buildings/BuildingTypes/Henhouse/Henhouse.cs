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
            CtxCollection = ctx ?? throw new ArgumentNullException(nameof(ctx));
            PosVector = posVector;
            Racks = new List<IRack> { new RackSeed(this) };
            Factory = factory;
            MaxCapacity = FarmOptions.DefaultHenHouseLimit;
            Lvl = 0;
            Chikens = new List<Chicken>(MaxCapacity * Lvl);
            DyingChickens = new List<Chicken>();
            Vector interactionZonePos = new Vector(posVector.X + 20, PosVector.Y + 96);
            EntryZone = new InteractionZone(interactionZonePos, 50, 50);
            LeaveZone = new InteractionZone(FarmOptions.HenhouseSpawn, 50, 50);

        }

        public XElement ToXml()
        {
            return new XElement("Henhouse",
                new XAttribute("xCoord",PosVector.X),
                new XAttribute("yCoord",PosVector.Y),
                new XAttribute("MaxCapacity",MaxCapacity),
                new XAttribute("Level",Lvl),
                new XElement("ChickenList",Chikens.Select(chicken => chicken.ToXml())),
                new XElement("Racks",Racks.Select(rack => rack.ToXml()))
                );
        }

        public List<IRack> Racks { get; }
        public List<Chicken> Chikens { get; }
        private List<Chicken> DyingChickens { get; }

        public int ChickenCount => Chikens.Count;
        public int MaxCapacity { get; set; }

        public bool IsFull => ChickenCount == MaxCapacity;

        public int CountDyingChickens => DyingChickens.Count;
        public Vector PosVector { get; set; }
        public BuildingCollection CtxCollection { get; set; }

        public int Lvl { get; set; }
        public IBuildingFactory Factory { get; }

        public void Upgrade()
        {
            Lvl ++;
            MaxCapacity *= Lvl;
        }


        public InteractionZone EntryZone { get; set; }
        public InteractionZone LeaveZone { get; set; }


        public bool CheckIfInside(InteractionZone interactionZone) { return true; }

        private static float ToFeed(IEnumerable<Chicken> collection)
        {
            return collection.Sum(chicken => 100f - chicken.Hunger);
        }

        public void FeedAllChicken()
        {
            if ( CtxCollection.FindStorage<StorageSeed>().
                     Capacity < ToFeed(Chikens) )
                return;
            foreach ( Chicken chicken in Chikens ) chicken.ChickenFeed();
        }

        public void FeedAllDyingChicken()
        {
            if ( CtxCollection.FindStorage<StorageSeed>().
                     Capacity < ToFeed(DyingChickens) )
                return;
            foreach ( Chicken chicken in DyingChickens ) chicken.ChickenFeed();
            DyingChickens.Clear();
        }

        public void AddChicken(Chicken.Breed breed) { Chikens.Add(new Chicken(this, breed)); }

        public void FillRack<TRackType>(int amount) where TRackType : IRack
        {
            Racks.Find(rack => rack is TRackType).
                Fill(amount);
        }

        public void UpgradeRack<TRackType>() where TRackType : IRack
        {
            Racks.Find(rack => rack is TRackType).
                Upgrade();
        }

        public void Update()
        {
            foreach ( Chicken chicken in Chikens )
            {
                chicken.Update();
                if ( chicken.CheckIfStarving && !FindDyingChicken(chicken) ) DyingChickens.Add(chicken);
            }

            if ( !CheckIfAllDyingAreFed() ) CleanupDiedChicken();
        }

        public IEnumerable<Chicken> DyingChickens2 => Chikens.Where(c => c.Hunger <= 25);
        public IEnumerable<Chicken> DiedChickens => Chikens.Where(c => c.Hunger <= 0);


        private bool CheckIfAllDyingAreFed()
        {
            foreach ( Chicken chicken in DyingChickens )
                if ( chicken.Hunger <= 25 )
                    return false;
            return true;
        }

        private void CleanupDiedChicken()
        {
            foreach ( Chicken chicken in DiedChickens.ToList() )
                {
                    chicken.Die();
                    Chikens.Remove(chicken);
                }
        }

        private bool FindDyingChicken(Chicken chickenParam)
        {
            foreach ( Chicken chicken in DyingChickens )
                if ( chickenParam == chicken )
                    return true;
            return false;
        }
    }
}