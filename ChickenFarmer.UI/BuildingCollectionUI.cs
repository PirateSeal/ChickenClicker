#region Usings

using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;
using System;
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
        public List<BuildingUI> BuildingsUIList { get; }





        internal void LoadBuildings()
        {

            foreach (var buildingUI in BuildingsUIList)
            {
                buildingUI.Dispose();
            }

            BuildingsUIList.Clear();

            Vector2f size = new Vector2f(250, 250);


            foreach (IBuilding building in CtxfarmUI.Farm.Buildings.
                BuildingList)
            {

                Vector2f worldPos = CtxfarmUI.CtxGame.Window.MapPixelToCoords(
                    new Vector2i((int)building.PosVector.X,
                        (int)building.PosVector.Y));

                Texture houseTexture;

                if (!(building is Henhouse) && !(building is IStorage)) throw new InvalidOperationException("This is not a building");
                if (building is Henhouse)
                    houseTexture =
                        CtxfarmUI.FarmOptionsUI.TextureTable[building.Lvl];
                else houseTexture =
                    CtxfarmUI.FarmOptionsUI.TextureTableStorage[
                        building.Lvl];
                BuildingsUIList.Add(new BuildingUI(this, building,
                    new RectangleShape((Vector2f)houseTexture.Size)
                    {
                        Texture = houseTexture,
                        Position = new Vector2f(building.PosVector.X,
                            building.PosVector.Y)
                    },
                    new Vector2f(building.PosVector.X, building.PosVector.Y)));
            }
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            foreach (BuildingUI item in BuildingsUIList)
            {
                target.Draw(item);
            }
        }
    }
}
