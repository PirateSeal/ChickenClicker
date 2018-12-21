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
        }

        public CollideCollection CollideCollection { get; }
        public Player Player { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }
        private int Chickencount => Buildings.ChickenCount();

        public void AddEgg()
        {
            Buildings.FindStorage<EggStorage>().
                Capacity ++;
        }

        public void Update() { Buildings.Update(); }

        public int[] UIinfo()
        {
            return new[]
            {
                Money, Buildings.FindStorage<EggStorage>().
                    Capacity,
                Chickencount, Buildings.DyingChickenCount()
            };
        }
    }
}