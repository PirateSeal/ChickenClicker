using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    internal class EggStorageFactory : IStorageFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new StorageEgg(ctx, this, posVector);
        }

        public IBuilding Create(BuildingCollection ctx, XElement xElement) { throw new System.NotImplementedException(); }

        public void OnRemove(IBuilding building) { NbrBuilt --; }

        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
        public int DefaultCapacity => FarmOptions.DefaultEggCapacity;
    }
}