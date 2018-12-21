#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.Model
{
    public class Player : ICharacter
    {
        public Player(Farm ctxFarm)
        {
            CtxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            Position = new Vector(1280 / 2,
                720 / 2); // divise par 2 pour centrer le joueur dans la view de la gameloop. A changer
            Life = FarmOptions.DefaultPlayerLife;
            Speed = FarmOptions.DefaultPlayerMaxSpeed;
            Inventory = new List<IBuilding>();
            Vector boundingBoxPos = new Vector(Position.X, Position.Y - 16);
            BoundingBox = new CollideObject(boundingBoxPos, 16, 16);
        }

        public List<IBuilding> Inventory { get; }
        public int Life { get; }
        public float Speed { get; }
        public Vector Position { get; set; }
        public Farm CtxFarm { get; }
        public Vector Direction { get; set; }
        public CollideObject BoundingBox { get; }

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