using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;


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
            var _bound = _ctxGameLoop.Gui.SellEggButton.GetGlobalBounds();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }

          

            if (_bound.Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.FarmUI.Farm.Market.Sellegg(_ctxGameLoop.FarmUI.Farm);
                Console.WriteLine("button clicked");
            }

        }


    }
}
