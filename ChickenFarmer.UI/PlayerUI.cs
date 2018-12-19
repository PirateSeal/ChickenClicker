using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ChickenFarmer.Model;

namespace ChickenFarmer.UI
{
    public class PlayerUI : IDrawable
    {
        public Player Player { get; }
        public Texture Texture { get; }
        public FarmUI CtxFarmUI { get; }
        public Vector2f SpriteSize { get; }
        public Vector2f Position { get; }
        public Sprite Sprite { get; }

        public PlayerUI(FarmUI ctxFarmUI, Player player)
        {
            AnimFrame = 0;
            Direction = 0;
            SpriteSize = new Vector2f(16f, 32f);
            CtxFarmUI = ctxFarmUI;
            Player = player;
            Position = new Vector2f(player.Position.X, player.Position.Y);
            Texture = new Texture("../../../../Data/SpriteSheet/Player/Player.png");
            Sprite = new Sprite(Texture);
        }

        public void AnimationLoop()
        {
            
            Sprite.TextureRect = new IntRect(0, 0, 16, 32);

            if (Direction == 1)
            {
                Sprite.TextureRect = new IntRect(AnimFrame * 16, 64, 16, 32);
            }
            if (Direction == 2)
            {
                Sprite.TextureRect = new IntRect(AnimFrame * 16, 96, 16, 32);
            }
            if (Direction == 3)
            {
                Sprite.TextureRect = new IntRect(AnimFrame * 16, 32, 16, 32);
            }
            if (Direction == 4)
            {
                Sprite.TextureRect = new IntRect(AnimFrame * 16, 0, 16, 32);
            }

            if (AnimFrame == 3) AnimFrame = 0;
            
   

        }

    

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            target.Draw(Sprite);
            
            //Console.WriteLine("sprite X : {0}  sprite Y : {1}  sprite.TextureREct : {2}", _sprite.Position.X, _sprite.Position.Y, _sprite.TextureRect);
            
        }

        public void UpdateSpritePosition()
        {


            Sprite.Position = new Vector2f(Player.Position.X, Player.Position.Y);
        }

        public int AnimFrame { get; set; }


        public int Direction { get; set; }
    }
}
