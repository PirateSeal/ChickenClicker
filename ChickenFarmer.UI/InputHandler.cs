﻿#region Usings

using System;
using ChickenFarmer.Model;
using SFML.System;
using SFML.Window;

#endregion

namespace ChickenFarmer.UI
{
    public class InputHandler
    {
        private static readonly Vector2f[] Direction =
        {
            new Vector2f(5, 0), new Vector2f(-5, 0), new Vector2f(0, 5), new Vector2f(0, -5)
        };

        private Vector _deplacement;
        private DateTime _oldUpdate = DateTime.Now;

        public InputHandler(GameLoop ctxGameLoop) { CtxGameLoop = ctxGameLoop; }
        public GameLoop CtxGameLoop { get; }
        public TimeSpan Time { get; } = new TimeSpan(0, 0, 0, 0, 500);

        public void Handle()
        {
            DateTime current = DateTime.Now;
            Vector2i mpos = Mouse.GetPosition(CtxGameLoop.Window);
            Vector2f worldPos = CtxGameLoop.Window.MapPixelToCoords(mpos);

            // var _menuBound = _ctxGameLoop.HouseMenu.Menu.GetGlobalBounds(); 
            //    var _buttonHenHouseUpgradeBound = _ctxGameLoop.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds();
            //  var _buttonBuyChickenBound = _ctxGameLoop.HouseMenu.ButtonBuyChicken.GetGlobalBounds();

            _deplacement = new Vector();

            if ( Keyboard.IsKeyPressed(Keyboard.Key.Escape) ) CtxGameLoop.Window.Close();
            if ( Keyboard.IsKeyPressed(Keyboard.Key.Z) )
            {
                _deplacement += new Vector(Direction[3].X, Direction[3].Y);
                CtxGameLoop.FarmUI.PlayerUI.Direction = 1;
            }

            if ( Keyboard.IsKeyPressed(Keyboard.Key.S) )
            {
                _deplacement += new Vector(Direction[2].X, Direction[2].Y);
                CtxGameLoop.FarmUI.PlayerUI.Direction = 4;
            }

            if ( Keyboard.IsKeyPressed(Keyboard.Key.Q) )
            {
                _deplacement += new Vector(Direction[1].X, Direction[1].Y);
                CtxGameLoop.FarmUI.PlayerUI.Direction = 2;
            }

            if ( Keyboard.IsKeyPressed(Keyboard.Key.D) )
            {
                _deplacement += new Vector(Direction[0].X, Direction[0].Y);
                CtxGameLoop.FarmUI.PlayerUI.Direction = 3;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.C) && _oldUpdate.Add(Time) < current && CtxGameLoop.MapManager.CurrentType == MapTypes.World)
            {
                 _oldUpdate = DateTime.Now;
                CtxGameLoop.FarmUI.FarmOptionsUI.MapPath.TryGetValue((int)MapTypes.InnerHenhouse, out var value);
                CtxGameLoop.MapManager.CurrentMap.ChangeSeason();
            }

            if ( Keyboard.IsKeyPressed(Keyboard.Key.V) && _oldUpdate.Add(Time) < current )
                CtxGameLoop.TileMap = new TileMap("../../../../Data/map/henhouse.tmx", CtxGameLoop);

            CtxGameLoop.View.Center = new Vector2f(CtxGameLoop.FarmUI.Farm.Player.Position.X
                , CtxGameLoop.FarmUI.Farm.Player.Position.Y);

            CtxGameLoop.FarmUI.Farm.Player.Move(_deplacement);
        



            foreach (BuildingUI buildingUI in CtxGameLoop.FarmUI.BuildingCollectionUI.BuildingsUIList)
            {
                if ( buildingUI.Shape.GetGlobalBounds().Contains(worldPos.X, worldPos.Y) &&
                     Mouse.IsButtonPressed(Mouse.Button.Left) )
                    buildingUI.DrawMenuState = true;
                for (int i = 0; i < buildingUI.Menu.ContextualButtons.ButtonRectShapeList.Count - 1; i ++)
                    if ( buildingUI.Menu.ContextualButtons.ButtonRectShapeList[0].
                             GetGlobalBounds().
                             Contains(worldPos.X, worldPos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {
                        Market.Sellegg();
                        Console.WriteLine("button SellEggs clicked");
                    }
                    else if ( buildingUI.Menu.ContextualButtons.ButtonRectShapeList[1].
                                  GetGlobalBounds().
                                  Contains(worldPos.X, worldPos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {
                        Market.BuyChicken(1, Chicken.Breed.Tier1);
                        Console.WriteLine("button BuyChicken clicked");
                    }

                if (CtxGameLoop.MapManager.CurrentType == MapTypes.World)
                {
                    if (!buildingUI.Shape.GetGlobalBounds().Contains(worldPos.X, worldPos.Y) && !buildingUI.Menu.TotalMenu.GetGlobalBounds().Contains(worldPos.X, worldPos.Y) &&
                         Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        buildingUI.DrawMenuState = false;
                    }


                    if (buildingUI.BuildingCtx is Henhouse henhouse)
                    {
                        if (henhouse.EntryZone.Isin(CtxGameLoop.FarmUI.Farm.Player.BoundingBox) && Keyboard.IsKeyPressed(Keyboard.Key.E))
                        {
                            CtxGameLoop.MapManager.LoadMap(buildingUI.MapTypes, henhouse.Lvl);
                        }

                    }
                    if (buildingUI.BuildingCtx is Builder house)
                    {
                        if (house.EntryZone.Isin(CtxGameLoop.FarmUI.Farm.Player.BoundingBox) && Keyboard.IsKeyPressed(Keyboard.Key.E))
                        {
                            CtxGameLoop.MapManager.LoadMap(buildingUI.MapTypes, house.Lvl);
                        }

                    }
                }

                if (CtxGameLoop.MapManager.CurrentType == MapTypes.InnerHenhouse )
                {
                    if (buildingUI.BuildingCtx is Henhouse henhouse)
                    {
                        if (henhouse.LeaveZone.Isin(CtxGameLoop.FarmUI.Farm.Player.BoundingBox) && Keyboard.IsKeyPressed(Keyboard.Key.E))
                        {
                            CtxGameLoop.MapManager.LoadMap(MapTypes.World);
                        }

                    }
                }



            }

            if ( Mouse.IsButtonPressed(Mouse.Button.Right) && _oldUpdate.Add(Time) < current )
            {
                _oldUpdate = DateTime.Now;
                Market.BuyBuilding<Henhouse>(worldPos.X, worldPos.Y);
                CtxGameLoop.FarmUI.BuildingCollectionUI.LoadBuildings();
            }

            if ( !Keyboard.IsKeyPressed(Keyboard.Key.Z) && !Keyboard.IsKeyPressed(Keyboard.Key.D) &&
                 !Keyboard.IsKeyPressed(Keyboard.Key.Q) && !Keyboard.IsKeyPressed(Keyboard.Key.S) )
                CtxGameLoop.FarmUI.PlayerUI.AnimFrame = 0;

         
        }
    }
}