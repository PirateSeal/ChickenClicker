#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    internal class Pnj : ICharacter
    {
        public Pnj(Farm ctxFarm, float xCoord, float yCoord)
        {
            if ( xCoord <= 0 ) throw new ArgumentOutOfRangeException(nameof(xCoord));
            if ( yCoord <= 0 ) throw new ArgumentOutOfRangeException(nameof(yCoord));
            CtxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            Position = new Vector(xCoord, yCoord);
            Vector interactionZonePos = new Vector(Position.X - 16, Position.Y - 16);
            Life = FarmOptions.DefaultPlayerLife;
            Speed = FarmOptions.DefaultPlayerMaxSpeed;
            Vector boundingBoxPos = new Vector(Position.X, Position.Y - 16);
            BoundingBox = new CollideObject(boundingBoxPos, 16, 16);
            InteractionZone = new InteractionZone(interactionZonePos, 50, 60);
        }

        public int Life { get; }
        public float Speed { get; }
        public Vector Position { get; set; }
        public Farm CtxFarm { get; }
        public Vector Direction { get; set; }
        public CollideObject BoundingBox { get; }
        InteractionZone InteractionZone { get; set; }

        public void Move(Vector direction)
        {
            if ( (direction.X == 5 || direction.X == -5) && (direction.Y == 5 || direction.Y == -5) )
                Direction = direction / 1.5f;

            else
                Direction = direction;

            Vector movement = Direction * Speed;
            Vector newPosition = Position.Add(movement);

            if ( CanMove(movement) )
            {
                Position = newPosition;
                BoundingBox.Origin = Position;
            }
        }

        public bool CanMove(Vector direction)
        {
            Vector nextPos = Position + direction;
            Vector boundingBoxPos = new Vector(nextPos.X, nextPos.Y + 16);
            CollideObject newbox = new CollideObject(boundingBoxPos, 16, 16);
            return!CtxFarm.CollideCollection.IsCollide(newbox);
        }
    }
}