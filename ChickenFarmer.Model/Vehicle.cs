namespace ChickenFarmer.Model
{
    internal class Vehicle
    {
        public Vehicle(Vector posVector) { PosVector = posVector; }
        public float MovementSpeed { get; set; }
        public bool IsDriving { get; set; }
        public Vector PosVector { get; set; }
    }
}