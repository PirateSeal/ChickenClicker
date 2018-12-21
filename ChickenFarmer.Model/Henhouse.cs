#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class Henhouse : IBuilding, IInteractible
    {
        public Henhouse(BuildingCollection ctx, IBuildingFactory factory, Vector posVector)
        {
            CtxCollection = ctx ?? throw new ArgumentNullException(nameof(ctx));
            PosVector = posVector;
            Racks = new List<IRack> { new SeedRack(this) };
            Factory = factory;
            MaxCapacity = FarmOptions.DefaultHenHouseLimit;
            Lvl = 0;
            Chikens = new List<Chicken>(MaxCapacity * Lvl);
            DyingChickens = new List<Chicken>();
            var interactionZonePos = new Vector(posVector.X+20, PosVector.Y + 96);
            InteractionZone = new InteractionZone(interactionZonePos,15 , 15);
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

        public InteractionZone InteractionZone { get; set; }

        public bool CheckIfInside(InteractionZone interactionZone) { return true; }

        private static float ToFeed(IEnumerable<Chicken> collection)
        {
            return collection.Sum(chicken => 100f - chicken.Hunger);
        }

        public void FeedAllChicken()
        {
            if ( CtxCollection.FindStorage<SeedStorage>().
                     Capacity < ToFeed(Chikens) )
                return;
            foreach ( Chicken chicken in Chikens ) chicken.ChickenFeed();
        }

        public void FeedAllDyingChicken()
        {
            if ( CtxCollection.FindStorage<SeedStorage>().
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

            if ( !CheckIfAllDyingAreFed() ) KillStarvingChicken();
        }

        private bool CheckIfAllDyingAreFed()
        {
            foreach ( Chicken chicken in DyingChickens )
                if ( chicken.Hunger <= 25 )
                    return false;
            return true;
        }

        private void KillStarvingChicken()
        {
            foreach ( Chicken chicken in DyingChickens )
                if ( chicken.Hunger <= 0 )
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