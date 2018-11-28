#region Usings

using System;
using ChickenFarmer.Model;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

#endregion

namespace ChickenFarmer.UI
{
    public class GameLoop
    {
        private readonly TimeSpan _intervalUpdate = new TimeSpan( 0, 0, 0, 0, 100 );

        private readonly TileMap _mapTest;
        private DateTime _oldUpdate = DateTime.Now;
        private readonly InputHandler _playerInput;

        public GameLoop()
        {
            Window = new RenderWindow( new VideoMode( 1280, 720 ), "ChickenFarmer",
                Styles.Default );
            Window.SetFramerateLimit( 60 );

            FarmUI = new FarmUI( this );
            FarmUI.Farm.Buildings.Build<Storage>( 50f, 50f );
            FarmUI.Farm.Buildings.Build<Henhouse>( 100f, 100f );
            _playerInput = new InputHandler( this );

            _mapTest = new TileMap( "../../../../Data/map/3Layers.tmx", this );
        }

        public RenderWindow Window { get; }
        public RenderStates State { get; set; }
        public View View { get; set; }
        internal FarmUI FarmUI { get; set; }

        private static void Init()
        {
            SystemNative.Load();
            WindowNative.Load();
            GraphicsNative.Load();
            AudioNative.Load();
        }

        public void Run()
        {
            Init();

            Vector2f size = new Vector2f( 800f, 600f );
            Vector2f buttonsize = new Vector2f( 80f, 60f );

            Shape square = new RectangleShape( size ) { FillColor = Color.Red };
            //Texture texture = new Texture("../../../../Data/farm_background.jpg");
            // Sprite background = new Sprite(texture);

            View = new View( new FloatRect( new Vector2f( 0f, 0f ), new Vector2f( 1280, 720 ) ) );

            Shape button = new RectangleShape( buttonsize )
            {
                FillColor = Color.Blue, Position = size
            };

            while (Window.IsOpen)
            {
                _playerInput.Handle();
                Window.View = View;
                Window.Clear( new Color( 255, 0, 255 ) );
                Window.Draw( square );
                //   _window.Draw(background);
                FarmUI.DrawInfo();
                FarmUI.BuildingCollectionUI.DrawBuildings( Window, State  );
                Window.Draw( _mapTest );
                Window.Display();
                Update();
            }
        }

        private void Update()
        {
            DateTime current = DateTime.Now;

            if ( _oldUpdate.Add( _intervalUpdate ) < current )
            {
                FarmUI.Update();

                _oldUpdate = current;
            }
        }
    }
}