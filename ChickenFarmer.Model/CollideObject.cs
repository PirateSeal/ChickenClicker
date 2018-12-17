using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmer.Model
{

    public class CollideObject
    {
        Vector _origin;
        Vector DownRight;
        float _width;
        float _height;

        public CollideObject(Vector origin, float width, float height)
        {
            Origin = origin;
            Width = width;
            Height = height;
            DownRight = new Vector(Origin.X + Width, Origin.Y + Height);
        }

        public Vector Origin { get => _origin; set => _origin = value; }
        public float Width { get => _width; set => _width = value; }
        public float Height { get => _height; set => _height = value; }
        public Vector DownRight1 { get => DownRight; set => DownRight = value; }
    }
}
