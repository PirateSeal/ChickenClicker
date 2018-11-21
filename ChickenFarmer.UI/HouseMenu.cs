using System;
using System.Collections.Generic;
using ChickenFarmer.Model;
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
        Vector2f _menuSize = new Vector2f(200f, 200f);
        //convert vector for relative position of sprite 
        Vector2f _menuPos;
        Vector2f _buttonBuyChickenPos;
        Vector2f _buttonHenHouseUpgradePos;
        Vector2f _textBuychickenPos;
        Vector2f _textUpgardeHousePos;

        Shape _menu;
        Shape _buttonBuyChicken;
        Shape _buttonHenHouseUpgrade;

        GameLoop _ctxGame;
        HenhouseUI _ctxHouseUI;
        Henhouse _ctxHouse;


        Texture _buttonTexture = new Texture("../../../../Data/UI/button/button.png");
        Texture _clickedbuttonTexture = new Texture("../../../../Data/UI/button/button.png");

        Font font = new Font("../../../../Data/pricedown.ttf");
        Text _text = new Text();
        Text _textBuychicken;
        Text _textUpgardeHouse;



        internal HouseMenu(GameLoop ctxGame,Henhouse ctxHouse,HenhouseUI ctxHouseUI )
        {
            _ctxHouse = ctxHouse;
            _ctxGame = ctxGame;
            drawState = false;
            _ctxHouseUI = ctxHouseUI;

            _menuPos = new Vector2f(_ctxHouseUI.HousePos1.X, _ctxHouseUI.HousePos1.Y + 100f);
            _buttonBuyChickenPos = new Vector2f(_menuPos.X+50f,_menuPos.Y+80);
            _buttonHenHouseUpgradePos = new Vector2f(_buttonBuyChickenPos.X , _buttonBuyChickenPos.Y+60f);
            _textBuychickenPos = new Vector2f(_textUpgardeHousePos.X, _buttonHenHouseUpgradePos.Y + 20);
            _textUpgardeHousePos = new Vector2f(_buttonHenHouseUpgradePos.X+15,_buttonHenHouseUpgradePos.Y+20);



            _menu = new RectangleShape(_menuSize)
            {

                FillColor = Color.Blue,
                Position = _menuPos, 
                OutlineThickness = 2f,
                OutlineColor = Color.Black
                
            };
            
            

            _buttonBuyChicken = new RectangleShape(buttonSize)
            {
            Texture = _buttonTexture,
            Position = _buttonBuyChickenPos
              
            };

            _textBuychicken = new Text("buy chicken", font,13)
            {
                Position =_buttonBuyChickenPos
            };





            _buttonHenHouseUpgrade = new RectangleShape(buttonSize)
            {
                Texture = _buttonTexture,
                FillColor = Color.Green,
                Position = _buttonHenHouseUpgradePos
            };



            _textUpgardeHouse = new Text("Upgrade", font,13)
            {
                Position = _textUpgardeHousePos
            };

            _text.Font = font;
            _text.Position = _menuPos;
            _text.CharacterSize = 20;


        }






        public void DrawGui()
        {
            if (drawState)
            {
                
                _ctxGame.Window.Draw(_menu);
                _ctxGame.Window.Draw(_buttonBuyChicken);
                _ctxGame.Window.Draw(_buttonHenHouseUpgrade);
                _ctxGame.Window.Draw(_textBuychicken);
                _ctxGame.Window.Draw(_textUpgardeHouse);



                string infoLvl = "Lvl :" + _ctxHouse.Lvl.ToString();
                string infoLimit = "limit :" + _ctxHouse.Limit.ToString();
                string infoChicken = "chicken Count :" + _ctxHouse.ChickenCount.ToString();


                _text.DisplayedString = infoLvl + " " + infoLimit + " " + infoChicken;
                

                _ctxGame.Window.Draw(_text);
            }
        }



        public Shape Menu { get => _menu; }
        public Shape ButtonBuyChicken { get => _buttonBuyChicken; }
        public Shape ButtonHenHouseUpgrade { get => _buttonHenHouseUpgrade; }

        public bool DrawState { get => drawState; set => drawState = value; }
    }
}
