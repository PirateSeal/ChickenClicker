using ChickenFarmer.Model;
using SFML.Window;
using System;
using System.Threading;

namespace ChickenFarmer.UI
{
    internal class InputHandler
    {
        private readonly GameLoop _ctxGameLoop;

        public InputHandler(GameLoop ctxGameLoop)
        {
            _ctxGameLoop = ctxGameLoop;

        }



        public void Handle()
        {
            var mpos = Mouse.GetPosition(_ctxGameLoop.Window);

            var houseBound = _ctxGameLoop.FarmUI.Henhouses.HousesList[0].GetGlobalBounds();
            var buttonSellEggsBound = _ctxGameLoop.FarmUI.ButtonSellEggs.GetGlobalBounds();
            var menuBound = _ctxGameLoop.HouseMenu.Menu.GetGlobalBounds();
            var buttonHenHouseUpgradeBound = _ctxGameLoop.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds();
            var buttonBuyChickenBound = _ctxGameLoop.HouseMenu.ButtonBuyChicken.GetGlobalBounds();


            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }

            if (houseBound.Contains(mpos.X, mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.HouseMenu.DrawState = true;
                Console.WriteLine("button HenHouse Menu clicked");
                Thread.Sleep(200);

            }

            if (!menuBound.Contains(mpos.X, mpos.Y) && _ctxGameLoop.HouseMenu.DrawState && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.HouseMenu.DrawState = false;
            }


            if (buttonSellEggsBound.Contains(mpos.X, mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Market.Sellegg(_ctxGameLoop.FarmUI.Farm);
                Console.WriteLine("button SellEggs clicked");
            }


            if (buttonBuyChickenBound.Contains(mpos.X, mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) && _ctxGameLoop.HouseMenu.DrawState)
            {
                _ctxGameLoop.FarmUI.Farm.Market.BuyChicken(_ctxGameLoop.FarmUI.Farm.Buildings.Henhouses[0], 1, 1);
                Console.WriteLine("button Buy Chicken clicked");
            }
            if (buttonHenHouseUpgradeBound.Contains(mpos.X, mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) && _ctxGameLoop.HouseMenu.DrawState == true)
            {
                _ctxGameLoop.FarmUI.Farm.Market.UpgradeHouse(_ctxGameLoop.FarmUI.Farm.Houses.Henhouses[0]);
                Console.WriteLine("button HenHouse Upgrade clicked");
                Thread.Sleep(1000);
            }




        }


    }
}
