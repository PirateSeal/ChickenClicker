#region Usings
using System;
using System.Xml.Linq;

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

        public Farm(XElement xElement)
        {
            Money = int.Parse(( string ) xElement.Attribute("Money"));
            CollideCollection = new CollideCollection(this);
            XElement xBuildings = xElement.Element("Buildings");
            Buildings = new BuildingCollection(this, xBuildings);
            Player = new Player(this, xElement);
        }

        private Market Market { get; }
        public CollideCollection CollideCollection { get; }
        public Player Player { get; }
        public BuildingCollection Buildings { get; }
        public int Money { get; set; }

        public XElement ToXml()
        {
            return new XElement("Farm", new XAttribute("Money", Money), Buildings.ToXml(), Player.ToXml());
        }

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
                Buildings.ChickenCount(), Buildings.DyingChickenCount()
            };
        }
    }
}