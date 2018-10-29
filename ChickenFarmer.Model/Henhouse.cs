using System;
using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    public class Henhouse
    {
        int _lvl;
        List<Chicken> _chickens;
        string _id;
        HenhouseCollections _ctxCollection;
        readonly FarmOptions _options;
        int _limit;
        List<Chicken> _dyingChickens;

        public Henhouse(HenhouseCollections collections, int limit)
        {
            _options = new FarmOptions();
            _ctxCollection = collections;
            _id = System.Guid.NewGuid().ToString();
            _lvl = 0;
            _limit = _options.DefaultHenHouseLimit;
            _chickens = new List<Chicken>(_limit * _lvl);
            _dyingChickens = new List<Chicken>();
        }

        public void Upgrade()
        {
            _lvl++;
            int newLimit;
            newLimit = _limit * _lvl;

            _chickens.Capacity = newLimit;
        }

        public void AddChicken(int breed)
        {
            Chicken newchiken = new Chicken(this, breed);
            _chickens.Add(newchiken);
        }

        public void Update()
        {
            foreach (Chicken item in _chickens)
            {
                item.update();
                if (item.CheckIfStarving() && !FindDyingChicken(item))
                {
                    _dyingChickens.Add(item);
                }
            }
            if (!CheckIfAllDyingAreFed())
            {
                KillStarvingChicken();
            }
        }

        internal bool CheckIfAllDyingAreFed()
        {
            foreach (Chicken chicken in _dyingChickens)
            {
                if (chicken.Hunger <= 25) return false;
            }
            return true;
        }

        internal void KillStarvingChicken()
        {
            foreach (var chicken in _dyingChickens)
            {
                if (chicken.Hunger <= 0)
                {
                    chicken.Die();
                    _chickens.Remove(chicken);
                }
            }
            _dyingChickens.Clear();
        }

        internal bool FindDyingChicken(Chicken chickenParam)
        {
            foreach (Chicken chicken in _dyingChickens)
            {
                if (chickenParam == chicken) return true; 
            }
            return false;
        }

        public int ChickenCount => _chickens.Count;
        public string Id => _id;
        internal HenhouseCollections CtxCollection => _ctxCollection;
        public int Limit => _limit;
        internal List<Chicken> Chikens => _chickens;
        public int Lvl => _lvl;
        public int CountDyingChickens => _dyingChickens.Count;
    }
}
