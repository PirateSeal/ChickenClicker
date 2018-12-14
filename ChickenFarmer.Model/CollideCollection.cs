using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmer.Model
{
    public class CollideCollection
    {
        List<CollideObject> _collideList = new List<CollideObject>();
        Farm _ctxFarm;


        public CollideCollection(Farm farm)
        {
            _ctxFarm = farm;

        }
        public void AddObject(Vector pos , float width, float height)
        {
            var collidable = new CollideObject(pos, width, height);
            _collideList.Add(collidable);
            
        }
        public bool IsCollide(CollideObject player)
        {
            var intersect = false;
            foreach (var item in _collideList)
                if(Collide(player.Origin.X, player.Origin.Y, player.Width,player.Height, item.Origin.X, item.Origin.Y, item.Width, item.Height))
                {
                    intersect = true;
                    break;
                }

            return intersect;
        }

        bool Collide(float x_1, float y_1, float width_1, float height_1, float x_2, float y_2, float width_2, float height_2)
        {
            return !(x_1 > x_2 + width_2 || x_1 + width_1 < x_2 || y_1 > y_2 + height_2 || y_1 + height_1 < y_2);
        }

        internal List<CollideObject> CollideList { get => CollideList; set => CollideList = value; }

        

    }
}
