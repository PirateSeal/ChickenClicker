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
        RectangleShape _buttonRectShape1;
        RectangleShape _buttonRectShape2;
        List<RectangleShape> _buttonRectShapeList = new List<RectangleShape>();
        Vector2f _buttonPos1;
        Vector2f _buttonPos2;
        Vector2f _menuPos;

        public ContextualMenuButton( ContextualMenu ctxContextualMenu, Vector2f menuPos)
        {
            _ctxContextualMenu = ctxContextualMenu;
            _menuPos = menuPos;
            _buttonRectShapeList = ButtonBuildingType();
        }

        public List<RectangleShape> ButtonBuildingType()
        {
            if (_ctxContextualMenu.CtxBuildingUI.BuildingCtx is Henhouse )
            {
                
                _buttonSize = new Vector2f(30, 30);
                _buttonRectShape1 = new RectangleShape(_buttonSize);
                _buttonPos1 = new Vector2f(_menuPos.X+30, _menuPos.Y+30);
                _buttonRectShape1.Position = _buttonPos1;
                _buttonRectShape1.FillColor = Color.Blue;

                _buttonRectShapeList.Add(_buttonRectShape1);

                _buttonRectShape2 = new RectangleShape(_buttonSize);
                _buttonPos2 = new Vector2f(_menuPos.X + 70, _menuPos.Y + 30);
                _buttonRectShape2.Position = _buttonPos2;
                _buttonRectShape2.FillColor = Color.Green;

                _buttonRectShapeList.Add(_buttonRectShape2);

                return _buttonRectShapeList;


            }
            else
            {
                
                _buttonSize = new Vector2f(30, 30);
                _buttonRectShape1 = new RectangleShape(_buttonSize);
                _buttonPos1 = new Vector2f(_ctxContextualMenu.MenuPos.X+30, _ctxContextualMenu.MenuPos.Y+30);
                _buttonRectShape1.Position = _buttonPos1;
                _buttonRectShape1.FillColor = Color.Cyan;

                _buttonRectShapeList.Add(_buttonRectShape1);

                return _buttonRectShapeList;
            }
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            //Console.WriteLine("button X : {0}, button Y : {1}", _ctxContextualMenu.ContextualButtons._buttonPos.X, _ctxContextualMenu.ContextualButtons._buttonPos.Y);
            //Console.WriteLine("Menu X : {0}, Menu Y : {1}", _ctxContextualMenu.MenuPos.X, _ctxContextualMenu.MenuPos.Y);
            foreach (RectangleShape item in _buttonRectShapeList)
            {
                _ctxContextualMenu.CtxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(item);
            }
            
        }

        public List<RectangleShape> ButtonRectShapeList
        {
            get { return _buttonRectShapeList; }
        }


        public RectangleShape ButtonRectShape
        {
            get { return _buttonRectShape1; }
        }
    }
}
