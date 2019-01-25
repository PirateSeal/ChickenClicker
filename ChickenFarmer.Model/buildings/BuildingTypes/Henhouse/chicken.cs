#region Usings

using System;
using System.Xml.Linq;

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
            Random r = new Random();
            IsAlive = true;
            PredateChance = r.Next(0, 20000);
        }

        public Chicken(Henhouse ctxHenhouse, XElement xElement)
        {
            CtxHenhouse = ctxHenhouse;
            ChikenBreed = ( Breed ) int.Parse(xElement?.Attribute(nameof(ChikenBreed))?.
                                                  Value ?? throw new InvalidOperationException(nameof(Breed)));
            Hunger = float.Parse(xElement.Attribute(nameof(Hunger))?.
                                     Value ?? throw new InvalidOperationException());
        }

        private Breed ChikenBreed { get; }

        public float Hunger { get; set; }

        public bool IsAlive { get; set; }

        public Henhouse CtxHenhouse { get; set; }

        public int PredateChance { get; set; }

        public XElement ToXml()
        {
            return new XElement("Chicken", new XAttribute(nameof(ChikenBreed), ( int ) ChikenBreed),
                new XAttribute(nameof(Hunger), Hunger));
        }

        public void Update()
        {
            Hunger -= FarmOptions.DefaultFoodConsumption * ( int ) ChikenBreed;
            Peck();
            Lay();
            Predate(PredateChance);
        }
        

        private void Predate(int predateChance)
        {
            Random r = new Random();
            int random = r.Next(0, predateChance);
            if ( random == 0 )
                Die();
            else
                PredateChance = r.Next(0, 20000);
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
                            if ( Hunger > 100f ) Hunger = 100f;

                            break;
                        }
                    }

                    if ( rack.Capacity > 0 )
                    {
                        rack.Capacity --;
                        Hunger += 2;
                        if ( Hunger > 100f ) Hunger = 100f;

                        break;
                    }
                }

                if ( rack.Capacity > 0 )
                {
                    rack.Capacity --;
                    Hunger += 5;
                    if ( Hunger > 100f ) Hunger = 100f;

                    break;
                }
            }
        }

        internal void Die() {
            CtxHenhouse = null;
            IsAlive = false;
        }

        private void Lay()
        {
            if ( Hunger > 20 ) CtxHenhouse.CtxCollection.CtxFarm.AddEgg();
        }
    }
}