using System;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;


namespace ChickenFarmer.UI
{

    public class GameLoop
    {
        RenderWindow _window;
        Event _input;
        TimeSpan _interval = new TimeSpan(0, 0, 0, 0, 100);
        DateTime _old = DateTime.Now;


        public GameLoop()
        {

            _window = new RenderWindow(new VideoMode(800, 600), "ChickenFarmer", Styles.Titlebar);
            _window.SetFramerateLimit(60);

        }

        public static void Init()
        {
            SFML.SystemNative.Load();
            SFML.WindowNative.Load();
            SFML.GraphicsNative.Load();
            SFML.AudioNative.Load();
            
        }

        public void Run()
        {
            Init();
            Vector2f size = new Vector2f(800f, 600f);
            Shape _square = new RectangleShape(size);
            _square.
            _square.FillColor = Color.Red;
            Texture texture = new Texture("C:/Users/Wazaa/Desktop/Chicken Farmer/farm_background.jpg");
            
            Sprite sprite = new Sprite(texture);
            
            
            


            while (_window.IsOpen)
            {
                
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    _window.Close();
                }
                _window.Clear();
                _window.Draw(_square);
                _window.Draw(sprite);
                _window.Display();
                Update();

            }
        }


        public void Update()
        {
            DateTime current = DateTime.Now;
            if (_old.Add(_interval) < current)
            {
                Console.WriteLine("HelloWord");
                _old = current;
            }
        }
    }
}
