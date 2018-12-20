using System;

namespace ChickenFarmer.Model
{
    internal class ChickenStoreFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt++;
            return new Builder(ctx, this, posVector);
        }

        public void OnRemove(IBuilding building) { NbrBuilt--; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
    }
}
