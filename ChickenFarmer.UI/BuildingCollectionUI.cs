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
        public List<BuildingUI> BuildingsUIList { get; }

        internal void LoadBuildings()
        {

            foreach (BuildingUI buildingUI in BuildingsUIList)
            {
                buildingUI.Dispose();
            }

            BuildingsUIList.Clear();

            foreach (IBuilding building in CtxfarmUI.Farm.Buildings.
                BuildingList)
            {

                CtxfarmUI.CtxGame.Window.MapPixelToCoords(
                    new Vector2i((int)building.PosVector.X,
                        (int)building.PosVector.Y));
                MapTypes type = MapTypes.None;
                Texture houseTexture;
                if (building is Henhouse)
                {
                    houseTexture = CtxfarmUI.FarmOptionsUI.HenhouseTexture[building.Lvl];
                    type = MapTypes.InnerHenhouse;
                    
                }else if(building is StorageSeed) {

                    houseTexture = CtxfarmUI.FarmOptionsUI.StorageTexture[building.Lvl];

                }
                else if (building is StorageEgg)
                {
                    houseTexture = CtxfarmUI.FarmOptionsUI.StorageTexture[building.Lvl];
       
                }
                else if (building is StorageMeat)
                {
                    houseTexture = CtxfarmUI.FarmOptionsUI.StorageTexture[building.Lvl];

                }
                else
                {
                    houseTexture = null;
                    
                }

                if ( houseTexture != null )
                    BuildingsUIList.Add(new BuildingUI(this, building,
                        new RectangleShape(( Vector2f ) houseTexture.Size)
                        {
                            Texture = houseTexture,
                            Position = new Vector2f(building.PosVector.X, building.PosVector.Y)
                        }, new Vector2f(building.PosVector.X, building.PosVector.Y), type));
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
