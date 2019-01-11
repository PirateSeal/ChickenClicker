using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public class RackSeed : IRack
    {
        public RackSeed(Henhouse ctx)
        {
            CtxHenhouse = ctx;
            Capacity = 0;
            Lvl = 1;
        }

        public Henhouse CtxHenhouse { get; set; }
        public int Capacity { get; set; }

        public int MaxCapacity
        {
            get => 500;
            set { }
        }

        public int Lvl { get; set; }
        public int UpgrageCost => FarmOptions.DefaultSeedRackPrice * Lvl;

        public int Fill(int amount)
        {
            int remain = 0;
            if ( Capacity + amount <= MaxCapacity && amount <= CtxHenhouse.CtxCollection.FindStorage<StorageSeed>().
                     Capacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<StorageSeed>().
                    Capacity -= amount;
                Capacity += amount;
            }
            else if ( Capacity + amount > MaxCapacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<StorageSeed>().
                    Capacity -= amount;
                Capacity = MaxCapacity;
                remain = Capacity + amount - MaxCapacity;
            }

            return remain;
        }

        public void Upgrade() { Lvl ++; }

        public XElement ToXml()
        {
            return new XElement("SeedRack",
                new XAttribute(nameof(Capacity),Capacity),
                new XAttribute(nameof(MaxCapacity), MaxCapacity),
                new XAttribute(nameof(Lvl), Lvl)
                );
        }
    }
}