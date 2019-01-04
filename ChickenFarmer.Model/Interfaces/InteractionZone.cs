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

        public bool Isin(CollideObject obj)
        {
            return!(Origin.X > obj.Origin.X + obj.Width || Origin.X + Width < obj.Origin.X ||
                    Origin.Y > obj.Origin.Y + obj.Height || Origin.Y + Height < obj.Origin.Y);
        }
    }
}