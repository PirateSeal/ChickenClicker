#region Usings

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
            Money = Options.DefaultMoney;
            TotalEgg = 0;
        }

        public FarmOptions Options { get; }
        public Market Market { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        internal int TotalEgg { get; set; }
        private int Chickencount => Buildings.ChickenCount();

        public void AddEgg() { TotalEgg ++; }

        public void Update()
        {
            Buildings.Update();
            Info();
        }

        public int[] UIinfo() { return new[] { Money, TotalEgg, Chickencount }; }

        private void Info()
        {
            Console.WriteLine( "money : {0} , " + "egg :{1} ," + " chicken {2} ", Money, TotalEgg,
                Chickencount );
        }
    }
}