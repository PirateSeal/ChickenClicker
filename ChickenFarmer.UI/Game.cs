using System;
using System.Drawing;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    class Game : GameLoop
    {
        DateTime old = DateTime.Now;
        TimeSpan interval = new TimeSpan(0, 0, 0, 0, 100);

        readonly string _rootPath;

        public const uint DEFAULT_WINDOW_WIDTH = 1280;
        public const uint DEFAULT_WINDOW_HEIGHT = 720;

        public const string WINDOW_TITLE = "MiamiOps";

        public Game(string rootPath) : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, SFML.Graphics.Color.Black)
        {
        }

        public override void Draw()
        {
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {

        }

        public override void Update()
        {
            DateTime current = DateTime.Now;
            if (old.Add(interval) < current)
            {
                Console.WriteLine("Hello World!");
                // update();
                old = current;
            }
        }
    }
}