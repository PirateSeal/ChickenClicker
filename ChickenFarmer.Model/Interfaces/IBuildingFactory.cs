using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public interface IBuildingFactory
    {
        int NbrBuilt { get; set; }
        bool IsEnabled { get; }
        IBuilding Create(BuildingCollection ctx, Vector posVector);
        IBuilding Create(BuildingCollection ctx, XElement xElement);
        void OnRemove(IBuilding        building);
    }
}