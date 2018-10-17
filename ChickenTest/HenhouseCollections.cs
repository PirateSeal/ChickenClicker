using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenTest
{
   internal class HenhouseCollections
    {
        public  List<Henhouse> _HenHouses;
        private Farm _farm;
        int Limit = 10;
        internal Farm Farm { get => _farm;}

        public HenhouseCollections(Farm farm)
        {
            _HenHouses = new List<Henhouse>(10);
            _farm = farm; 
        }

        public Henhouse AddHouse()
        {
            Henhouse newHouse = new Henhouse(this, Enum.HenHeouse.DefaultHenhouseLimit);
            _HenHouses.Add(newHouse);
            return newHouse;
        }

        public void AddChicken(Henhouse house,int breed)
        {
            foreach (var item in _HenHouses)
            {
                if (item == house) house.AddChicken(breed);
            }

        }

        public int Count() => _HenHouses.Count();

        public void Update()
        {
            foreach (var item in _HenHouses )
            {
                item.Update();
            }
        }



       

    }
}
