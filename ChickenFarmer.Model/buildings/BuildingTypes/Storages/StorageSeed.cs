#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class StorageSeed : Storage

    {
        public StorageSeed(BuildingCollection ctx, IStorageFactory factory, Vector posVector) : base(ctx, factory,
            posVector)
        {
        }

        public StorageSeed(BuildingCollection ctx, IStorageFactory factory, XElement xElement) : base(ctx, factory,
            xElement)
        {
        }

        protected override string StorageName => "StorageSeed";
    }
}