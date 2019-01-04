namespace ChickenFarmer.Model
{
    public interface IStorageFactory : IBuildingFactory
    {
        int DefaultCapacity { get; }
    }
}