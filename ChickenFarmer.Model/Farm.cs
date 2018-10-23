using System;

namespace ChickenFarmer.Model
{
    public class Farm
    {
        
        int _money;
        int _TotalEgg;
        int _chickencount;
        readonly FarmOptions _options;
        HenhouseCollections _Houses;
        Market market;

        public Farm()
        {
            _options = new FarmOptions();
            _money = _options.DefaultMoney;
            _TotalEgg = 0;
            _chickencount = 0;
            _Houses = new HenhouseCollections(this);
             market = new Market(this);
        }

        internal FarmOptions Options
        {
            get { return _options; }
        }




        public int Money { get => _money; set => _money = value; }
        public int TotalEgg { get => _TotalEgg; set => _TotalEgg = value; }
        public HenhouseCollections Houses => _Houses;
        public Market Market => market;

        public void addEgg() => _TotalEgg++;

        public void update()
        {
            _Houses.Update();
            info();
        }

        public void info() => Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", _money, _TotalEgg, Chickencount);

        public int Chickencount => _Houses.ChickenCount();



    }


}
