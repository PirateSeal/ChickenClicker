using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using ChickenFarmer.Model;

namespace ChickenFarmer.UI
{
    internal class HenhouseUi
    {
        private GameLoop _ctxGame;
        private Vector2f _houseSize = new Vector2f( 64f, 96f );
        private Texture[] _textures;

        public HenhouseUi( FarmUI ctxFarm, Henhouse house, Vector2f pos )
        {
            HousePos1 = pos;
            _ctxGame = ctxFarm.CtxGame;
            Ctxhouse = house;
            HouseMenu = new HouseMenu( _ctxGame, this );

            HouseSprite = new RectangleShape( _houseSize ) { Position = HousePos1, };
            _textures = _textures = new Texture[]
            {
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse2.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" )
            };
        }

        public void Drawhouses()
        {
        
            HouseSprite.Texture = _textures[Ctxhouse.Lvl];

            _ctxGame.Window.Draw( HouseSprite );
            HouseMenu.DrawGui();
        }

        public Shape HouseSprite { get; private set; }
        public HouseMenu HouseMenu { get; private set; }
        public Henhouse Ctxhouse { get; private set; }
        public Vector2f HousePos1 { get; private set; } = new Vector2f( 100f, 100f );
    }
}
