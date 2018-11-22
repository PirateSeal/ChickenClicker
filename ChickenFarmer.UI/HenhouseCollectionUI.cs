using System;
using System.Collections.Generic;
using System.Text;
using ChickenFarmer.Model;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


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
            AddHouses();
        }

        private void AddHouses()
        {
            foreach (Building building in _ctxfarmUi.Farm.Buildings.Buildings)
            {
                Henhouse item = ( Henhouse ) building;
                Henhouses.Add(new HenhouseUi(_ctxfarmUi, item, _housePos));
                _housePos = new Vector2f(_housePos.X + 100f, _housePos.Y);
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
