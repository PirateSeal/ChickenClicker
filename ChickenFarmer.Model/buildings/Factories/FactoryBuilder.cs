#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    internal class BuilderFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new Builder(ctx, this, posVector);
        }

        public IBuilding Create(BuildingCollection ctx, XElement xElement)
        {
            NbrBuilt ++;
            return new Builder(ctx, this, xElement);
        }

        public void OnRemove(IBuilding building) { NbrBuilt --; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
    }
}