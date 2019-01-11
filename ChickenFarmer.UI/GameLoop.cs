#region Usings

using System;
using ChickenFarmer.Model;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

#endregion
using System.Runtime.Serialization;

namespace ChickenFarmer.UI
{
    public class GameLoop
    {
        public InputHandler PlayerInput { get; }
        public TimeSpan IntervalUpdate { get; } = new TimeSpan(0, 0, 0, 0, 60);
        public DateTime OldUpdate { get; private set; } = DateTime.Now;
        

        public GameLoop()
        {
            Window = new RenderWindow(new VideoMode(1280, 720), "ChickenFarmer",
                Styles.Default);
            Window.SetFramerateLimit(60);

            FarmUI = new FarmUI(this);
            PlayerInput = new InputHandler(this);


           MapManager = new MapManager(this);


        }

        public View View { get; set; }
        public RenderStates State { get; set; }
        public RenderWindow Window { get; }
        public FarmUI FarmUI { get; }
        internal TileMap TileMap { get; set; }
        public MapManager MapManager { get; set; }


        public static void Init()
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
                new Vector2f(1280/2, 720/2)));

            Shape button = new RectangleShape(buttonsize)
            {
                FillColor = Color.Blue, Position = View.Size
            };

           

            while (Window.IsOpen)
            {
                
                Window.View = View;            
                Window.Clear(new Color(255, 0, 255));

                Window.Draw(MapManager.CurrentMap);

                FarmUI.PlayerUI.UpdateSpritePosition();
                FarmUI.PlayerUI.Draw(Window, State);

                FarmUI.BuildingCollectionUI.Draw(Window, State);

                MapManager.CurrentMap.DrawOver(Window, State);
                FarmUI.DrawInfo();
                Update();

                PlayerInput.Handle();

                Window.Display();    
            }
        }

        void Update()
        {
            DateTime current = DateTime.Now;

            if ( OldUpdate.Add(IntervalUpdate) < current )
            {
                
                FarmUI.Update();
                FarmUI.PlayerUI.AnimationLoop();
                FarmUI.PlayerUI.AnimFrame++;

                OldUpdate = current;

                // debug 

                Console.WriteLine(FarmUI.PlayerUI.Sprite.Position);

            }
        }
    }
}