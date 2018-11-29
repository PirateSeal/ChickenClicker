using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;
using SFML.Graphics;
using SFML.System;



namespace ChickenFarmer.UI
{
    // CECI EST UN EXEMPLE
    internal class TileMap : IDrawable
    {
        private static readonly Vector2f[] Direction = {

            new Vector2f( 0 + 0.0075f, 0 + 0.0075f),         // 0.0075f  fix texture bleeding
            new Vector2f( 16 + 0.0075f, 0 + 0.0075f),
            new Vector2f( 16 + 0.0075f , 16 + 0.0075f),
            new Vector2f( 0 + 0.0075f , 16 + 0.0075f)
        };

        private TmxMap _map;
        public VertexArray[] UnderMap{ get; }
        private VertexArray _collide;

        public VertexArray[] OverMap { get; }



        private Texture[] _texturesArray;
        private GameLoop _gameCtx;

        private bool _disposed;


        Color _color = new Color(255, 255, 255,255);
        Color _noColor = new Color(255,0,255,0);

        public int TileSize { get; }
        public int MapSize { get; }
        public int TileSetSize { get; }
        public VertexArray Collide { get => _collide; set => _collide = value; }

        public TileMap( string file, GameLoop gameCtx )
        {
            _gameCtx = gameCtx;
            _map = new TmxMap( file );
            UnderMap = new VertexArray[2];
            OverMap = new VertexArray[_map.Layers.Count-2];

            MapSize = _map.Height;
            TileSize = _map.TileHeight;
            Console.WriteLine( file );
            LoadTexture();
            int? imageWidth = _map.Tilesets[0].Image.Width; //check for null expression
            if ( imageWidth != null ) TileSetSize = ( int ) imageWidth;

            _collide = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));

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

            int layerIdx=0;
            foreach (var layer in _map.Layers)
            {              
                VertexArray _vertexArrayUnder = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));
                VertexArray _vertexArrayOver = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));


                for (int index = 0; index < layer.Tiles.Count; index++)
                {
                   
                    if (layer.Tiles[index].Gid != 0)
                    {
                        if (layerIdx < 2)
                        {
                            Vector2i pos = new Vector2i(layer.Tiles[index].X * TileSize, layer.Tiles[index].Y * TileSize);
                            Add(pos, layer.Tiles[index].Gid, _vertexArrayUnder, _color);
                            
                        }else if (layerIdx >= 2 && layerIdx < _map.Layers.Count - 1)
                        {
                            Vector2i pos = new Vector2i(layer.Tiles[index].X * TileSize, layer.Tiles[index].Y * TileSize);
                            Add(pos, layer.Tiles[index].Gid, _vertexArrayOver, _color);
                        }

                        else
                        {
                            Vector2i pos = new Vector2i(layer.Tiles[index].X * TileSize, layer.Tiles[index].Y * TileSize);
                            Add(pos, layer.Tiles[index].Gid, _collide, _noColor);
                          

                        }
                    }
                    

                }
                if (layerIdx < 2) UnderMap[layerIdx++] = _vertexArrayUnder;
                else OverMap[(-2)+layerIdx++] = _vertexArrayOver ;

            }
        
        }




        public void Dispose()
        {
            foreach (var item in UnderMap)
            {
                item?.Dispose();
                _disposed = true;
            }         
            
        }


        public void DrawOver(IRenderTarget target, in RenderStates states)
        {
            if (_disposed) throw new ObjectDisposedException(typeof(Vertex).Name);
            RenderStates state = new RenderStates(_texturesArray[0]);

            foreach (var item in OverMap)
            {
                item.Draw(target, state);
            }
        }

        public void Draw( IRenderTarget target, in RenderStates states )
        {
            if ( _disposed ) throw new ObjectDisposedException( typeof( Vertex ).Name );
            RenderStates state = new RenderStates(_texturesArray[0]);

            foreach (var item in UnderMap)
            {
                item.Draw(target, state);
            }
        
            
        }
        

        private void Add( Vector2i vertexPos, int gid,VertexArray vertexArray, Color color)
        {
            
            int tu = gid % (TileSetSize / TileSize) - 1;
            int tv = gid / (TileSetSize / TileSize);
            if ( tu < 0 )
            {
                tu = TileSetSize / TileSize - 1;
                tv --;
            }

            vertexArray.Append( 
                new Vertex( Direction[0] + ( Vector2f ) vertexPos, 
                color,
                new Vector2f( tu * TileSize, tv * TileSize ) ) );

            vertexArray.Append( 
                new Vertex( Direction[1] + ( Vector2f ) vertexPos, 
                color,
                new Vector2f( (tu + 1) * TileSize, tv * TileSize ) ) );

            vertexArray.Append(
                new Vertex( Direction[2] + ( Vector2f ) vertexPos, 
                color,
                new Vector2f( (tu + 1) * TileSize, (tv + 1) * TileSize ) ) );

            vertexArray.Append( 
                new Vertex( Direction[3] + ( Vector2f ) vertexPos,
                color,
                new Vector2f( tu * TileSize, (tv + 1) * TileSize ) ) );
        }
    }
}
