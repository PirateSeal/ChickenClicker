using System;

namespace ChickenFarmer.Model
{
    public class Farm
    {

        readonly FarmOptions _options;
        readonly Storage _storage;
        readonly Market _market;
        HenhouseCollections _Houses;
        int _money;
        int _TotalEgg;

        public Farm()
        {
            _options = new FarmOptions();
            _storage = new Storage(this, _options);
            _market = new Market(this, _options);
            _Houses = new HenhouseCollections(this, _options);
            _money = _options.DefaultMoney;
            _TotalEgg = 0;
        }

        public void AddEgg() => _TotalEgg++;

        public void Update()
        {
            _Houses.Update();
            Info();
        }

        public void Info() => Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", _money, _TotalEgg, Chickencount);

        public FarmOptions Options => _options;
        public Storage Storage => _storage;
        public int Money { get => _money; set => _money = value; }
        public int TotalEgg { get => _TotalEgg; set => _TotalEgg = value; }
        public HenhouseCollections Houses => _Houses;
        public Market Market => _market;
        public int Chickencount => _Houses.ChickenCount();
    }
}
