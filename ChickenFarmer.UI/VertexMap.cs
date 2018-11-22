using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace ChickenFarmer.UI
{
    class VertexMap : IDrawable, IDisposable
    {
        private VertexArray VertexArray1 { get; }
        private Texture Texture1 { get; }
        private bool _disposed;

        private static readonly Vector2f[] Direction =
        {
            new Vector2f( 0, 0 ), new Vector2f( 1, 0 ), new Vector2f( 1, 1 ),
            new Vector2f( 0, 1 )
        };

        public VertexMap( Dictionary<Vector2i, IntRect> tiles, Texture texture )
        {
            VertexArray1 = new VertexArray( PrimitiveType.Quads, 4 * ( uint ) tiles.Count );
            Texture1 = texture;
            foreach ( KeyValuePair<Vector2i, IntRect> tile in tiles )
            {
                Add( tile.Value, tile.Key );
            }
        }

        public void ReadTmx( string filename )
        {
            TmxMap map = new TmxMap( filename );
            int count = map.Layers.Count;
        }

        public void Dispose()
        {
            VertexArray1?.Dispose();
            _disposed = true;
        }

        public void Draw( IRenderTarget target, in RenderStates states )
        {
            if ( _disposed ) throw new ObjectDisposedException( typeof( VertexMap ).Name );
            RenderStates texture = new RenderStates( states.BlendMode, states.Transform, Texture1,
                states.Shader );

            target.Draw( VertexArray1, texture ); //TODO ASK SPI
        }

        private Vector2i[] GetPositions( IntRect intRect )
        {
            Vector2i pos1 = new Vector2i( intRect.Left, intRect.Top );
            Vector2i pos2 = new Vector2i( intRect.Left + intRect.Width, intRect.Top );
            Vector2i pos3 = new Vector2i( intRect.Left + intRect.Width,
                intRect.Top + intRect.Height );
            Vector2i pos4 = new Vector2i( intRect.Left, intRect.Top + intRect.Height );
            return new Vector2i[] { pos1, pos2, pos3, pos4 };
        }

        private void Add( IntRect texturePos, Vector2i vertexPos )
        {
            Vector2i[] positions = GetPositions( texturePos );
            VertexArray1.Append( new Vertex( Direction[0] + ( Vector2f ) vertexPos,
                ( Vector2f ) positions[0] + new Vector2f( 0.0075f, 0.0075f ) ) );
            VertexArray1.Append( new Vertex( Direction[1] + ( Vector2f ) vertexPos,
                ( Vector2f ) positions[1] + new Vector2f( -0.0075f, 0.0075f ) ) );
            VertexArray1.Append( new Vertex( Direction[2] + ( Vector2f ) vertexPos,
                ( Vector2f ) positions[2] + new Vector2f( -0.0075f, -0.0075f ) ) );
            VertexArray1.Append( new Vertex( Direction[3] + ( Vector2f ) vertexPos,
                ( Vector2f ) positions[3] + new Vector2f( 0.0075f, -0.0075f ) ) );
        }
    }
}