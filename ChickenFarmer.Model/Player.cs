#region Usings

using System;
using System.Xml.Linq;

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
            Vector boundingBoxPos = new Vector(Position.X, Position.Y - 16);
            BoundingBox = new CollideObject(boundingBoxPos, 16, 16);
        }

        public Player(Farm ctxFarm, XContainer xElement) : this(ctxFarm)
        {
            XElement xPlayer = xElement.Element("Player");
            Position = new Vector((float)xPlayer?.Attribute(nameof(Position.X)), (float)xPlayer?.Attribute(nameof(Position.Y)));
            Life = (int)xPlayer?.Attribute(nameof(Life));
        }

        public int Life { get; }
        public float Speed { get; }
        public Vector Position { get; set; }
        public Farm CtxFarm { get; }
        public Vector Direction { get; set; }
        public CollideObject BoundingBox { get; }

        public void Move(Vector direction)
        {
            if ((direction.X == 5 || direction.X == -5) && (direction.Y == 5 || direction.Y == -5))
                Direction = direction / 1.5f;

            else
                Direction = direction;

            Vector movement = Direction * Speed;
            Vector newPosition = Position.Add(movement);

            if (CanMove(movement))
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
            return !CtxFarm.CollideCollection.IsCollide(newbox);
        }

        public XElement ToXml()
        {
            return new XElement("Player",
                                new XAttribute(nameof(Position.X), Position.X),
                                new XAttribute(nameof(Position.Y), Position.Y),
                                new XAttribute(nameof(Life), Life));
        }
    }
}