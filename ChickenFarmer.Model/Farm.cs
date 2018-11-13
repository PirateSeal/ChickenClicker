using System;

namespace ChickenFarmer.Model
{
    public class Farm
    {
        readonly FarmOptions _options;
        readonly Market _market;
        BuildingCollection _buildings;
        int _money;
        int _totalEgg;

        public Farm()
        {
            _options = new FarmOptions();
            _market = new Market(this, _options);
            _buildings = new BuildingCollection(this, Options);
            _money = _options.DefaultMoney;
            _totalEgg = 0;
        }

        public void AddEgg() => _totalEgg++;

        public void Update()
        {
            _buildings.Update();
            Info();
        }

        public int[] UIinfo() => new int[] {Money, TotalEgg, Chickencount};

        public void Info() => Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", _money, _totalEgg,
            Chickencount);

        public FarmOptions Options => _options;

        public int Money
        {
            get => _money;
            set => _money = value;
        }

        public int TotalEgg
        {
            get => _totalEgg;
            set => _totalEgg = value;
        }

        public BuildingCollection Buildings => _buildings;
        public Market Market => _market;
        public int Chickencount => _buildings.ChickenCount();
    }
}
