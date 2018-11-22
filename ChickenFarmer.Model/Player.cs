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
            _position = new Vector(200, 200);
            _life = ctxFarm.Options.DefaultPlayerLife;
            _speed = ctxFarm.Options.DefaultPlayerMaxSpeed;
            _inventory = new List<Building>();
        }

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        


        
        

        

             
    
    }
}
