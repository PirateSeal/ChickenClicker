namespace ChickenFarmer.Model
{
    class Chicken
    {
        private int _breed;
        private string _id;
        private float _hunger;
        FarmOptions _farmOptions;
        Henhouse _ctxHouse;

        public Chicken(Henhouse ctxHouse, int breed)
        {
            _breed = breed;
            _farmOptions = new FarmOptions();
            _id = System.Guid.NewGuid().ToString();
            _hunger = 100;
            _ctxHouse = ctxHouse;
        }

        public int Type => _breed;

        public void update()
        {
            Hunger -= 0.1f;
            Lay();
        }

        public void ChickenFeed()
        {

            _ctxHouse.CtxCollection.CtxFarm.FoodStock -= Type * _farmOptions.DefaultFoodConsumption;
            Hunger = 100;
        }

        public bool CheckIfStarving()
        {
            if (_hunger <= 25)
            {
                return true;
            }
            return false;
        }

        internal void Die()
        {
            _ctxHouse.CtxCollection.CtxFarm = null;
        }

        private void Lay() => _ctxHouse.CtxCollection.CtxFarm.addEgg();
        public float Hunger
        {
            get => _hunger;
            set => _hunger = value;
        }
    }
}
