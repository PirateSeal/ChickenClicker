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
    class HenhouseCollectionUI
    {
        private FarmUI _ctxfarmUI;
        private List<HenhouseUI> _henhousesUI;
        Vector2f HousePos = new Vector2f(100f, 100f);


        public HenhouseCollectionUI(FarmUI farmUI)
        {
            this._ctxfarmUI = farmUI;
            _henhousesUI = new List<HenhouseUI>();
            addHouses();
        }


        public void addHouses()
        {
            foreach (var item in _ctxfarmUI.Farm.Houses.Henhouses)
            {
                _henhousesUI.Add(new HenhouseUI(_ctxfarmUI, item, HousePos));
                HousePos = new Vector2f(HousePos.X + 100f, HousePos.Y);

            }
        }

        public void DrawHouses()
        {
            foreach (var item in _henhousesUI)
            {
                item.Drawhouses();
            }
        }

        
        internal List<HenhouseUI> Henhouses{ get => _henhousesUI; set => _henhousesUI = value; }



    }
}
