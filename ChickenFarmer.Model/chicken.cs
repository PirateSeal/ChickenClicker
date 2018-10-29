namespace ChickenFarmer.Model
{
    class Chicken
    {
        private int _breed;
        private string _id;
        private int _hunger;
        Farm _farm;
        FarmOptions _farmOptions;

        public Chicken(Farm farm, int breed)
        {
            _breed = breed;
            _farmOptions = new FarmOptions();
            _id = System.Guid.NewGuid().ToString();
            _hunger = 100;
            _farm = farm;
        }

        public int Type => _breed;

        public void update()
        {
            Hunger--;
            Lay();
        }

        public void ChickenFeed()
        {
            _farm.FoodStock -= Type * _farmOptions.DefaultFoodConsumption;
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
            _farm = null;
        }

        private void Lay() => _farm.addEgg();
        public int Hunger
        {
            get => _hunger;
            set => _hunger = value;
        }
    }
}
