using System;
using System.Collections.Generic;
using System.Text;
using ChickenFarmer.Model;
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
        Texture _houseTexture = new Texture("../../../../Data/henhouse1.png");

        GameLoop _ctxGame;
        List<Shape> _housesList;

        Vector2f buttonSize = new Vector2f(64f, 96f);
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
            foreach (var building in _ctxFarm.Farm.Buildings.Buildings)
            {
                var item = (Henhouse) building;
                buttonPos = new Vector2f(buttonPos.X + 50f, 60f);


                Shape house = new RectangleShape(buttonSize)
                {
                    Position = buttonPos,
                    Texture = _houseTexture
                };
                

                _housesList.Add(house);
            }
        }



        public void Drawhouses()
        {
            foreach (var item in _housesList)
            {
                
               

                Texture _houseTexture = new Texture("../../../../Data/henhouse1.png");

                _ctxGame.Window.Draw(item);
            }
        }

        public List<Shape> HousesList { get => _housesList; set => _housesList = value; }


    }
}
