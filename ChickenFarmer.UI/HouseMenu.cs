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
        private readonly Vector2f _buttonSize = new Vector2f( 80f, 60f );

        private readonly Vector2f _menuSize = new Vector2f( 200f, 200f );

        //convert vector for relative position of sprite 
        private Vector2f TextBuychickenPos { get; }
        private Vector2f _textUpgradeHousePos;
        private GameLoop _ctxGame;
        private HenhouseUi _ctxHouseUI;

        private Texture ButtonTexture { get; } =
            new Texture( "../../../../Data/UI/button/button.png" );

        public Texture ClickedbuttonTexture { get; } =
            new Texture( "../../../../Data/UI/button/button.png" );

        private readonly Font _font = new Font( "../../../../Data/pricedown.ttf" );
        private readonly Text _text = new Text();
        private Text _textBuychicken;
        private Text _textUpgradeHouse;

        internal HouseMenu( GameLoop ctxGame, HenhouseUi ctxHouseUI )
        {
            _ctxGame = ctxGame;
            DrawState = false;
            _ctxHouseUI = ctxHouseUI;

            Vector2f menuPos =
                new Vector2f( _ctxHouseUI.HousePos1.X, _ctxHouseUI.HousePos1.Y + 100f );
            Vector2f buttonBuyChickenPos = new Vector2f( menuPos.X + 50f, menuPos.Y + 80 );
            Vector2f buttonHenHouseUpgradePos =
                new Vector2f( buttonBuyChickenPos.X, buttonBuyChickenPos.Y + 60f );
            TextBuychickenPos =
                new Vector2f( _textUpgradeHousePos.X, buttonHenHouseUpgradePos.Y + 20 );
            _textUpgradeHousePos = new Vector2f( buttonHenHouseUpgradePos.X + 15,
                buttonHenHouseUpgradePos.Y + 20 );

            Menu = new RectangleShape( _menuSize )
            {
                FillColor = Color.Blue,
                Position = menuPos,
                OutlineThickness = 2f,
                OutlineColor = Color.Black
            };

            ButtonBuyChicken = new RectangleShape( _buttonSize )
            {
                Texture = ButtonTexture, Position = buttonBuyChickenPos
            };

            _textBuychicken = new Text( "buy chicken", _font, 13 )
            {
                Position = buttonBuyChickenPos
            };

            ButtonHenHouseUpgrade = new RectangleShape( _buttonSize )
            {
                Texture = ButtonTexture,
                FillColor = Color.Green,
                Position = buttonHenHouseUpgradePos
            };

            _textUpgradeHouse = new Text( "Upgrade", _font, 13 )
            {
                Position = _textUpgradeHousePos
            };

            _text.Font = _font;
            _text.Position = menuPos;
            _text.CharacterSize = 20;
        }

        public void DrawGui()
        {
            if ( DrawState )
            {
                _ctxGame.Window.Draw( Menu );
                _ctxGame.Window.Draw( ButtonBuyChicken );
                _ctxGame.Window.Draw( ButtonHenHouseUpgrade );
                _ctxGame.Window.Draw( _textBuychicken );
                _ctxGame.Window.Draw( _textUpgradeHouse );

                string infoLvl = "Lvl :" + _ctxHouseUI.Ctxhouse.Lvl;
                string infoLimit = "limit :" + _ctxHouseUI.Ctxhouse.MaxCapacity;
                string infoChicken = "chicken Count :" + _ctxHouseUI.Ctxhouse.ChickenCount;

                _text.DisplayedString = infoLvl + " " + infoLimit + " " + infoChicken;

                _ctxGame.Window.Draw( _text );
            }
        }

        public Shape Menu { get; }
        public Shape ButtonBuyChicken { get; }
        public Shape ButtonHenHouseUpgrade { get; }

        public bool DrawState { get; set; }
    }
}
