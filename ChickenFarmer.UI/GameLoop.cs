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
        private TimeSpan _intervalUpdate = new TimeSpan( 0, 0, 0, 0, 60 );
        private DateTime _oldUpdate = DateTime.Now;
        View _view;
        RenderStates states;

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

            View = new View( new FloatRect( new Vector2f( 0f, 0f ), new Vector2f( 1280/2, 720/2 ) ) );

            states = new RenderStates();

            Shape button = new RectangleShape( buttonsize )
            {
                FillColor = Color.Blue, Position = size
            };



            while (Window.IsOpen)
            {
                Window.View = View;
                Window.Clear(new Color( 255, 0, 255 ));
                Window.Draw( square );
                
                //   _window.Draw(background);
                //FarmUI.DrawInfo();
                
                Window.Draw(_mapTest);
                FarmUI.HenhouseCollection.DrawHouses();
                FarmUI._playerUI.UpdateSpritePosition();
                FarmUI._playerUI.Draw(Window, states);
                
                Window.Display();
                _playerInput.Handle();
                Update();
            }
        }

        private void Update()
        {
            DateTime current = DateTime.Now;

            if ( _oldUpdate.Add( _intervalUpdate ) < current )
            {
                
                FarmUI.Update();
                FarmUI._playerUI.AnimationLoop();
                FarmUI._playerUI.AnimFrame++;

                _oldUpdate = current;
            }
        }
    }
}
