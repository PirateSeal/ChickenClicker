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
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }
        }


    }
}
