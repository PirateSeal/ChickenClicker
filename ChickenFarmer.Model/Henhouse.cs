using System.Collections.Generic;

namespace ChickenFarmer.Model
{
    public class Henhouse
    {
        HenhouseCollections _ctx;
        FarmOptions _options;
        List<Chicken> _chickens;
        List<Chicken> _dyingChickens;
        int _lvl;
        int _limit;

        public Henhouse(HenhouseCollections henhouseCollections, FarmOptions farmOptions, int limit)
        {
            _options = farmOptions;
            _ctx = henhouseCollections;
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

        public void FeedChicken()
        {
            if (Collection.Farm.Storage.SeedCapacity >= CountDyingChickens)
            {
                foreach (var chicken in Chikens)
                {
                    chicken.ChickenFeed();
                }
            }
        }

        public void AddChicken(int breed)
        {
            Chicken newchiken = new Chicken(this, _options, breed);
            _chickens.Add(newchiken);
        }

        public void Update()
        {
            foreach (Chicken item in _chickens)
            {
                item.Update();
                if (item.CheckIfStarving&& !FindDyingChicken(item))
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

        internal HenhouseCollections Collection => _ctx;
        internal List<Chicken> Chikens => _chickens;
        public int ChickenCount => _chickens.Count;
        public int Limit => _limit;
        public int Lvl => _lvl;
        public int CountDyingChickens => _dyingChickens.Count;
    }
}
