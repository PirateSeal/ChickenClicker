using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;


namespace ChickenFarmer.UI

{
    public class ContextualMenu : IDrawable, IDisposable
    {

        BuildingUI _ctxBuildingUI;
        private Type _buildingType;
        ContextualMenuButton _contextualButtons;
        Texture _texture;
        public RectangleShape _totalMenu;
        Vector2f _menuSize = new Vector2f(150, 100);
        Vector2f _menuPos;
        Color _color = Color.Red;

        

        

        public ContextualMenu(BuildingUI ctxBuildingUI)
        {
            _ctxBuildingUI = ctxBuildingUI;
            _menuPos = new Vector2f(_ctxBuildingUI.Pos.X, (_ctxBuildingUI.Pos.Y + _ctxBuildingUI.Shape.Size.Y));
            _totalMenu = new RectangleShape(_menuSize);
            _totalMenu.Position = _menuPos;
            _totalMenu.FillColor = _color;
            _contextualButtons = new ContextualMenuButton(this, _menuPos);
        }

        

        public void Dispose()
        {
            _totalMenu.Dispose();
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            //Console.WriteLine("menu X {0} menu Y {1}", ContextualButtons.ButtonRectShape.Position.X, ContextualButtons.ButtonRectShape.Position.Y);

            _ctxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(_totalMenu);
            _contextualButtons.Draw(target, states);
            //Console.WriteLine("buiding type : {0}", _ctxBuildingUI.BuildingCtx.GetType().ToString());
            //target.Draw(_totalMenu, states);
        }

        
        public Vector2f MenuPos
        {
            get { return _menuPos; }
        }

        public RectangleShape TotalMenu
        {
            get { return _totalMenu; }
        }

        public BuildingUI CtxBuildingUI { get => _ctxBuildingUI; set => _ctxBuildingUI = value; }
        public BuildingUI CtxBuildingUI1 { get => _ctxBuildingUI; set => _ctxBuildingUI = value; }
        public ContextualMenuButton ContextualButtons { get => _contextualButtons; set => _contextualButtons = value; }
    }
}

