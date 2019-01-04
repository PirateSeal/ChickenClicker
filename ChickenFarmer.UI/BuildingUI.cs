#region Usings

using System;
using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;

#endregion

namespace ChickenFarmer.UI
{
    public class BuildingUI : IDrawable, IDisposable
    {

        public BuildingUI(BuildingCollectionUI ctx, IBuilding building , RectangleShape shape, Vector2f pos ,MapTypes type)
        {

            Shape = shape ?? throw new ArgumentNullException(nameof(shape));
            CtxBuildingCollectionUi = ctx;
            Pos = pos;
            BuildingCtx = building;
            Menu = new ContextualMenu(this);
            DrawMenuState = false;
            MapTypes = type;
        }

        public MapTypes MapTypes { get; }
        public IBuilding BuildingCtx { get; set; }
        public bool DrawMenuState { get; set; }
        public BuildingCollectionUI CtxBuildingCollectionUi { get; }
        public RectangleShape Shape { get; }
        public Vector2f Pos { get; }
        public ContextualMenu Menu { get; }
        public Texture BuildingTexture { get; set; }
       

        public void Dispose() { Shape.Dispose(); Menu.Dispose(); }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            
            if (DrawMenuState) Menu.Draw(target, states);
            //else if (DrawMenuState == false) Menu.TotalMenu.Dispose();

            Shape.Draw(target,states);
        }

//        public void Texturize<TBuildingType>() where TBuildingType : BuildingUI
//        {
//            CtxBuildingCollectionUi.CtxfarmUI.FarmOptionsUI.TextureDictionary.
//                TryGetValue(typeof(TBuildingType), out Texture[] textures);
//            if ( textures != null ) BuildingTexture = textures[];
//        }
    }
}