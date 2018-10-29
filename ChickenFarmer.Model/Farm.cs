using System;

namespace ChickenFarmer.Model
{
    public class Farm
    {

        int _money;
        int _TotalEgg;
        int _chickencount;
        int _foodStock;
        int _chickentToFeed;
        readonly FarmOptions _options;
        HenhouseCollections _Houses;
        Market market;

        public Farm()
        {
            _options = new FarmOptions();
            _money = _options.DefaultMoney;
            _TotalEgg = 0;
            _foodStock = _options.DefaultFoodStock;
            _chickencount = 0;
            _chickentToFeed = 0;
            _Houses = new HenhouseCollections(this);
            market = new Market(this);
        }

        internal FarmOptions Options => _options;

        public int Money { get => _money; set => _money = value; }
        public int TotalEgg { get => _TotalEgg; set => _TotalEgg = value; }
        public HenhouseCollections Houses => _Houses;
        public Market Market => market;

        public void addEgg() => _TotalEgg++;

        public void update()
        {
            _chickentToFeed = 0;
            _Houses.Update();
            info();
        }

        public void CountChickenToFeed()
        {
            foreach (var item in Houses.Henhouses)
            {
                foreach (var chicken in item.Chikens)
                {
                    if (chicken.Hunger <= 25) _chickentToFeed++;
                }
            }
        }

        public void FeedAllChicken()
        {
            if (FoodStock >= _chickentToFeed)
            {
                foreach (var item in Houses.Henhouses)
                {
                    foreach (var chicken in item.Chikens)
                    {
                        chicken.ChickenFeed();
                    }
                }
            }
        }

        public void info() => Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", _money, _TotalEgg, Chickencount);

        public int Chickencount => _Houses.ChickenCount();
        public int FoodStock
        {
            get => _foodStock;
            set => _foodStock = value;
        }

        public int ChickenToFeed
        {
            get => _chickentToFeed;
            set => _chickentToFeed = value;
        }

        public int[] UIinfo()
        {
            return new int[] { _money, _TotalEgg, Chickencount };
        }
    }
}
