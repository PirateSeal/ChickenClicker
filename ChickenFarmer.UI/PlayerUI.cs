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
        Vector2f _spriteSize;
        Vector2f _position;
        RectangleShape _sprite;

        public PlayerUI(FarmUI ctxFarmUI, Player player, Vector2f position)
        {
            _spriteSize = new Vector2f(64f, 96f);
            _ctxFarmUI = ctxFarmUI;
            _position = position;
            _player = player;
            _texture = new Texture("../../../../Data/henhouse1.png");
            _sprite = new RectangleShape(_spriteSize);
            
        }

        public void DrawPlayer()
        {
            _sprite.Texture = _texture;
            _sprite.Position = _position;
            _ctxFarmUI.CtxGame.Window.Draw(_sprite);
        }


        
    }
}
