using SFML.Window;
using System;
using System.Threading;
using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;

namespace ChickenFarmer.UI
{
    internal class InputHandler
    {
        GameLoop _ctxGameLoop;
        TimeSpan _time = new TimeSpan(0, 0, 0, 0, 500);
        private DateTime _oldUpdate = DateTime.Now;
        Vector _deplacement;
        private static readonly Vector2f[] Direction = {
            new Vector2f( 5, 0),
            new Vector2f( -5, 0 ),
            new Vector2f(0, 5 ),
            new Vector2f( 0, -5 )
        };

        public InputHandler( GameLoop ctxGameLoop ) { _ctxGameLoop = ctxGameLoop; }

        public void Handle()
        {
            DateTime current = DateTime.Now;
            Vector2i mpos = Mouse.GetPosition( _ctxGameLoop.Window);
            Vector2f worldPos = _ctxGameLoop.Window.MapPixelToCoords(mpos);
            FloatRect buttonSellEggsBound = _ctxGameLoop.FarmUI.ButtonSellEggs.GetGlobalBounds();

            // var _menuBound = _ctxGameLoop.HouseMenu.Menu.GetGlobalBounds(); 
            //    var _buttonHenHouseUpgradeBound = _ctxGameLoop.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds();
            //  var _buttonBuyChickenBound = _ctxGameLoop.HouseMenu.ButtonBuyChicken.GetGlobalBounds();


            _deplacement = new Vector();

            if ( Keyboard.IsKeyPressed( Keyboard.Key.Escape ) )
            {
                _ctxGameLoop.Window.Close();
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                _deplacement += new Vector(Direction[3].X, Direction[3].Y);
                _ctxGameLoop.FarmUI.PlayerUI.Direction = 1;
                
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                _deplacement += new Vector(Direction[2].X, Direction[2].Y);
                _ctxGameLoop.FarmUI.PlayerUI.Direction = 4;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                _deplacement += new Vector(Direction[1].X, Direction[1].Y);
                _ctxGameLoop.FarmUI.PlayerUI.Direction = 2;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                _deplacement += (new Vector(Direction[0].X, Direction[0].Y));
                _ctxGameLoop.FarmUI.PlayerUI.Direction = 3;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.C) && _oldUpdate.Add(_time) < current)
            {
                _oldUpdate = DateTime.Now;
                _ctxGameLoop.TileMap.changeSeason();
            }


            //if (Keyboard.IsKeyPressed(Keyboard.Key.E) && _ctxGameLoop.FarmUI.Farm.Player.Position)
            //{
            //    _ctxGameLoop.FarmUI._playerUI.Interact();
            //}

            _ctxGameLoop.View.Center = new Vector2f(_ctxGameLoop.FarmUI.Farm.Player.Position.X, _ctxGameLoop.FarmUI.Farm.Player.Position.Y);
            _ctxGameLoop.FarmUI.Farm.Player.Move(_deplacement);



            if (Mouse.IsButtonPressed(Mouse.Button.Right) && _oldUpdate.Add(_time) < current)
            {
                _oldUpdate = DateTime.Now;
                _ctxGameLoop.FarmUI.Farm.Market.BuyHenhouse(worldPos.X, worldPos.Y);
                _ctxGameLoop.FarmUI.BuildingCollectionUI.LoadBuildings();
            }


            if (!Keyboard.IsKeyPressed(Keyboard.Key.Z) && !Keyboard.IsKeyPressed(Keyboard.Key.D) && !Keyboard.IsKeyPressed(Keyboard.Key.Q) && !Keyboard.IsKeyPressed(Keyboard.Key.S))
                _ctxGameLoop.FarmUI.PlayerUI.AnimFrame = 0;
     
         
            /*foreach ( HenhouseUi house in _ctxGameLoop.FarmUI.BuildingCollectionUI.Henhouses )
            {
                if ( house.HouseSprite == null ) return;
                FloatRect buyChickenBound = house.HouseMenu.ButtonBuyChicken.GetGlobalBounds();

                Console.WriteLine("gb : {0}", house.HouseSprite.GetGlobalBounds());



                if ( house.HouseSprite.GetGlobalBounds().Contains( mpos.X, mpos.Y ) &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) &&
                     house.HouseMenu.DrawState == false )
                {
                    foreach ( HenhouseUi item in _ctxGameLoop.FarmUI.BuildingCollectionUI.Henhouses )
                    {
                        if ( item != house )
                        {
                            if ( item.HouseMenu.DrawState )
                            {
                                item.HouseMenu.DrawState = false;
                            }
                        }
                    }

                    house.HouseMenu.DrawState = true;
                    Console.WriteLine( "button HenHouse Menu clicked" );
                    Thread.Sleep( 150 );
                }

                if ( !house.HouseMenu.Menu.GetGlobalBounds().Contains( mpos.X, mpos.Y ) &&
                     house.HouseMenu.DrawState == true &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    house.HouseMenu.DrawState = false;
                    Console.WriteLine( "button HenHouse Menu not clicked" );
                    Thread.Sleep( 150 );
                }

                if ( house.HouseMenu.DrawState && buyChickenBound.Contains( mpos.X, mpos.Y ) &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    _ctxGameLoop.FarmUI.Farm.Market.BuyChicken( 1, Chicken.Breed.Tier1 );
                    Console.WriteLine( "Chicken buyed" );

                    Thread.Sleep( 50 );
                }

                if ( house.HouseMenu.DrawState &&
                     house.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds()
                         .Contains( mpos.X, mpos.Y ) && Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    _ctxGameLoop.FarmUI.Farm.Market.UpgradeHouse( house.Ctxhouse );
                    Console.WriteLine( "house upgrade" );

                    Thread.Sleep( 50 );
                }
            }*/

            if ( buttonSellEggsBound.Contains( mpos.X, mpos.Y ) &&
                 Mouse.IsButtonPressed( Mouse.Button.Left ) )
            {
                Market.Sellegg( _ctxGameLoop.FarmUI.Farm );
                Console.WriteLine( "button SellEggs clicked" );
            }
        }
    }
}
