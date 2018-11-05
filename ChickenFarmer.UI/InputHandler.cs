using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChickenFarmer.UI
{
    class InputHandler
    {

        GameLoop _ctxGameLoop;

        public InputHandler(GameLoop ctxGameLoop)
        {
            _ctxGameLoop = ctxGameLoop;
        }
        


        public void Handle()
        {
            var Mpos = Mouse.GetPosition(_ctxGameLoop.Window);
            var _bound = _ctxGameLoop.HouseMenu.SellEggButton.GetGlobalBounds();
            var _houseBound = _ctxGameLoop.FarmUI.Henhouses.HousesList[0].GetGlobalBounds();


            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }

            if(_houseBound.Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.HouseMenu.DrawState = true;
                Console.WriteLine("button clicked");
                Thread.Sleep(200);

            }

            if (!_bound.Contains(Mpos.X, Mpos.Y) && _ctxGameLoop.HouseMenu.DrawState == true && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.HouseMenu.DrawState = false;
               
            }

          

            if (_bound.Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) && _ctxGameLoop.HouseMenu.DrawState == true )
            {
                _ctxGameLoop.FarmUI.Farm.Market.Sellegg(_ctxGameLoop.FarmUI.Farm);
                Console.WriteLine("button clicked");
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.P))
            {
                _ctxGameLoop.FarmUI.Farm.Market.BuyChicken(_ctxGameLoop.FarmUI.Farm.Houses.Henhouses[0], 1, 1);
            }

        }


    }
}
