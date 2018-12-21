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
        public ContextualMenu CtxContextualMenu { get; }
        public Vector2f ButtonSize { get; private set; }
        public List<RectangleShape> ButtonRectShapeList { get; } = new List<RectangleShape>();
        public RectangleShape ButtonRectShape2 { get; private set; }
        public Vector2f ButtonPos1 { get; private set; }
        public Vector2f ButtonPos2 { get; private set; }
        public Vector2f MenuPos { get; }

        public ContextualMenuButton( ContextualMenu ctxContextualMenu, Vector2f menuPos)
        {
            CtxContextualMenu = ctxContextualMenu;
            MenuPos = menuPos;
            ButtonRectShapeList = ButtonBuildingType();
        }

        public List<RectangleShape> ButtonBuildingType()
        {
            if (CtxContextualMenu.CtxBuildingUI.BuildingCtx is Henhouse )
            {
                
                ButtonSize = new Vector2f(30, 30);
                ButtonRectShape = new RectangleShape(ButtonSize);
                ButtonPos1 = new Vector2f(MenuPos.X+30, MenuPos.Y+30);
                ButtonRectShape.Position = ButtonPos1;
                ButtonRectShape.FillColor = Color.Blue;

                ButtonRectShapeList.Add(ButtonRectShape);

                ButtonRectShape2 = new RectangleShape(ButtonSize);
                ButtonPos2 = new Vector2f(MenuPos.X + 70, MenuPos.Y + 30);
                ButtonRectShape2.Position = ButtonPos2;
                ButtonRectShape2.FillColor = Color.Green;

                ButtonRectShapeList.Add(ButtonRectShape2);

                return ButtonRectShapeList;


            }
            else
            {
                
                ButtonSize = new Vector2f(30, 30);
                ButtonRectShape = new RectangleShape(ButtonSize);

                ButtonPos1 = new Vector2f(CtxContextualMenu.MenuPos.X+30, CtxContextualMenu.MenuPos.Y+30);
                ButtonRectShape.Position = ButtonPos1;
                ButtonRectShape.FillColor = Color.Cyan;
                ButtonRectShapeList.Add(ButtonRectShape);

                return ButtonRectShapeList;
            }
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            //Console.WriteLine("button X : {0}, button Y : {1}", _ctxContextualMenu.ContextualButtons._buttonPos.X, _ctxContextualMenu.ContextualButtons._buttonPos.Y);
            //Console.WriteLine("Menu X : {0}, Menu Y : {1}", _ctxContextualMenu.MenuPos.X, _ctxContextualMenu.MenuPos.Y);
            foreach (RectangleShape item in ButtonRectShapeList)
            {
                CtxContextualMenu.CtxBuildingUI.CtxBuildingCollectionUi.CtxfarmUI.CtxGame.Window.Draw(item);
            }
            
        }

        public RectangleShape ButtonRectShape { get; private set; }
    }
}
