using System;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    public abstract class GameLoop
    {
        public RenderWindow Window
        {
            get;
            protected set;
        }

        public SFML.Graphics.Color WindowClearColor
        {
            get;
            protected set;
        }

        protected GameLoop(uint windowWidth, uint windowHeight, string windowTitle, SFML.Graphics.Color windowClearColor)
        {

            SFML.SystemNative.Load();
            SFML.WindowNative.Load();
            SFML.GraphicsNative.Load();
            //SFML.AudioNative.Load();

            while (true)
            {

                WindowClearColor = windowClearColor;
                Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
                Window.KeyPressed += WindowEscaping;
            }
        }

        public void Run() // Main method of the gameloop
        {
            LoadContent();
            Initialize();
        }

        public abstract void LoadContent();
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();

        private void WindowEscaping(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape) Window.Close();
        }


        public Window GameWindow => Window;
    }
}
