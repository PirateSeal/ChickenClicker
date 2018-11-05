using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ChickenFarmer.UI
{
    public class GUI
    {
        Vector2f buttonSize = new Vector2f(80f, 60f);
        Vector2f buttonPos = new Vector2f(80f, 60f);

        Shape sellEggButton;
        GameLoop _ctxGame;



        public GUI(GameLoop ctxGame)
        {
            _ctxGame = ctxGame;
           
             sellEggButton = new RectangleShape(buttonSize)
            {
                FillColor = Color.Blue,
                Position = buttonPos
            };


        }


 




        public void DrawGui()
        {
            _ctxGame.Window.Draw(sellEggButton);
        }

        public Shape SellEggButton { get => sellEggButton; }

    }
}
