#region Usings

using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.UI
{
    public class BuildingCollectionUI
    {
        public BuildingCollectionUI(FarmUI farmUi)
        {
            CtxfarmUI = farmUi;
            Buildings = new List<BuildingUI>();
            LoadBuildings();
        }

        public FarmUI CtxfarmUI { get; }
        private List<BuildingUI> Buildings { get; }

        private void LoadBuildings()
        {
            foreach (Building building in CtxfarmUI.Farm.Buildings.Buildings)
            {
                Buildings.Add(new BuildingUI(this, building, new RectangleShape(){FillColor =  new Color(255,255,255)}, new Vector2f(building.PosVector.X, building.PosVector.Y)));
            }
        }

        public void DrawBuildings(IRenderTarget target, RenderStates states)
        {
            foreach (BuildingUI item in Buildings) item.Draw(target, states);
        }
    }
}