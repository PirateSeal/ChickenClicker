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
        }

        public FarmOptions Options { get; }
        public Market Market { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        private int Chickencount => Buildings.ChickenCount();

        public void AddEgg() { Buildings.StorageBuilding.TotalEggs ++; }

        public void Update()
        {
            Buildings.Update();
            Info();
        }

        public int[] UIinfo() { return new[] { Money, Buildings.StorageBuilding.TotalEggs, Chickencount }; }

        private void Info()
        {
            Console.WriteLine( "money : {0} , " + "egg :{1} ," + " chicken {2} ", Money, Buildings.StorageBuilding.TotalEggs,
                Chickencount );
        }
    }
}