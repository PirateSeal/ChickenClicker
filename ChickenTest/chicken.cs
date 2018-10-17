using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenTest
{
    class Chicken
    {
        private int _breed;
        private  string _id;
        private int _hunger;
        Farm _farm;

        public Chicken(Farm farm,int breed)
        {
            _breed = breed;
            _id = System.Guid.NewGuid().ToString();
            _hunger = 100;
            _farm = farm;
        }

        public int Type { get => _breed;}

        public void update()
        {
            _hunger--;

            lay();
        }

        private void lay()
        {
            _farm.addEgg();
        }

    }
}
