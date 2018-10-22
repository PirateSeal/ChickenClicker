﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmer.Model
{
    class Farm
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
        public int Chickencount { get => _chickencount; set => _chickencount = value; }
        internal HenhouseCollections Houses { get => _Houses; }
        internal Market Market { get => market;}

        internal void addEgg()
        {
            _TotalEgg++;
        }

        internal void update()
        {
            _Houses.Update();
            info();
        }

        public void info()
        {
            Console.WriteLine("money : {0} , " +
                "egg :{1} ," +
                " chicken {2} ", _money, _TotalEgg, _chickencount

                );
        }

       
    }

   
}
