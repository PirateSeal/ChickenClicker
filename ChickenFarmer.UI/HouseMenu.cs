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
        Vector2f _buttonBuyChickenPos = new Vector2f(700f, 60f);
        Vector2f _buttonHenHouseUpgradePos = new Vector2f(700f, 125f);

        Shape _buttonBuyChicken;
        Shape _buttonHenHouseUpgrade;
        GameLoop _ctxGame;



        public HouseMenu(GameLoop ctxGame)
        {
            _ctxGame = ctxGame;
            drawState = false;
             _buttonBuyChicken = new RectangleShape(buttonSize)
            {
                FillColor = Color.Red,
                Position = _buttonBuyChickenPos
            };

            _buttonHenHouseUpgrade = new RectangleShape(buttonSize)
            {
                FillColor = Color.Yellow,
                Position = _buttonHenHouseUpgradePos
            };
        }


        public void DrawGui()
        {

            if (drawState == true) _ctxGame.Window.Draw(_buttonBuyChicken);
            if (drawState == true) _ctxGame.Window.Draw(_buttonHenHouseUpgrade);

        }

        public Shape ButtonBuyChicken { get => _buttonBuyChicken; }
        public Shape ButtonHenHouseUpgrade { get => _buttonHenHouseUpgrade; }
        public bool DrawState { get => drawState; set => drawState = value; }
    }
}
