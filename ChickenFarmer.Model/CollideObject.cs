using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmer.Model
{

    public class CollideObject
    {
        public CollideObject(Vector origin, float width, float height)
        {
            Origin = origin;
            Width = width;
            Height = height;
            DownRight = new Vector(Origin.X + Width, Origin.Y + Height);
        }

        public Vector Origin { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Vector DownRight { get; set; }
    }
}
