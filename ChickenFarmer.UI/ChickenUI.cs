using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmer.UI
{
   public class ChickenUI : IDrawable
    {
        public Chicken Chicken { get; }
        public Texture Texture { get; }
        public Texture DeathTexture { get; }
        public FarmUI CtxFarmUI { get; }
        public Vector2f SpriteSize { get; }
        public Vector2f Position { get; }
        public Sprite Sprite { get; }
        public Vector2f MaxPointLeftUpHenHouse { get; set; }
        public Vector2f MaxPointLeftDownHenHouse { get; set; }
        public bool DeathState { get; set; }


        public ChickenUI(FarmUI ctxFarmUI, Chicken chicken, int incrementX, int incrementY, int countChickenSpawn)
        {
            AnimFrame = 0;
            Direction = 0;
            SpriteSize = new Vector2f(16f, 32f);
            CtxFarmUI = ctxFarmUI;
            Chicken = chicken;
            MaxPointLeftUpHenHouse = new Vector2f(300,197);
            MaxPointLeftDownHenHouse = new Vector2f(540, 453);
            DeathState = false;


            Position = new Vector2f(MaxPointLeftUpHenHouse.X + incrementX, 300 + incrementY);
           
            if(countChickenSpawn == 3 )
            {
                Vector2f NewPosition = new Vector2f(MaxPointLeftUpHenHouse.X + incrementX, Position.Y + 50);

                Position = NewPosition;
            }
            
            Texture = new Texture("../../../../Data/chicken_walk.png");
            DeathTexture = new Texture("../../../../Data/death_chicken.png");
            Sprite = new Sprite(Texture);
            Sprite.Position = Position;
        }

        public void AnimationLoop()
        {
           Sprite.TextureRect = new IntRect(AnimFrame * 32, 64, 32, 32);
           if (AnimFrame == 3) AnimFrame = 0;

           if(DeathState == true)
            {
                Sprite.TextureRect = new IntRect(0, 0, 27, 18);
            }

        }

        public void Dispose() { Sprite.Dispose(); }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            if (Chicken.IsAlive == false && DeathState == false)
            {
                Sprite.Texture = DeathTexture;
                Sprite.Position = Position;

                DeathState = true;
            }

            target.Draw(Sprite);

            //Console.WriteLine("sprite X : {0}  sprite Y : {1}  sprite.TextureREct : {2}", _sprite.Position.X, _sprite.Position.Y, _sprite.TextureRect);
        }
        public int AnimFrame { get; set; }


        public int Direction { get; set; }
        public Vector2f OldPos { get; internal set; }
    }

}
