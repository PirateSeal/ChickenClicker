using System;
using System.Collections.Generic;



namespace ChickenFarmer.Model
{
    public class Player
    {
        public int _life;
        public float _speed;
        public Vector _position;
        public List<IBuilding> _inventory;
        public Farm _ctxFarm;
        public Vector _direction;
        public CollideObject _boundingBox;

        public Player(Farm ctxFarm)
        {
            _ctxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            _position = new Vector(1280/2, 720/2); // divise par 2 pour centrer le joueur dans la view de la gameloop. A changer
            _life = ctxFarm.Options.DefaultPlayerLife;
            _speed = _ctxFarm.Options.DefaultPlayerMaxSpeed;
            _inventory = new List<IBuilding>();

            var _boundingBoxPos = new Vector(_position.X, Position.Y - 16);
            _boundingBox = new CollideObject(_boundingBoxPos, 16, 16);
        }

        public void Move(Vector direction)
        {
            if ((direction.X == 5 || direction.X == -5) && (direction.Y == 5 || direction.Y == -5)) _direction = (direction / 1.5f);
            
            else _direction = direction;
                     
            Vector movement = _direction * _speed;
            Vector newPosition = _position.Add(movement);
            if (CanMove(movement))
            {
                
                _position = newPosition;
                _boundingBox.Origin = _position;
            }
             

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
