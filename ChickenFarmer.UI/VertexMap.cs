using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace ChickenFarmer.UI
{
    class VertexMap : IDrawable, IDisposable
    {
        VertexArray _vertexArray;
        Texture _texture;
        bool _disposed;
        static readonly Vector2f[] Direction = { new Vector2f(0, 0), new Vector2f(1, 0), new Vector2f(1, 1), new Vector2f(0, 1) };


        public VertexMap(Dictionary<Vector2i, IntRect> tiles, Texture texture)
        {
            _vertexArray = new VertexArray(PrimitiveType.Quads, 4 * (uint)tiles.Count);
            _texture = texture;
            foreach (KeyValuePair<Vector2i, IntRect> tile in tiles)
            {
                Add(tile.Value, tile.Key);
            }
        }

        

        public void readTmx(string filename)
        {
            TmxMap map = new TmxMap(filename);
            var count = map.Layers.Count;

        }

        


        public void Dispose()
        {
            _vertexArray?.Dispose();
            _disposed = true;
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            if (_disposed) throw new ObjectDisposedException(typeof(VertexMap).Name);
            RenderStates texture = new RenderStates(states.BlendMode, states.Transform, _texture, states.Shader);
            
            target.Draw(_vertexArray, texture);//TODO ASK SPI
        }

        Vector2i[] GetPositions(IntRect intRect)
        {
            Vector2i pos1 = new Vector2i(intRect.Left, intRect.Top);
            Vector2i pos2 = new Vector2i(intRect.Left + intRect.Width, intRect.Top);
            Vector2i pos3 = new Vector2i(intRect.Left + intRect.Width, intRect.Top + intRect.Height);
            Vector2i pos4 = new Vector2i(intRect.Left, intRect.Top + intRect.Height);
            return new Vector2i[] { pos1, pos2, pos3, pos4 };
        }

        void Add(IntRect texturePos, Vector2i vertexPos)
        {
            Vector2i[] positions = GetPositions(texturePos);
            _vertexArray.Append(
                new Vertex(Direction[0] + (Vector2f)vertexPos,
                (Vector2f)positions[0] + new Vector2f(0.0075f, 0.0075f)));
            _vertexArray.Append(
                new Vertex(Direction[1] + (Vector2f)vertexPos,
                (Vector2f)positions[1] + new Vector2f(-0.0075f, 0.0075f)));
            _vertexArray.Append(
                new Vertex(Direction[2] + (Vector2f)vertexPos,
                (Vector2f)positions[2] + new Vector2f(-0.0075f, -0.0075f)));
            _vertexArray.Append(
                new Vertex(Direction[3] + (Vector2f)vertexPos,
                (Vector2f)positions[3] + new Vector2f(0.0075f, -0.0075f)));
        }
    }
}