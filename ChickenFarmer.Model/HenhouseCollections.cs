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
        private Farm _ctxFarm;
        internal FarmOptions _options;

        public HenhouseCollections(Farm ctxFarm, FarmOptions options)
        {
            _ctxFarm = ctxFarm ?? throw new ArgumentNullException(nameof(ctxFarm));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _HenHouses = new List<Henhouse>();
        }

        

        public void AddChicken(Henhouse house,int breed)
        {
            foreach (var item in _HenHouses)
            {
                if (item == house) house.AddChicken(breed);
            }
        }


        public int ChickenCount()
        {
            int count = 0;
            foreach (var item in Henhouses)
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
        public int Count() => _HenHouses.Count();

        public List<Henhouse> Henhouses => _HenHouses;

        public Farm CtxFarm { get => _ctxFarm; set => _ctxFarm = value; }

    }
}
