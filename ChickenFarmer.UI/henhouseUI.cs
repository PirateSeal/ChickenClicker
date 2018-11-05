using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;



namespace ChickenFarmer.UI
{
    class henhouseUI
    {
        FarmUI _ctxFarm;
        HouseMenu _menu;
        Texture _houseTexture = new Texture("../../../../Data/house.png");
        GameLoop _ctxGame;
        List<Shape> _housesList;

        Vector2f buttonSize = new Vector2f(80f, 60f);
       public Vector2f buttonPos = new Vector2f(80f, 60f);


        public henhouseUI(FarmUI ctxFarm ,GameLoop ctxGame)
        {
            _ctxFarm = ctxFarm;
            _menu = new HouseMenu(ctxGame);
            _ctxGame = ctxGame;
            _housesList = new List<Shape>();
        }

        public void CreateHouses()
        {         
            foreach (var item in _ctxFarm.Farm.Houses.Henhouses)
            {
                buttonPos = new Vector2f(buttonPos.X + 50f, 60f);


                Shape house = new RectangleShape(buttonSize)
                {
                    FillColor = Color.Blue,
                    Position = buttonPos
                };

                _housesList.Add(house);
            }
        }


        public void Drawhouses()
        {
            foreach (var item in _housesList)
            {
                _ctxGame.Window.Draw(item);
            }
        }

        public List<Shape> HousesList { get => _housesList; set => _housesList = value; }


    }
}
