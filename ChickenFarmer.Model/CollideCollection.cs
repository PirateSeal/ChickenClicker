using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    public class CollideCollection
    {
        List<CollideObject> _collideList = new List<CollideObject>();
        public Farm CtxFarm { get; }

        public CollideCollection(Farm farm)
        {
            CtxFarm = farm;

        }
        public void AddObject(Vector pos, float width, float height)
        {
            CollideObject collidable = new CollideObject(pos, width, height);
            _collideList.Add(collidable);

        }


        public bool IsCollide(CollideObject obj)
        {
            bool intersect = false;
            foreach (CollideObject item in _collideList)
                if (Collide(obj.Origin.X, obj.Origin.Y, obj.Width, obj.Height, item.Origin.X, item.Origin.Y, item.Width, item.Height))
                {
                    intersect = true;
                    break;
                }

            return intersect;
        }

        bool Collide(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
        {
            return !(x1 > x2 + width2 || x1 + width1 < x2 || y1 > y2 + height2 || y1 + height1 < y2);
        }

        internal List<CollideObject> CollideList
        {
            get => CollideList;
            set => CollideList = value;
        }
        }
}
