using ChickenFarmer.Model;
using SFML.System;
using System.Collections.Generic;


namespace ChickenFarmer.UI
{
    internal class HenhouseCollectionUi
    {
        private readonly FarmUI _ctxfarmUi;
        private Vector2f _housePos = new Vector2f(100f, 100f);

        
        public HenhouseCollectionUi(FarmUI farmUi)
        {
            _ctxfarmUi = farmUi;
            Henhouses = new List<HenhouseUi>();
            LoadHouses();
        }

        private void LoadHouses()
        {
            List<Henhouse> housesList = _ctxfarmUi.Farm.Buildings.GetBuildingInList<Henhouse>();
            {
                foreach (Henhouse item in housesList)
                {
                    _housePos = new Vector2f(_housePos.X + 100f, _housePos.Y);
                    Henhouses.Add(new HenhouseUi(_ctxfarmUi, item, _housePos));
                }
            }
        }

        public void DrawHouses()
        {
            foreach (HenhouseUi item in Henhouses)
            {
                item.Drawhouses();
            }
        }

        internal List<HenhouseUi> Henhouses { get; }
    }
}
