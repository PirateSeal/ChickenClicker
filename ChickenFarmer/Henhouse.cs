using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmer.Model
{
    public class Henhouse
    {
        int _lvl; 
        List<Chicken> _chickens;
        string _id;
        HenhouseCollections _collection;
        int _limit;

        public Henhouse(HenhouseCollections collections, int limit)
        {
            _collection = collections;
            _id = System.Guid.NewGuid().ToString();
            _lvl = 1;
            _chickens = new List<Chicken>(limit * _lvl);
            

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
            Chicken newchiken = new Chicken(_collection.Farm,breed);
            _chickens.Add(newchiken);
        }

        public void Update()
        {
            foreach (var item in _chickens)
            {
                item.update();
            }
        }

        /*
       public void Dispose()
       {
           //Antoine//
           pourquoi draw dans ui quand tu peut le faire dans cette classe sans parler de séparer les choses
           idem pour dispose & les assets
       }

       public void Draw(Function Draw)
       {
          Draw(Chickens);
       }
       */


        public int ChickenCount => _chickens.Count;

        public string Id { get => _id; }
        internal HenhouseCollections Collection  => _collection; 
        public int Limit => _limit;
        internal List<Chicken> Chikens => _chickens;
        public int Lvl => _lvl;
    }
}
