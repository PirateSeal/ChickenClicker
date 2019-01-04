#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Chicken
    {
        public enum Breed
        {
            None = 0,
            Tier1 = 1,
            Tier2 = 2,
            Tier3 = 3,
            Tier4 = 4
        }

        public Chicken(Henhouse ctxHenhouse, Breed chikenBreed)
        {
            CtxHenhouse = ctxHenhouse ?? throw new ArgumentNullException(nameof(ctxHenhouse));
            ChikenBreed = chikenBreed;
            Hunger = 100;
        }

        public bool CheckIfStarving => Hunger <= 25;

        private Breed ChikenBreed { get; }

        public float Hunger { get; private set; }

        private Henhouse CtxHenhouse { get; set; }

        public void Update()
        {
            Hunger -= FarmOptions.DefaultFoodConsumption * ( int ) ChikenBreed;
            Peck();
            Lay();
        }

        public void ChickenFeed()
        {
            if ( CtxHenhouse != null )
                CtxHenhouse.CtxCollection.FindStorage<StorageSeed>().
                    Capacity -= ( int ) Math.Round(Hunger);
            Hunger = 100;
        }

        public void Peck()
        {
            foreach ( IRack rack in CtxHenhouse.Racks )
            {
                if ( !(rack is RackMeat) )
                {
                    if ( !(rack is RackVegetable) )
                    {
                        if ( !(rack is RackSeed) ) throw new InvalidOperationException("Incorrect Rack type");
                        if ( rack.Capacity > 0 )
                        {
                            rack.Capacity --;
                            Hunger ++;
                            break;
                        }
                    }

                    if ( rack.Capacity > 0 )
                    {
                        rack.Capacity --;
                        Hunger += 2;
                        break;
                    }
                }

                if ( rack.Capacity > 0 )
                {
                    rack.Capacity --;
                    Hunger += 5;
                    break;
                }
            }
        }

        internal void Die() { CtxHenhouse = null; }

        private void Lay()
        {
            if ( Hunger > 20 ) CtxHenhouse.CtxCollection.CtxFarm.AddEgg();
        }
    }
}