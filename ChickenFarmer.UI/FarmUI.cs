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

        PlayerUI _playerUI;

        public FarmUI( GameLoop ctx )
        {
            FarmOptionsUI = new FarmOptionsUI();
            Farm = new Farm();
          
            CtxGame = ctx;
            BuildingCollectionUI = new BuildingCollectionUI( this );
            _playerUI = new PlayerUI(this, Farm.Player);

            Font font = new Font( FontLocation );
            Text = new Text( "", font );

            ButtonSellEggs = new RectangleShape( _buttonSize ) { Position = _buttonPos };
         
        }

        public Text Text { get; }
        public PlayerUI PlayerUI { get { return _playerUI; } }
        public Farm Farm { get; }

        public FarmOptionsUI FarmOptionsUI { get; }

        public Shape ButtonSellEggs { get; }
        public GameLoop CtxGame { get; }
        internal BuildingCollectionUI BuildingCollectionUI { get; set; }
        public void Update()
        {
            Farm.Update();
        }

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
            Text.Position = new Vector2f(CtxGame.View.Center.X - CtxGame.View.Size.X / 2, CtxGame.View.Center.Y - CtxGame.View.Size.Y / 2);

            CtxGame.Window.Draw( Text );

            CtxGame.Window.Draw( ButtonSellEggs );
        }
    }
}