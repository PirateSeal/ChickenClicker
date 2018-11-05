using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ChickenFarmer.UI
{
    public class HouseMenu
    {
        bool drawState;

        Vector2f buttonSize = new Vector2f(80f, 60f);
        Vector2f buttonPos = new Vector2f(800f, 600f);

        Shape sellEggButton;
        GameLoop _ctxGame;



        public HouseMenu(GameLoop ctxGame)
        {
            _ctxGame = ctxGame;
            drawState = false;
             sellEggButton = new RectangleShape(buttonSize)
            {
                FillColor = Color.Red,
                Position = buttonPos
            };


        }


        public void DrawGui()
        {

            if(drawState == true) _ctxGame.Window.Draw(sellEggButton);

        }

        public Shape SellEggButton { get => sellEggButton; }
        public bool DrawState { get => drawState; set => drawState = value; }
    }
}
