using SFML.Window;
using System;
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
            var _buttonSellEggsBound = _ctxGameLoop.FarmUI.ButtonSellEggs.GetGlobalBounds();


            //      var _menuBound = _ctxGameLoop.HouseMenu.Menu.GetGlobalBounds(); 
            //    var _buttonHenHouseUpgradeBound = _ctxGameLoop.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds();
            //  var _buttonBuyChickenBound = _ctxGameLoop.HouseMenu.ButtonBuyChicken.GetGlobalBounds();




            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _ctxGameLoop.Window.Close();
            }


            foreach (var house in _ctxGameLoop.FarmUI.HenhouseCollection.Henhouses)
            {
                if (house.HouseSprite  == null) return;
                var buyChickenBound = house.HouseMenu.ButtonBuyChicken.GetGlobalBounds();

                

                if (house.HouseSprite.GetGlobalBounds().Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) && house.HouseMenu.DrawState == false )
                {
                    foreach (var item in _ctxGameLoop.FarmUI.HenhouseCollection.Henhouses)
                    {
                        if (item != house)
                        {
                            if (item.HouseMenu.DrawState)
                            {
                                item.HouseMenu.DrawState = false;
                            }
                        }
                    }

                    house.HouseMenu.DrawState = true;
                    Console.WriteLine("button HenHouse Menu clicked");
                    Thread.Sleep(150);

                }

                if (!house.HouseMenu.Menu.GetGlobalBounds().Contains(Mpos.X, Mpos.Y) && house.HouseMenu.DrawState == true && Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    house.HouseMenu.DrawState = false;
                    Console.WriteLine("button HenHouse Menu not clicked");
                    Thread.Sleep(150);

                }

               

                if (house.HouseMenu.DrawState && buyChickenBound.Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _ctxGameLoop.FarmUI.Farm.Market.BuyChicken(house.Ctxhouse, 1, 1);
                    Console.WriteLine("Chicken buyed");

                    Thread.Sleep(50);
                }

                if (house.HouseMenu.DrawState && house.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds().Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
                {

                    _ctxGameLoop.FarmUI.Farm.Market.UpgradeHouse(house.Ctxhouse);
                    Console.WriteLine("house upgrade");

                    Thread.Sleep(50);
                }


            }

           

            if (_buttonSellEggsBound.Contains(Mpos.X, Mpos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctxGameLoop.FarmUI.Farm.Market.Sellegg(_ctxGameLoop.FarmUI.Farm);
                Console.WriteLine("button SellEggs clicked");
            }






        }


    }
}
