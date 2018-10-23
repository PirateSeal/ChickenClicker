using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmer.Model
{
   public class HenhouseCollections
    {
        private  List<Henhouse> _HenHouses;
        private Farm _farm;
        internal Farm Farm { get => _farm;}
        readonly FarmOptions _options;


        public HenhouseCollections(Farm farm)
        {
            _options = new FarmOptions();
            _HenHouses = new List<Henhouse>(_options.DefaultCapacity);
            AddHouse();
            _farm = farm; 
        }

        public void UpgradeHouse(Henhouse house)
        {
            foreach (var item in _HenHouses)
            {
                if (item == house) item.Upgrade();
            }
        }

        public Henhouse AddHouse()
        {
            if (_HenHouses.Count == _options.DefaultCapacity) { throw new InvalidOperationException("Can't add a new henhouse, max limit reached"); }

            Henhouse newHouse = new Henhouse(this, _options.DefaultHenHouseLimit);
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

        public List<Henhouse> Henhouses => _HenHouses;

        public int ChickenCount()
        {
            int count = 0;
            foreach (var item in _HenHouses)
            {
                count += item.ChickenCount;
            }
            return count;
        }

        public void Update()
        {
            foreach (var item in _HenHouses )
            {
                item.Update();
            }
        }



       

    }
}
