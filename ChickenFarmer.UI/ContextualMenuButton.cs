using System;
using System.Collections.Generic;
using System.Text;
using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.Window;
using SFML.System;


namespace ChickenFarmer.UI
{
    public class ContextualMenuButton : IDrawable
    {
        ContextualMenu _ctxContextualMenu;
        Vector2f _buttonSize;
        RectangleShape _buttonRectShape;
        Vector2f _buttonPos;
        Color _buttonColor;
        Vector2f _menuPos;

        public ContextualMenuButton( ContextualMenu ctxContextualMenu, Vector2f menuPos)
        {
            _ctxContextualMenu = ctxContextualMenu;
            _menuPos = menuPos;
            _buttonRectShape = ButtonBuildingType();
        }

        public RectangleShape ButtonBuildingType()
        {
            if (_ctxContextualMenu.CtxBuildingUI.BuildingCtx is Henhouse )
            {
                
                _buttonSize = new Vector2f(30, 30);
                _buttonRectShape = new RectangleShape(_buttonSize);
                _buttonPos = new Vector2f(_menuPos.X+30, _menuPos.Y+30);
                _buttonRectShape.Position = _buttonPos;
                _buttonColor = Color.Blue;
                
                return _buttonRectShape;
            }
            else
            {
                
                _buttonSize = new Vector2f(30, 30);
                _buttonRectShape = new RectangleShape(_buttonSize);
                _buttonPos = new Vector2f(_ctxContextualMenu.MenuPos.X+30, _ctxContextualMenu.MenuPos.Y+30);
                _buttonRectShape.Position = _buttonPos;
                _buttonColor = Color.White;
                return _buttonRectShape;
            }
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            //Console.WriteLine("button X : {0}, button Y : {1}", _ctxContextualMenu.ContextualButtons._buttonPos.X, _ctxContextualMenu.ContextualButtons._buttonPos.Y);
            //Console.WriteLine("Menu X : {0}, Menu Y : {1}", _ctxContextualMenu.MenuPos.X, _ctxContextualMenu.MenuPos.Y);
            _ctxContextualMenu.CtxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(_buttonRectShape);
        }

        public RectangleShape ButtonRectShape
        {
            get { return _buttonRectShape; }
        }
    }
}
