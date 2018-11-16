#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.Model
{
    public class Henhouse : Building
    {
        private readonly List<Chicken> _dyingChickens;

        public Henhouse( BuildingCollection ctx, int xCoord, int yCoord ) : base( ctx, xCoord,
            yCoord )
        {
            CtxBuildingCollection = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            XCoord = xCoord;
            YCoord = yCoord;
            Limit = ctx.CtxFarm.Options.DefaultHenhouseCapacity;
            Lvl = 0;
            Chikens = new List<Chicken>( Limit * Lvl );
            _dyingChickens = new List<Chicken>();
        }

        internal BuildingCollection CtxBuildingCollection { get; }
        private int XCoord { get; }
        private int YCoord { get; }
        private FarmOptions Options => CtxBuildingCollection.CtxFarm.Options;
        internal List<Chicken> Chikens { get; }

        public int ChickenCount => Chikens.Count;
        public int Limit { get; private set; }

        public bool IsFull => ChickenCount == Limit;

        public int Lvl { get; private set; }

        private int CountDyingChickens => _dyingChickens.Count;

        public void Upgrade()
        {
            Lvl ++;
            var newLimit = Options.DefaultHenHouseLimit * Lvl;
            Limit = newLimit;
        }

        public void FeedChicken()
        {
            if ( CtxBuildingCollection.StorageBuilding.SeedCapacity < CountDyingChickens ) return;
            foreach ( var chicken in Chikens ) chicken.ChickenFeed();
        }

        public void AddChicken( int breed ) { Chikens.Add( new Chicken( this, breed ) ); }

        public void Update()
        {
            foreach ( var item in Chikens )
            {
                item.Update();
                if ( item.CheckIfStarving && !FindDyingChicken( item ) ) _dyingChickens.Add( item );
            }

            if ( !CheckIfAllDyingAreFed() ) KillStarvingChicken();
        }

        private bool CheckIfAllDyingAreFed()
        {
            foreach ( var chicken in _dyingChickens )
                if ( chicken.Hunger <= 25 )
                    return false;
            return true;
        }

        private void KillStarvingChicken()
        {
            foreach ( var chicken in _dyingChickens )
                if ( chicken.Hunger <= 0 )
                {
                    chicken.Die();
                    Chikens.Remove( chicken );
                }

            _dyingChickens.Clear();
        }

        private bool FindDyingChicken( Chicken chickenParam )
        {
            foreach ( var chicken in _dyingChickens )
                if ( chickenParam == chicken )
                    return true;
            return false;
        }
    }
}