#region Usings

using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.UI
{
    public class BuildingCollectionUI : IDrawable
    {
        public BuildingCollectionUI(FarmUI farmUi)
        {
            CtxfarmUI = farmUi;
            BuildingsUIList = new List<BuildingUI>();
            LoadBuildings();
        }

        public FarmUI CtxfarmUI { get; }
        private List<BuildingUI> BuildingsUIList { get; }

     



        internal void LoadBuildings()
        {
           
            foreach (var buildingUI in BuildingsUIList)
            {
                buildingUI.Dispose();
            }
            BuildingsUIList.Clear();

            var _size = new Vector2f(250, 250);


            foreach (IBuilding building in CtxfarmUI.Farm.Buildings.BuildingList)
            {

                Vector2f worldPos = CtxfarmUI.CtxGame.Window.MapPixelToCoords(new Vector2i((int)building.PosVector.X , (int)building.PosVector.Y));

                if (building is Henhouse)
                {
                    Texture HouseTexture = CtxfarmUI.FarmOptionsUI.TextureTable[building.Lvl]; 
                    

                    BuildingsUIList.Add(
                        new BuildingUI(
                            this, 
                            building,
                            new RectangleShape(
                                (Vector2f)HouseTexture.Size)
                                {
                                    Texture = HouseTexture,
                                    Position = new Vector2f(worldPos.X, worldPos.Y)
                                }, 
                                new Vector2f(worldPos.X, worldPos.Y)
                        )
                    );

                }

                if (building is Storage)
                {
                    Texture HouseTexture = CtxfarmUI.FarmOptionsUI.TextureTableStorage[building.Lvl];

                    BuildingsUIList.Add(new BuildingUI(
                        this,
                        building,
                        new RectangleShape((Vector2f)HouseTexture.Size)
                        {
                          Texture = HouseTexture,
                          Position = new Vector2f(worldPos.X, worldPos.Y)
                        },
                        new Vector2f(worldPos.X, worldPos.Y)

                        ));

                }


            }
        }

        public void Draw(IRenderTarget target,in RenderStates states)
        {

            foreach (BuildingUI item in BuildingsUIList)
            {
                target.Draw(item);
            }
        }
    }
}