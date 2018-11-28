using System;
using System.Collections.Generic;


namespace ChickenFarmer.Model
{
    public class Player
    {
        public int _life;
        public float _speed;
        public Vector _position;
        public List<Building> _inventory;
        public Farm _ctxFarm;
        public Vector _direction;

        public Player(Farm ctxFarm)
        {
            _ctxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            _position = new Vector(1280/2, 720/2); // divise par 2 pour centrer le joueur dans la view de la gameloop. A changer
            _life = ctxFarm.Options.DefaultPlayerLife;
            _speed = ctxFarm.Options.DefaultPlayerMaxSpeed;
            _inventory = new List<Building>();
        }

        public void Move(Vector direction)
        {
            _direction = direction;
            Vector movement = _direction * _speed;
            Vector newPosition = _position.Add(movement);
            _position = newPosition;
            //Console.WriteLine("Position Joueur X = {0} Y = {1}", Position.X, Position.Y);
        }


        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        


        
        

        

             
    
    }
}
