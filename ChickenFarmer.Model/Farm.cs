#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Farm
    {


        public Farm()
        {
            Buildings = new BuildingCollection(this);
            CollideCollection = new CollideCollection(this);
            Money = FarmOptions.DefaultMoney;
            Player = new Player(this);
            
        }

        public Player Player { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        private int Chickencount => Buildings.ChickenCount();
        public CollideCollection CollideCollection { get; set; }


        public void AddEgg() { Buildings.FindStorage<EggStorage>().Capacity++; }

        public void Update()
        {
            Buildings.Update();
            Info();
        }

        public int[] UIinfo() { return new[] { Money, Buildings.FindStorage<EggStorage>().Capacity, Chickencount }; }

        private void Info()
        {
            //Console.WriteLine("money : {0} , " + "egg :{1} ," + " chicken {2} ", Money, Buildings.FindStorage<EggStorage>().Capacity,Chickencount);
        }
    }
}