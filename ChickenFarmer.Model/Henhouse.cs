#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class Henhouse : Building
    {
        public Henhouse( BuildingCollection ctx, Vector posVector ) : base( ctx, posVector )
        {
            CtxCollection = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            PosVector = posVector;
            MaxCapacity = ctx.CtxFarm.Options.DefaultHenHouseLimit;
            Lvl = 0;
            Chikens = new List<Chicken>( MaxCapacity * Lvl );
            DyingChickens = new List<Chicken>();
        }

        private FarmOptions Options => CtxCollection.CtxFarm.Options;
        public List<Chicken> Chikens { get; }
        private List<Chicken> DyingChickens { get; }

        public int ChickenCount => Chikens.Count;
        public int MaxCapacity { get; set; }

        public bool IsFull => ChickenCount == MaxCapacity;

        public int Lvl { get; private set; }

        public int CountDyingChickens => DyingChickens.Count;

        public void Upgrade()
        {
            Lvl ++;
            int newLimit = Options.DefaultHenHouseLimit * Lvl;
            MaxCapacity = newLimit;
        }

        private static float ToFeed( IEnumerable<Chicken> collection )
        {
            return collection.Sum( chicken =>
            {
                if ( chicken == null ) throw new ArgumentNullException( nameof(chicken) );

                return 100f - chicken.Hunger;
            } );
        }

        public void FeedAllChicken()
        {
            if ( CtxCollection.StorageBuilding.SeedCapacity < ToFeed( Chikens ) ) return;
            foreach ( Chicken chicken in Chikens ) chicken.ChickenFeed();
        }

        public void FeedAllDyingChicken()
        {
            if ( CtxCollection.StorageBuilding.SeedCapacity < ToFeed( DyingChickens ) ) return;
            foreach ( Chicken chicken in DyingChickens ) chicken.ChickenFeed();
            DyingChickens.Clear();
        }

        public void AddChicken( Chicken.Breed breed ) { Chikens.Add( new Chicken( this, breed ) ); }

        public void Update()
        {
            foreach ( Chicken chicken in Chikens )
            {
                chicken.Update();
                if ( chicken.CheckIfStarving && !FindDyingChicken( chicken ) )
                    DyingChickens.Add( chicken );
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
                    Chikens.Remove( chicken );
                }
        }

        private bool FindDyingChicken( Chicken chickenParam )
        {
            foreach ( Chicken chicken in DyingChickens )
                if ( chickenParam == chicken )
                    return true;
            return false;
        }
    }
}