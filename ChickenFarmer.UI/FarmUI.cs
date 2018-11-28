#region Usings

using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;

#endregion

namespace ChickenFarmer.UI
{
    public class FarmUI
    {
        private const string FontLocation = "../../../../Data/pricedown.ttf";
        private readonly Vector2f _buttonPos = new Vector2f( 10f, 540f );

        private readonly Vector2f _buttonSize = new Vector2f( 80f, 60f );

        public FarmUI( GameLoop ctx )
        {
            Farm = new Farm();

            CtxGame = ctx;
            BuildingCollectionUI = new BuildingCollectionUI( this );

            Font font = new Font( FontLocation );
            Text = new Text( "", font );

            ButtonSellEggs = new RectangleShape( _buttonSize ) { Position = _buttonPos };
            FarmOptionsUI = new FarmOptionsUI();
        }

        public Text Text { get; }

        public Farm Farm { get; }

        public FarmOptionsUI FarmOptionsUI { get; }

        public Shape ButtonSellEggs { get; }
        public GameLoop CtxGame { get; }
        internal BuildingCollectionUI BuildingCollectionUI { get; set; }
        public void Update() { Farm.Update(); }

        public void DrawInfo()
        {
            int[] info = Farm.UIinfo();
            string infoToPrint = "";

            int i;
            for (i = 0; i < 3; i ++)
                switch (i)
                {
                    case 0:
                        infoToPrint += "Argent : " + info[i] + "\n";
                        break;
                    case 1:
                        infoToPrint += "Oeufs : " + info[i] + "\n";
                        break;
                    case 2:
                        infoToPrint += "Poules : " + info[i] + "\n";
                        break;
                }

            Text.DisplayedString = infoToPrint;
            CtxGame.Window.Draw( Text );

            CtxGame.Window.Draw( ButtonSellEggs );
        }
    }
}