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
        Shape _buttonSellEggs;
        HenhouseCollectionUI henhouseCollection;
        

        string FontLocation = "../../../../Data/pricedown.ttf";

        public Farm Farm { get => farm; set => farm = value; }

        public FarmUI(GameLoop ctx)
        {
            farm = new Farm();
            henhouseCollection = new HenhouseCollectionUI(this);

            _ctx = ctx;
            font = new Font(FontLocation);
            DrawButtonSellEggs();

        }


        public void update()
        {
            farm.Update();
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




        public void DrawButtonSellEggs()
        {
            Vector2f buttonSize = new Vector2f(80f, 60f);
            Vector2f buttonPos = new Vector2f(10f, 540f);
            _buttonSellEggs = new RectangleShape(buttonSize)
            {
                FillColor = Color.Green,
                Position = buttonPos
            };

            _ctx.Window.Draw(_buttonSellEggs);
        
        }

        public Shape ButtonSellEggs { get => _buttonSellEggs; }
        public GameLoop CtxGame { get => _ctx; set => _ctx = value; }
        internal HenhouseCollectionUI HenhouseCollection { get => henhouseCollection; set => henhouseCollection = value; }
    }
}



