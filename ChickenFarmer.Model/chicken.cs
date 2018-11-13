using System;

namespace ChickenFarmer.Model
{
    class Chicken
    {
        Henhouse _ctxHenhouse;
        FarmOptions _options;
        private readonly int _breed;
        private float _hunger;

        public Chicken(Henhouse ctxHenhouse, FarmOptions options, int breed)
        {
            _ctxHenhouse = ctxHenhouse ?? throw new ArgumentNullException(nameof(ctxHenhouse));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _breed = breed;
            _hunger = 100;
        }

        public void Update()
        {
            Hunger -= _options.DefaultFoodConsumption * _breed;
            Lay();
        }

        public void ChickenFeed()
        {
            CtxFarm.Buildings.SeedCapacity -= (int)Math.Round(Hunger);
            Hunger = 100;
        }

        internal void Die() => _ctxHenhouse = null;

        public Farm CtxFarm => _ctxHenhouse.Collection.CtxFarm;
        public bool CheckIfStarving => _hunger <= 25 ? true : false;
        private void Lay() => CtxFarm.AddEgg();
        public int Breed => _breed;
        public float Hunger { get => _hunger; set => _hunger = value; }
    }
}
