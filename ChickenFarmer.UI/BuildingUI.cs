using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    class BuildingUI : IDrawable , IDisposable
    {
        RectangleShape _shape;
        Vector2f _pos;
        Texture texture;
        ContextualMenu _menu;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            target.Draw(this);
        }
    }
}
