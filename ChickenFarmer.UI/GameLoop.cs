using System;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    public class GameLoop
    {
        private InputHandler _playerInput;
        private TimeSpan _intervalUpdate = new TimeSpan( 0, 0, 0, 0, 100 );
        private DateTime _oldUpdate = DateTime.Now;
        View _view;

        private MapTest _mapTest;

        public GameLoop()
        {
            Window = new RenderWindow( new VideoMode( 1280, 720 ), "ChickenFarmer",
                Styles.Default );
            Window.SetFramerateLimit( 60 );

            FarmUI = new FarmUI( this );
            
            
            _playerInput = new InputHandler( this );

            _mapTest = new MapTest( "../../../../Data/map/3Layers.tmx", this );
        }

        public RenderWindow Window { get; private set; }

        public RenderStates State { get; set; }
        public View View { get => _view; set => _view = value; }
        internal FarmUI FarmUI { get; set; }

        private static void Init()
        {
            SFML.SystemNative.Load();
            SFML.WindowNative.Load();
            SFML.GraphicsNative.Load();
            SFML.AudioNative.Load();
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
                Window.View = View;
                Window.Clear( new Color( 255, 0, 255 ) );
                Window.Draw( square );
                
                //   _window.Draw(background);
                FarmUI.DrawInfo();
                FarmUI.HenhouseCollection.DrawHouses();
                Window.Draw(_mapTest);
                FarmUI._playerUI.DrawPlayer();
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
                _playerInput.Handle();

                _oldUpdate = current;
            }
        }
    }
}
