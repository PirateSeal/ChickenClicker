using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;


namespace ChickenFarmer.UI

{
    public class ContextualMenu : IDrawable, IDisposable
    {

        BuildingUI _ctxBuildingUI;
        Texture _texture;
        RectangleShape _totalMenu;
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
        }

        public void Dispose()
        {
            _totalMenu.Dispose();
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            _ctxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(_totalMenu);
            //target.Draw(_totalMenu, states);
        }


        public Vector2f MenuPos
        {
            get { return _menuPos; }
        }
    }
}

