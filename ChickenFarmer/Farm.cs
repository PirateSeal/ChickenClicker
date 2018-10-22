using System;

namespace ChickenFarmer.Model
{
    public class Farm
    {
        
        int _money;
        int _TotalEgg;
        int _chickencount;
        HenhouseCollections _Houses;
        Market market;

        public Farm()
        {
            _money = Enum.Farm.DefaultMoney;
            _TotalEgg = 0;
            _chickencount = 0;
            _Houses = new HenhouseCollections(this);
             market = new Market(this);
        
        }

        public int Money { get => _money; set => _money = value; }
        public int TotalEgg { get => _TotalEgg; set => _TotalEgg = value; }
<<<<<<< Updated upstream:ChickenFarmer/Farm.cs
        internal HenhouseCollections Houses { get => _Houses; }
        internal Market Market { get => market;}
=======
        public int Chickencount { get => _chickencount; set => _chickencount = value; }
        public HenhouseCollections Houses => _Houses;
        public Market Market => market;
>>>>>>> Stashed changes:ChickenTest/Farm.cs

        internal void addEgg() => _TotalEgg++;



        internal void update()
        {
            _Houses.Update();
            info();
        }

<<<<<<< Updated upstream:ChickenFarmer/Farm.cs
        public void info()
        {
            Console.WriteLine("money : {0} , " +
                "egg :{1} ," +
                " chicken {2} ", _money, _TotalEgg, Chickencount

                );
        }

        public int Chickencount { get => _Houses.ChickenCount();}



=======
        public void info() => Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", _money, _TotalEgg, _chickencount);
>>>>>>> Stashed changes:ChickenTest/Farm.cs
    }


}
