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
        private InputHandler _playerInput;
        private TimeSpan _intervalUpdate = new TimeSpan( 0, 0, 0, 0, 60 );
        private readonly TileMap _tileMap;
        private DateTime _oldUpdate = DateTime.Now;
        View _view;

        public GameLoop()
        {
            Window = new RenderWindow(new VideoMode(1280, 720), "ChickenFarmer",
                Styles.Default);
            Window.SetFramerateLimit(60);

            FarmUI = new FarmUI(this);
            _playerInput = new InputHandler(this);

            _tileMap = new TileMap("../../../../Data/map/3Layers.tmx", this);
        }

        public View View { get; set; }
        public RenderStates State { get; set; }
        public RenderWindow Window { get; }
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
            

            Vector2f buttonsize = new Vector2f(80f, 60f);

            View = new View(new FloatRect(new Vector2f(0f, 0f),
                new Vector2f(1280, 720)));

            Shape button = new RectangleShape(buttonsize)
            {
                FillColor = Color.Blue, Position = View.Size
            };

           

            while (Window.IsOpen)
            {
                _playerInput.Handle();
                Window.View = View;
                Window.Draw(_tileMap);
                Window.Clear(new Color(255, 0, 255));
                //   _window.Draw(background);
                FarmUI.BuildingCollectionUI.Draw(Window, State);
                FarmUI.DrawInfo();
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

            if ( _oldUpdate.Add(_intervalUpdate) < current )
            {
                
                FarmUI.Update();
                FarmUI._playerUI.AnimationLoop();
                FarmUI._playerUI.AnimFrame++;

                _oldUpdate = current;
            }
        }
    }
}