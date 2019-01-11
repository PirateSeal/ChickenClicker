using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public abstract class Storage : IStorage
    {
        protected Storage(BuildingCollection ctx, IStorageFactory factory, Vector posVector)
        {
            CtxCollection = ctx;
            PosVector = posVector;
            Factory = factory;
            Capacity = FarmOptions.DefaultMeatCapacity;
            MaxCapacity = FarmOptions.DefaultMeatMaxCapacity;
        }

        protected Storage(BuildingCollection ctx, IStorageFactory factory, XElement xElement)
        {
            CtxCollection = ctx;
            Factory = factory;
            PosVector = new Vector((float)xElement.Attribute(nameof(PosVector.X)), (float)xElement.Attribute(nameof(PosVector.Y)));
            Capacity = (int)xElement.Element(nameof(Capacity));
            MaxCapacity = (int)xElement.Element(nameof(MaxCapacity));
        }

        public XElement ToXml()
        {
            return new XElement(StorageName,
                new XAttribute(nameof(PosVector.X), PosVector.X),
                new XAttribute(nameof(PosVector.Y), PosVector.Y),
                new XAttribute(nameof(Lvl), Lvl),
                new XAttribute(nameof(Capacity), Capacity),
                new XAttribute(nameof(MaxCapacity), MaxCapacity)
            );
        }

        protected abstract string StorageName { get; }

        public BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; set; }
        public int Lvl { get; set; }
        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public int Value => FarmOptions.EggValue;
        public IStorageFactory Factory { get; set; }

        IBuildingFactory IBuilding.Factory => Factory;

        public void Upgrade()
        {
            Lvl++;
            MaxCapacity *= Lvl;
        }

    }
}
