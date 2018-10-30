namespace ChickenFarmer.Model
{
    class Chicken
    {
        private readonly int _breed;
        private int _hunger;
        Henhouse _ctxHenhouse;
        FarmOptions _options;

        public Chicken(Henhouse henhouse, FarmOptions farmOptions, int breed)
        {
            _breed = breed;
            _options = farmOptions;
            _hunger = 100;
            _ctxHenhouse = henhouse;
        }


        public void Update()
        {
            Hunger--;
            Lay();
        }

        public void ChickenFeed()
        {
            CtxFarm.Storage.SeedCapacity -= Breed * _options.DefaultFoodConsumption;
            Hunger = 100;
        }

        internal void Die()
        {
            _ctxHenhouse = null;
        }

        public Farm CtxFarm => _ctxHenhouse.Collection.Farm;
        public bool CheckIfStarving => _hunger <= 25 ? true : false;
        private void Lay() => CtxFarm.AddEgg();
        public int Breed => _breed;
        public int Hunger { get => _hunger; set => _hunger = value; }
    }
}
