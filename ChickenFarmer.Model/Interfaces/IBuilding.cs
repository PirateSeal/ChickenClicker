using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public interface IBuilding
    {
        BuildingCollection CtxCollection { get; set; }
        Vector PosVector { get; set; }
        int Lvl { get; set; }
        IBuildingFactory Factory { get; }
        void Upgrade();
        XElement Serialize();
    }
}