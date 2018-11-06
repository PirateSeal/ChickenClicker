using System;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;


namespace ChickenFarmer.UI
{

    public class GameLoop
    {
        InputHandler _playerInput;
        RenderWindow _window;
        Event _input;
        TimeSpan _interval = new TimeSpan(0, 0, 0, 0, 100);
        DateTime _old = DateTime.Now;
        FarmUI _farmUI;
        HouseMenu _houseMenu;
        
        

        public GameLoop()
        {
            _window = new RenderWindow(new VideoMode(1280, 720), "ChickenFarmer", Styles.Default);
            _window.SetFramerateLimit(60);


            _farmUI = new FarmUI(this);
            _playerInput = new InputHandler(this);
            _houseMenu = new HouseMenu(this);

        }

        public RenderWindow Window { get => _window; set => _window = value; }
        public HouseMenu HouseMenu { get => _houseMenu; set => _houseMenu = value; }
        internal FarmUI FarmUI { get => _farmUI; set => _farmUI = value; }

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
            Vector2f buttonsize = new Vector2f(80f, 60f);


            Shape _square = new RectangleShape(size);
            _square.FillColor = Color.Red;
            Texture texture = new Texture("../../../../Data/farm_background.jpg");
            Sprite background = new Sprite(texture);


            Shape _button = new RectangleShape(buttonsize);
            _button.FillColor = Color.Blue;
            _button.Position = size;


            while (_window.IsOpen)
            {





                _playerInput.Handle();
                _window.Clear();
                _window.Draw(_square);
                _window.Draw(background);
                _farmUI.Henhouses.Drawhouses();
                
                _houseMenu.DrawGui();
                _farmUI.DrawInfo();
                _farmUI.DrawButtonSellEggs();
                _window.Display();
               
                Update();



           

            }
        }


        public void Update()
        {
            DateTime current = DateTime.Now;
            if (_old.Add(_interval) < current)
            {
                _farmUI.update();
                _old = current;
            }
        }

       
    }
}
