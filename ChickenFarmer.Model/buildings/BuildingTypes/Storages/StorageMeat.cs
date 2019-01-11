using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public class StorageMeat : Storage
    {
        public StorageMeat(BuildingCollection ctx, IStorageFactory factory, Vector posVector) : base(ctx, factory,posVector) { }

        public StorageMeat(BuildingCollection ctx, IStorageFactory factory, XElement xElement) : base(ctx, factory, xElement) { }

        protected override string StorageName => "StorageMeat";
    }
}