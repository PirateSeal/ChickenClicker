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

        private readonly Vector2f _buttonPos = new Vector2f(10f, 540f);

        private readonly Vector2f _buttonSize = new Vector2f(80f, 60f);

        public FarmUI( GameLoop ctx )
        {
            FarmOptionsUI = new FarmOptionsUI(this);
            Farm = new Farm();


            Farm.Buildings.Build<Henhouse>(600, 740);
            Farm.Buildings.Build<EggStorage>(800, 740);


            CtxGame = ctx;
            BuildingCollectionUI = new BuildingCollectionUI( this );
            PlayerUI = new PlayerUI(this, Farm.Player);

            Font font = new Font( FontLocation );
            Text = new Text( "", font );



            //ButtonSellEggs = new RectangleShape( _buttonSize ) { Position = _buttonPos };
         
        }

        public Text Text { get; }
        public PlayerUI PlayerUI { get; }
        public Farm Farm { get; }

        public FarmOptionsUI FarmOptionsUI { get; }


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
            for (i = 0; i < info.Length; i ++)
                if ( i == 0 )
                    infoToPrint += "Argent : " + info[i] + "\n";
                else if ( i == 1 )
                    infoToPrint += "Oeufs : " + info[i] + "\n";
                else if ( i == 2 ) infoToPrint += "Poules : " + info[i] + "\n";
                else if ( i == 3 ) infoToPrint += "Poules mourrantes : " + info[i] + "\n";

            Text.DisplayedString = infoToPrint;
            Text.Position = new Vector2f(CtxGame.View.Center.X - CtxGame.View.Size.X / 2, CtxGame.View.Center.Y - CtxGame.View.Size.Y / 2);

            CtxGame.Window.Draw( Text );

            
        }
    }
}