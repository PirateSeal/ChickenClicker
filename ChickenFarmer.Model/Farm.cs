#region Usings

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
            Market = new Market(this);
        }

        private Market Market { get; }
        public CollideCollection CollideCollection { get; }
        public Player Player { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        private int Chickencount => Buildings.ChickenCount();

        public void AddEgg()
        {
            Buildings.FindStorage<StorageEgg>().
                Capacity ++;
        }

        public void Update() { Buildings.Update(); }

        public int[] UIinfo()
        {
            return new[]
            {
                Money, Buildings.FindStorage<StorageEgg>().
                    Capacity,
                Chickencount, Buildings.DyingChickenCount()
            };
        }
    }
}