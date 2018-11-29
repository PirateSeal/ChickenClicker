using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;


namespace ChickenFarmer.UI

{
    public class ContextualMenu : IDrawable, IDisposable
    {
        Shape _totalMenu;
        Vector2f _menuSize = new Vector2f(50, 50);
        Vector2f _menuPos;
        Color color = Color.Red;

        public ContextualMenu(BuildingUI ctxBuilding)
        {
            _menuPos = new Vector2f(ctxBuilding.Pos.X, (ctxBuilding.Pos.Y + ctxBuilding.Shape.Size.Y));
            _totalMenu = new RectangleShape(_menuSize)
            {
                Position = _menuPos,
                FillColor = color
            };
        }

        public void Dispose()
        {
            _totalMenu.Dispose();
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            target.Draw(_totalMenu, states);
        }
    }
}

