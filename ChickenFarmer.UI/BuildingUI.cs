#region Usings

using System;
using SFML.Graphics;
using SFML.System;

#endregion

namespace ChickenFarmer.UI
{
    public class BuildingUI : IDrawable, IDisposable
    {
        public BuildingUI( BuildingCollectionUI ctx, RectangleShape shape, Vector2f pos )
        {
            Shape = shape ?? throw new ArgumentNullException( nameof(shape) );
            CtxBuildingCollectionUi = ctx;
            Menu = new ContextualMenu();
            Pos = pos;

        }

        public BuildingCollectionUI CtxBuildingCollectionUi { get; }
        public RectangleShape Shape { get; }
        public Vector2f Pos { get; }
        public ContextualMenu Menu { get; }
        public Texture BuildingTexture { get; set; }

        public void Dispose() { throw new NotImplementedException(); }

        public void Draw( IRenderTarget target, in RenderStates states ) { target.Draw( Shape ); }

        public void Texturize<TBuildingType>( int buildingLvl ) where TBuildingType : BuildingUI
        {
            CtxBuildingCollectionUi.CtxfarmUI.FarmOptionsUI.TextureDictionary.TryGetValue(
                typeof( TBuildingType ), out Texture[] textures );
            if ( textures != null ) BuildingTexture = textures[buildingLvl];
        }
    }
}