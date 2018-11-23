using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;
using SFML.Graphics;
using SFML.System;
using System.Diagnostics;


namespace ChickenFarmer.UI
{
    internal class MapTest : IDrawable
    {
        private static readonly Vector2f[] Direction = {
            new Vector2f( 0, 0 ),
            new Vector2f( 16, 0 ),
            new Vector2f( 16, 16 ),
            new Vector2f( 0, 16 )
        };

        private TmxMap _map;
        public VertexArray[] _TotalMap{ get; }

        Stopwatch sw = new Stopwatch();

       
        private Texture[] _texturesArray;
        private GameLoop _gameCtx;

        private bool _disposed;

        //  Color color = new Color(255, 255, );
        public int TileSize { get; }
        public int MapSize { get; }
        public int TileSetSize { get; }

        public MapTest( string file, GameLoop gameCtx )
        {
            _gameCtx = gameCtx;
            _map = new TmxMap( file );
            _TotalMap = new VertexArray[_map.Layers.Count];
           
            MapSize = _map.Height;
            TileSize = _map.TileHeight;
            Console.WriteLine( file );
            LoadTexture();
            int? imageWidth = _map.Tilesets[0].Image.Width; //check for null expression
            if ( imageWidth != null ) TileSetSize = ( int ) imageWidth;
            ConvertLayers();


        }

        private void LoadTexture()
        {
            _texturesArray = new Texture[_map.Tilesets.Count];
            for (int i = 0; i < _map.Tilesets.Count; i ++)
            {
                _texturesArray[i] = new Texture( _map.Tilesets[i].Image.Source );
            }
        }

        private void ConvertLayers()
        {

            int idx=0;
            foreach (var layer in _map.Layers)
            {              
                VertexArray _vertexArray = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));
                for (int index = 0; index < layer.Tiles.Count; index++)
                {
                   
                    if (layer.Tiles[index].Gid != 0)
                    {
                        Vector2i pos = new Vector2i(layer.Tiles[index].X * TileSize, layer.Tiles[index].Y * TileSize);                     
                        Add(pos, layer.Tiles[index].Gid,_vertexArray);
                    }
                    
                }
                _TotalMap[idx++] = _vertexArray;
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        public void Dispose()
        {
            foreach (var item in _TotalMap)
            {
                item?.Dispose();
                _disposed = true;
            }         
            
        }


        public void Draw( IRenderTarget target, in RenderStates states )
        {
            if ( _disposed ) throw new ObjectDisposedException( typeof( Vertex ).Name );
            RenderStates state = new RenderStates(_texturesArray[0]);

            foreach (var item in _TotalMap)
            {
                item.Draw(target, state);
            }
        
            
        }
        

        private void Add( Vector2i vertexPos, int gid,VertexArray vertexArray )
        {
            
            int tu = gid % (TileSetSize / TileSize) - 1;
            int tv = gid / (TileSetSize / TileSize);
            if ( tu < 0 )
            {
                tu = TileSetSize / TileSize - 1;
                tv --;
            }

            vertexArray.Append( new Vertex( Direction[0] + ( Vector2f ) vertexPos,
                new Vector2f( tu * TileSize, tv * TileSize ) ) );

            vertexArray.Append( new Vertex( Direction[1] + ( Vector2f ) vertexPos,
                new Vector2f( (tu + 1) * TileSize, tv * TileSize ) ) );

            vertexArray.Append( new Vertex( Direction[2] + ( Vector2f ) vertexPos,
                new Vector2f( (tu + 1) * TileSize, (tv + 1) * TileSize ) ) );

            vertexArray.Append( new Vertex( Direction[3] + ( Vector2f ) vertexPos,
                new Vector2f( tu * TileSize, (tv + 1) * TileSize ) ) );
        }
    }
}
