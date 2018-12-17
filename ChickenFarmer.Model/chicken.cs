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
            Hunger -= FarmOptions.DefaultFoodConsumption * (int)ChikenBreed;
            Lay();
        }

        public void ChickenFeed()
        {
            if (CtxHenhouse != null)
                CtxHenhouse.CtxCollection.FindStorage<SeedStorage>().Capacity -=
                    (int)Math.Round(Hunger);
            Hunger = 100;
        }

        public void Peck()
        {
            if (CtxHenhouse.Racks.Find(rack => rack is MeatRack).
                     Capacity <= 0)
            {
                if (CtxHenhouse.Racks.Find(rack => rack is VegetableRack).
                         Capacity <= 0)
                {
                    CtxHenhouse.Racks.Find(rack => rack is SeedRack).
                        Capacity--;
                    Hunger++;
                }
                CtxHenhouse.Racks.Find(rack => rack is VegetableRack).
                    Capacity--;
                Hunger += 2;

            }
            CtxHenhouse.Racks.Find(rack => rack is MeatRack).
                Capacity--;
            Hunger += 5;
        }

        internal void Die() { CtxHenhouse = null; }

        private void Lay() { CtxHenhouse.CtxCollection.CtxFarm.AddEgg(); }
    }
}