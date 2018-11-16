#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    internal class Chicken
    {
        public Chicken( Henhouse ctxHenhouse, int breed )
        {
            CtxHenhouse = ctxHenhouse ?? throw new ArgumentNullException( nameof(ctxHenhouse) );
            Breed = breed;
            Hunger = 100;
        }

        public bool CheckIfStarving => Hunger <= 25;

        private int Breed { get; }

        public float Hunger { get; private set; }

        private Henhouse CtxHenhouse { get; set; }
        private FarmOptions Options => CtxHenhouse.CtxBuildingCollection.CtxFarm.Options;

        public void Update()
        {
            Hunger -= Options.DefaultFoodConsumption * Breed;
            Lay();
        }

        public void ChickenFeed()
        {
            if ( CtxHenhouse != null )
                CtxHenhouse.CtxBuildingCollection.StorageBuilding.SeedCapacity -=
                    ( int ) Math.Round( Hunger );
            Hunger = 100;
        }

        internal void Die() { CtxHenhouse = null; }

        private void Lay() { CtxHenhouse.CtxBuildingCollection.CtxFarm.AddEgg(); }
    }
}