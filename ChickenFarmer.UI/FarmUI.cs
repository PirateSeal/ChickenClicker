﻿using System;
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
            string infoToPrint = "";

            int i;
            for (i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    infoToPrint += "Argent : " + info[i].ToString() + "\n";
                }
                else if (i == 1)
                {
                    infoToPrint += "Oeufs : " + info[i].ToString() + "\n";
                }
                else if ( i == 2 )
                {
                    infoToPrint += "Poules : " + info[i].ToString() + "\n";
                }
            }

            
            Text text = new Text(infoToPrint, font);
            _ctx.Window.Draw(text);
        }

    }
}



