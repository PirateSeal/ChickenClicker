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

        public Player(Farm ctxFarm)
        {
            CtxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            Position = new Vector(abs: 1280/2, ord: 720/2); // divise par 2 pour centrer le joueur dans la view de la gameloop. A changer
            Life = FarmOptions.DefaultPlayerLife;
            Speed = FarmOptions.DefaultPlayerMaxSpeed;
            Inventory = new List<IBuilding>();
        }

        public void Move(Vector direction)
        {
            if ((direction.X == 5 || direction.X == -5) && (direction.Y == 5 || direction.Y == -5)) Direction = (direction / 1.5f);
            
            else Direction = direction;
            
           
            //Console.WriteLine("direction X = {0} Y = {1}", _direction.X, _direction.Y);
            Vector movement = Direction * Speed;
            Vector newPosition = Position.Add(movement);
            
            Position = newPosition;
            //Console.WriteLine("Position Joueur X = {0} Y = {1}", Position.X, Position.Y);
        }


        
        


        
        

        

             
    
    }
}
