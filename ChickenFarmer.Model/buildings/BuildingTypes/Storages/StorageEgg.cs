#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public class StorageEgg : Storage
    {
        public StorageEgg(BuildingCollection ctx, IStorageFactory factory, Vector posVector) : base(ctx, factory,
            posVector)
        {
        }

        public StorageEgg(BuildingCollection ctx, IStorageFactory factory, XElement e) : base(ctx, factory, e) { }

        protected override string StorageName => "StorageEgg";
    }
}