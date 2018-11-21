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
        string FontLocation = "../../../../Data/pricedown.ttf";
        
        Farm farm;
        GameLoop _ctxGame;
        Font font;
        Shape _buttonSellEggs;
        HenhouseCollectionUI henhouseCollection;

        Vector2f buttonSize = new Vector2f(80f, 60f);
        Vector2f buttonPos = new Vector2f(10f, 540f);
        Text text = new Text();




        public Farm Farm { get => farm; set => farm = value; }

        public FarmUI(GameLoop ctx)
        {
            farm = new Farm();

            _ctxGame = ctx;
            henhouseCollection = new HenhouseCollectionUI(this);

            font = new Font(FontLocation);
            text = new Text("",font);

            _buttonSellEggs = new RectangleShape(buttonSize)
            {
                Position = buttonPos,
            };

            
            

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

            text.DisplayedString = infoToPrint;
            _ctxGame.Window.Draw(text);

            _ctxGame.Window.Draw(_buttonSellEggs);

        }


        public Shape ButtonSellEggs { get => _buttonSellEggs; }
        public GameLoop CtxGame { get => _ctxGame; set => _ctxGame = value; }
        internal HenhouseCollectionUI HenhouseCollection { get => henhouseCollection; set => henhouseCollection = value; }
    }
}



