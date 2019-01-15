namespace ChickenFarmer.Model
{
    internal interface ICharacter
    {
        int Life { get; }
        float Speed { get; }
        Vector Position { get; set; }
        Farm CtxFarm { get; }
        Vector Direction { get; set; }
        CollideObject BoundingBox { get; }
        void Move(Vector direction);
        bool CanMove(Vector direction);
    }
}