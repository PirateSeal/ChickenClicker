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
    internal class FarmUI
    {
        private const string FontLocation = "../../../../Data/pricedown.ttf";

        private readonly Vector2f _buttonSize = new Vector2f( 80f, 60f );
        private readonly Vector2f _buttonPos = new Vector2f( 10f, 540f );
        private Text _text;
        public PlayerUI _playerUI;
        public Farm Farm { get; private set; }

        public FarmUI( GameLoop ctx )
        {
            Farm = new Farm();
            CtxGame = ctx;
            _playerUI = new PlayerUI(this, Farm.Player, new Vector2f(Farm.Player.Position.X, Farm.Player.Position.Y));
            HenhouseCollection = new HenhouseCollectionUi( this );

            Font font = new Font( FontLocation );
            _text = new Text( "", font );

            ButtonSellEggs = new RectangleShape( _buttonSize ) { Position = _buttonPos, };
        }

        public void Update() { Farm.Update(); }

        public void DrawInfo()
        {
            int[] info = Farm.UIinfo();
            string infoToPrint = "";

            int i;
            for (i = 0; i < 3; i ++)
            {
                switch (i)
                {
                    case 0:
                        infoToPrint += "Argent : " + info[i].ToString() + "\n";
                        break;
                    case 1:
                        infoToPrint += "Oeufs : " + info[i].ToString() + "\n";
                        break;
                    case 2:
                        infoToPrint += "Poules : " + info[i].ToString() + "\n";
                        break;
                    default:
                        break;
                }
            }

            _text.DisplayedString = infoToPrint;
            CtxGame.Window.Draw( _text );

            CtxGame.Window.Draw( ButtonSellEggs );
        }

        public Shape ButtonSellEggs { get; }
        public GameLoop CtxGame { get; private set; }
        internal HenhouseCollectionUi HenhouseCollection { get; set; }
    }
}



