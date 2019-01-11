using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    internal class MeatStorageFactory : IStorageFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new StorageMeat(ctx, this, posVector);
        }

        public IBuilding Create(BuildingCollection ctx, XElement xElement)
        {
            NbrBuilt ++;
            return new StorageMeat(ctx, this,  xElement);
        }

        public void OnRemove(IBuilding building) { NbrBuilt --; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
        public int DefaultCapacity => FarmOptions.DefaultMeatCapacity;
    }
}