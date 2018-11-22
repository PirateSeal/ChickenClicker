using System;
using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    internal class Player
    {
        public int Life { get; }
        public float MaxSpeed { get; }
        public float Speed { get; }
        public Vector PosVector { get; }
        public List<Type> Inventory { get; }
        public Farm CtxFarm { get; }

        public Player(Farm ctxFarm, Vector posVector)
        {
            CtxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            PosVector = posVector;
            Life = 10;
            MaxSpeed = ctxFarm.Options.DefaultPlayerMaxSpeed;
        }
    }
}
