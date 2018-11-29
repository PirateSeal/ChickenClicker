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
        public BuildingUI(BuildingCollectionUI ctx, IBuilding building , RectangleShape shape, Vector2f pos)
        {
            Shape = shape ?? throw new ArgumentNullException(nameof(shape));
            CtxBuildingCollectionUi = ctx;
            Menu = new ContextualMenu(this);
            Pos = pos;
            BuildingCtx = building;
        }

        public IBuilding BuildingCtx { get; set; }

        public BuildingCollectionUI CtxBuildingCollectionUi { get; }
        public RectangleShape Shape { get; }
        public Vector2f Pos { get; }
        public ContextualMenu Menu { get; }
        public Texture BuildingTexture { get; set; }

        public void Dispose() { Shape.Dispose(); Menu.Dispose(); }

        public void Draw(IRenderTarget target, in RenderStates states)
        {

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