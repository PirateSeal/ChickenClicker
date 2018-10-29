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
    class FarmUI
    {
        Farm farm;
        GameLoop _ctx;
        Font font;
        string fontlocation = "../../../../Data/pricedown.ttf";


        public FarmUI(GameLoop ctx)
        {
            farm = new Farm();
            _ctx = ctx;
            font = new Font(fontlocation);

        }


        public void update()
        {
            farm.update();
        }

        public void DrawInfo()
        {
            int[] info = farm.UIinfo();
            foreach (var item in info)
            {
                Text text = new Text(item.ToString(), font, 30);
                text.FillColor = Color.White;
                _ctx.Window.Draw(text);
            }
        }

    }
}



