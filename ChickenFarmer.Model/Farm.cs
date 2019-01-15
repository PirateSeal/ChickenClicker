#region Usings
using System;
using System.Xml.Linq;

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
            Buildings.Build<Builder>(200, 200);    
        }

        public Farm(XContainer xElement) : this()
        {
            Money = int.Parse(xElement.Element("Money")?.Value ?? throw new InvalidOperationException("No money saved found"));
            XElement xBuildings = xElement.Element("Buildings");
            BuildingCollection buildingCollection = new BuildingCollection(this, xBuildings);
        }

        public XElement ToXml()
        {
            return new XElement("Farm",
                new XAttribute("Money", Money),
                new XElement("Farm.Buildings", Buildings.ToXml()),
                new XElement("Farm.Player", Player.ToXml()));
        }

        private Market Market { get; }
        public CollideCollection CollideCollection { get; }
        public Player Player { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }

        public void AddEgg()
        {
            Buildings.FindStorage<StorageEgg>().
                Capacity++;
        }

        public void Update() { Buildings.Update(); }

        public int[] UIinfo()
        {
            return new[]
            {
                Money, Buildings.FindStorage<StorageEgg>().
                    Capacity,
                Buildings.ChickenCount(), Buildings.DyingChickenCount()
            };
        }
    }
}