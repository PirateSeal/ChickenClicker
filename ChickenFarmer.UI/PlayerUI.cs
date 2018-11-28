using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ChickenFarmer.Model;

namespace ChickenFarmer.UI
{
    internal class PlayerUI
    {
        Player _player ;
        Texture _texture;
        private FarmUI _ctxFarmUI;
        int _animFrame;
        Vector2f _spriteSize;
        Vector2f _position;
        Sprite _sprite;
        int _columnSpriteSheet;
        int _direction;

        public PlayerUI(FarmUI ctxFarmUI, Player player)
        {
            _animFrame = 0;
            _columnSpriteSheet = 0;
            _direction = 0;
            _spriteSize = new Vector2f(16f, 32f);
            _ctxFarmUI = ctxFarmUI;
            _player = player;
            _position = new Vector2f(player.Position.X, player.Position.Y);
            _texture = new Texture("../../../../Data/SpriteSheet/Player/Player.png");
            _sprite = new Sprite(_texture);
        }

        public void DrawPlayer()
        {

            _sprite.TextureRect = new IntRect(0, 0, 16, 32);

            if (_direction == 1)
            {
                _sprite.TextureRect = new IntRect(_animFrame*16, 64, 16, 32);
                
            }
            if (_direction == 2)
            {
                _sprite.TextureRect = new IntRect(_animFrame * 16, 96, 16, 32);

            }
            if (_direction == 3)
            {
                _sprite.TextureRect = new IntRect(_animFrame * 16, 32, 16, 32);

            }
            if (_direction == 4)
            {
                _sprite.TextureRect = new IntRect(_animFrame * 16, 0, 16, 32);
            }

            if (_animFrame == 3) _animFrame = 0;

            _sprite.Position = new Vector2f(_player.Position.X, _player.Position.Y);
            _ctxFarmUI.CtxGame.Window.Draw(_sprite);
            //Console.WriteLine(_sprite.TextureRect.Left.ToString(), _sprite.TextureRect.Top, _sprite.TextureRect.Height, _sprite.TextureRect.Width);

        }



        public int AnimFrame
        {
            get { return _animFrame; }
            set { _animFrame = value; }
        }


        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector2f Position
        {
            get { return _sprite.Position; }
            set { _position = value; }
        }

        


        
    }
}
