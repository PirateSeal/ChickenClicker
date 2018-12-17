using System;
using System.Collections.Generic;



namespace ChickenFarmer.Model
{
    public class Player
    {
        public int Life { get; }
        public float Speed { get; }
        public Vector Position { get; set; }
        public List<IBuilding> Inventory { get; }
        public Farm CtxFarm { get; }
        public Vector Direction { get; set; }
        public CollideObject _boundingBox;

        public Player(Farm ctxFarm)
        {
            CtxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            Position = new Vector(abs: 1280/2, ord: 720/2); // divise par 2 pour centrer le joueur dans la view de la gameloop. A changer
            Life = FarmOptions.DefaultPlayerLife;
            Speed = FarmOptions.DefaultPlayerMaxSpeed;
            Inventory = new List<IBuilding>();
            var _boundingBoxPos = new Vector(_position.X, Position.Y - 16);
            _boundingBox = new CollideObject(_boundingBoxPos, 16, 16);
        }

        public void Move(Vector direction)
        {
            if ((direction.X == 5 || direction.X == -5) && (direction.Y == 5 || direction.Y == -5)) Direction = (direction / 1.5f);
            
            else _direction = direction;
                     
            if (CanMove(movement))
            {
                
                _position = newPosition;
                _boundingBox.Origin = _position;
            }
             

            Vector movement = Direction * Speed;
            Vector newPosition = Position.Add(movement);
        }

        public bool CanMove(Vector direction)
        {
            var nextPos = _position + direction;
            var _boundingBoxPos = new Vector(nextPos.X, nextPos.Y + 16);
            var newbox = new CollideObject(_boundingBoxPos, 16, 16);
            return !_ctxFarm.CollideCollection.IsCollide(newbox);
        }


        public Vector Direction
        {
            get { return _direction; }
        }
        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        


        
        

        

             
    
    }
}
