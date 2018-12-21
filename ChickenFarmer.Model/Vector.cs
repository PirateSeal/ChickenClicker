#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public struct Vector
    {
        public Vector(float abs, float ord)
        {
            X = abs;
            Y = ord;
        }

        public float X { get; }

        public float Y { get; }

        public float Magnitude => ( float ) Math.Sqrt(X * X + Y * Y);
        public float MagnitudeInverse => ( float ) Math.Sqrt(X * X + Y * Y);

        public static Vector operator +(Vector v1, Vector v2) { return new Vector(v1.X + v2.X, v1.Y + v2.Y); }

        public static Vector operator -(Vector v1, Vector v2) { return new Vector(v1.X - v2.X, v1.Y - v2.Y); }

        public static Vector operator *(Vector v1, float nb) { return new Vector(v1.X * nb, v1.Y * nb); }

        public static Vector operator *(float nb, Vector v1) { return v1 * nb; }

        public static Vector operator /(Vector v1, float nb) { return new Vector(v1.X / nb, v1.Y / nb); }

        public float Distance(Vector v1, Vector v2)
        {
            float distance = ( float ) Math.Sqrt(Math.Pow(2, v2.X - v1.X) + Math.Pow(2, v2.Y - v1.Y));
            return distance;
        }

        public Vector Add(Vector vector) { return new Vector(X + vector.X, Y + vector.Y); }
    }
}