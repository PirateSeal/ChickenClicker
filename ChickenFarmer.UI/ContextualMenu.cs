using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;


namespace ChickenFarmer.UI

{
    public class ContextualMenu : IDrawable, IDisposable
    {
        public Vector2f MenuSize { get; } = new Vector2f(150, 100);
        public Color Color { get; } = Color.Red;

        public ContextualMenu(BuildingUI ctxBuildingUI)
        {
            CtxBuildingUI = ctxBuildingUI;
            MenuPos = new Vector2f(CtxBuildingUI.Pos.X, (CtxBuildingUI.Pos.Y + CtxBuildingUI.Shape.Size.Y));
            TotalMenu = new RectangleShape(MenuSize) { Position = MenuPos};
            Texture texture = new Texture("../../../../Data/Menu/contextualmenu.png");
            TotalMenu.Texture = texture;
            ContextualButtons = new ContextualMenuButton(this, MenuPos);
        }

        

        public void Dispose()
        {
            TotalMenu.Dispose();
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            //Console.WriteLine("menu X {0} menu Y {1}", ContextualButtons.ButtonRectShape.Position.X, ContextualButtons.ButtonRectShape.Position.Y);

            CtxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(TotalMenu);
            ContextualButtons.Draw(target, states);
            //Console.WriteLine("buiding type : {0}", _ctxBuildingUI.BuildingCtx.GetType().ToString());
            //target.Draw(_totalMenu, states);
        }

        
        public Vector2f MenuPos { get; }
        public RectangleShape TotalMenu { get; }
        public BuildingUI CtxBuildingUI { get; set; }
        public ContextualMenuButton ContextualButtons { get; set; }
    }
}

