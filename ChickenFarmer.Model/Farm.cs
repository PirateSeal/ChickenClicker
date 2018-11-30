﻿#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Farm
    {
        

        public Farm()
        {
            Options = new FarmOptions();
            Market = new Market( this );
            Buildings = new BuildingCollection( this );


            Buildings.Build<Henhouse>(200, 400);
            Buildings.Build<Storage>(600, 300, Storage.StorageType.Eggs);
            Money = Options.DefaultMoney;
            Player = new Player(this);
        }

        public Player Player { get; } 
        public FarmOptions Options { get; }
        public Market Market { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        private int Chickencount => Buildings.ChickenCount();

        public void AddEgg() { Buildings.FindStorageByType( Storage.StorageType.Eggs ).Capacity++; }

        public void Update()
        {
            Buildings.Update();
            //Info();
        }

        public int[] UIinfo() { return new[] { Money, Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity, Chickencount }; }

        private void Info()
        {
            Console.WriteLine( "money : {0} , " + "egg :{1} ," + " chicken {2} ", Money, Buildings.FindStorageByType(Storage.StorageType.Eggs).Capacity,
                Chickencount );
        }
    }
}