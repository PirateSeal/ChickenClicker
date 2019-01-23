#region Usings

using System;
using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class RackVegetable : IRack
    {
        public RackVegetable(Henhouse ctx)
        {
            CtxHenhouse = ctx;
            Capacity = 0;
            Lvl = 1;
        }

        public RackVegetable(Henhouse ctx, XElement xElement)
        {
            CtxHenhouse = ctx;
            Capacity = int.Parse(xElement.Attribute(nameof(Capacity))?.
                                     Value ?? throw new InvalidOperationException(nameof(Capacity)));
            Lvl = int.Parse(xElement.Attribute(nameof(Lvl))?.
                                Value ?? throw new InvalidOperationException(nameof(Lvl)));
        }

        public Henhouse CtxHenhouse { get; set; }
        public int Capacity { get; set; }

        public int MaxCapacity
        {
            get => 350;
            set { }
        }

        public int Lvl { get; set; }
        public int UpgrageCost => FarmOptions.DefaultVegetableRackPrice * Lvl;

        public int Fill(int amount)
        {
            int remain = 0;
            if ( Capacity + amount <= MaxCapacity && amount <= CtxHenhouse.CtxCollection.
                     FindStorage<StorageVegetable>().
                     Capacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<StorageVegetable>().
                    Capacity -= amount;
                Capacity += amount;
            }
            else if ( Capacity + amount > MaxCapacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<StorageVegetable>().
                    Capacity -= amount;
                Capacity = MaxCapacity;
                remain = Capacity + amount - MaxCapacity;
            }

            return remain;
        }

        public void Upgrade() { Lvl ++; }

        public XElement ToXml()
        {
            return new XElement("RackVegetable", new XAttribute(nameof(Capacity), Capacity),
                new XAttribute(nameof(MaxCapacity), MaxCapacity), new XAttribute(nameof(Lvl), Lvl));
        }
    }
}