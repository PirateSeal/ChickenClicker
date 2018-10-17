using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenTest
{
    class Henhouse
    {
        List<Chicken> _chikens;
        string _id;
        HenhouseCollections _collection;
        int _limit;

        public Henhouse(HenhouseCollections collections, int limit)
        {
            _collection = collections;
            _chikens = new List<Chicken>(limit - 1);
            _id = System.Guid.NewGuid().ToString();
        }


        public void AddChicken(int breed)
        {
            Chicken newchiken = new Chicken(_collection.Farm,breed);
            _chikens.Add(newchiken);
        }

        public void UpgradeHouse(int newCapacity)
        {
            // Tableau temporaire
            // New tableau avec new taille
            // permutation tableau
        }

        public void Update()
        {
            foreach (var item in _chikens)
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

        public string Id { get => _id; }
        internal HenhouseCollections Collection { get => _collection;  }
        public int Limit { get => _limit; set => _limit = value; }
        internal List<Chicken> Chikens { get => _chikens; set => _chikens = value; }
    }
}
