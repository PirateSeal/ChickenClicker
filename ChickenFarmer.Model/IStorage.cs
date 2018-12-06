namespace ChickenFarmer.Model
{
    public interface IStorage : IBuilding
    {
        int Capacity { get; set; }
        int MaxCapacity { get; set; }
        int Value { get; }
    }
}