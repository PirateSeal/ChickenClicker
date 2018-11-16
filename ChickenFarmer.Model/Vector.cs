#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public struct Vector
    {
        public Vector( double abs, double ord )
        {
            X = abs;
            Y = ord;
        }

        private double X { get; }

        private double Y { get; }

        public double Magnitude => Math.Sqrt( X * X + Y * Y );
        public double MagnitudeInverse => Math.Sqrt( X * X + Y * Y );

        public static Vector operator +( Vector v1, Vector v2 )
        {
            return new Vector( v1.X + v2.X, v1.Y + v2.Y );
        }

        public static Vector operator -( Vector v1, Vector v2 )
        {
            return new Vector( v1.X - v2.X, v1.Y - v2.Y );
        }

        public static Vector operator *( Vector v1, double nb )
        {
            return new Vector( v1.X * nb, v1.Y * nb );
        }

        public static Vector operator *( double nb, Vector v1 ) { return v1 * nb; }

        public static Vector operator /( Vector v1, double nb )
        {
            return new Vector( v1.X / nb, v1.Y / nb );
        }

        public float Distance( Vector v1, Vector v2 )
        {
            var distance =
                ( float ) Math.Sqrt( Math.Pow( 2, v2.X - v1.X ) + Math.Pow( 2, v2.Y - v1.Y ) );
            return distance;
        }
    }
}