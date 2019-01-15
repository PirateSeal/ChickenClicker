#region Usings

using System.Collections.Generic;

#endregion

namespace ChickenFarmer.Model
{
    public class CollideCollection
    {
        private List<CollideObject> _collideList = new List<CollideObject>();

        public CollideCollection(Farm farm) { CtxFarm = farm; }

        public Farm CtxFarm { get; }

        internal List<CollideObject> CollideList
        {
            get => CollideList;
            set => CollideList = value;
        }

        public void AddObject(Vector pos, float width, float height)
        {
            CollideObject collidable = new CollideObject(pos, width, height);
            _collideList.Add(collidable);
        }

        public void LoadBuilingsCollide()
        {
            foreach ( IBuilding item in CtxFarm.Buildings.BuildingList ) AddObject(item.PosVector, 64, 96);
        }

        public bool IsCollide(CollideObject obj)
        {
            bool intersect = false;
            foreach ( CollideObject item in _collideList )
                if ( Collide(obj.Origin.X, obj.Origin.Y, obj.Width, obj.Height, item.Origin.X,
                             item.Origin.Y, item.Width, item.Height) )
                {
                    intersect = true;
                    break;
                }

            return intersect;
        }

        public void Clear() { _collideList.Clear(); }

        private bool Collide(float x1, float y1, float width1, float height1, float x2,
            float y2, float width2, float height2)
        {
            return!(x1 > x2 + width2 || x1 + width1 < x2 || y1 > y2 + height2 || y1 + height1 < y2);
        }
    }
}