using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using ChickenFarmer.Model;


namespace ChickenFarmer.UI
{
    class HenhouseUI
    {

        FarmUI _ctxFarm;
        HouseMenu _menu;
        GameLoop _ctxGame;
        Shape houseSprite;
        Henhouse _Ctxhouse;
        Vector2f HousePos = new Vector2f(100f, 100f);
        Vector2f HouseSize = new Vector2f(64f, 96f);
        Texture[] textures;

        public HenhouseUI(FarmUI ctxFarm ,Henhouse house,Vector2f pos)
        {
            HousePos = pos;
            _ctxFarm = ctxFarm;
            _ctxGame = _ctxFarm.CtxGame;
            _Ctxhouse = house;
            _menu = new HouseMenu(_ctxGame,house,this);

            houseSprite = new RectangleShape(HouseSize)
            {
                Position = HousePos,
            };
            textures = textures = new Texture[]{
                new Texture("../../../../Data/henhouse1.png"),
            new Texture("../../../../Data/henhouse1.png"),
            new Texture("../../../../Data/henhouse2.png"),
            new Texture("../../../../Data/henhouse1.png"),
            new Texture("../../../../Data/henhouse1.png"),
            new Texture("../../../../Data/henhouse1.png"),
            new Texture("../../../../Data/henhouse1.png")
            };
        }

       

        public void Drawhouses()
        {




            string _houseTexturePath = "../../../../Data/henhouse1.png";
            string texturePath = _houseTexturePath;
            //Texture _houseTexture = new Texture(texturePath);
            houseSprite.Texture = textures[_Ctxhouse.Lvl];


            _ctxGame.Window.Draw(houseSprite);
            _menu.DrawGui();
        }




        public Shape HouseSprite { get => houseSprite; set => houseSprite = value; }
        public HouseMenu HouseMenu { get => _menu; set => _menu = value; }
        public Henhouse Ctxhouse { get => _Ctxhouse; set => _Ctxhouse = value; }
        public Vector2f HousePos1 { get => HousePos; set => HousePos = value; }
    }
}
