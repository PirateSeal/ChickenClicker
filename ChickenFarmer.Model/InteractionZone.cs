namespace ChickenFarmer.Model
{
    public class InteractionZone : CollideObject
    {

        public InteractionZone(Vector origin, float width, float height) : base(origin, width, height)
        {
            Origin = origin;
            Width = width;
            Height = height;
        }
    }
}
