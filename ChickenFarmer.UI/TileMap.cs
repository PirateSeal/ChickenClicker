using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using ChickenFarmer.Model;
using TiledSharp;


namespace ChickenFarmer.UI
{
    public class TileMap : IDrawable
    {
        private static readonly Vector2f[] Direction = {

            new Vector2f( 0 + 0.0075f, 0 + 0.0075f),         // 0.0075f  fix texture bleeding
            new Vector2f( 16 + 0.0075f, 0 + 0.0075f),
            new Vector2f( 16 + 0.0075f , 16 + 0.0075f),
            new Vector2f( 0 + 0.0075f , 16 + 0.0075f)
        };

        private TmxMap _map;
        public VertexArray[] UnderMap{ get; }

        public VertexArray[] OverMap { get; }

        public int Season { get; set; }

       const int UnderLayer = 2;                        // define how many layers of the tmx are draw under the player


        private Texture[] _texturesArray;
        public GameLoop GameCtx { get; }

        public bool Disposed { get; private set; }

        public Color Color { get; } = new Color(255, 255, 255);
        public Color NoColor { get; } = new Color(255, 0, 255, 0);

        public int TileSize { get; }
        public int MapSize { get; }
        public int TileSetSize { get; }
        public VertexArray Collide { get; set; }

        public TileMap( string file, GameLoop gameCtx )
        {
            GameCtx = gameCtx;
            _map = new TmxMap( file );
            UnderMap = new VertexArray[UnderLayer];
            OverMap = new VertexArray[_map.Layers.Count-UnderLayer];

            MapSize = _map.Height;
            TileSize = _map.TileHeight;
            Console.WriteLine( file );
            LoadTexture();
            int? imageWidth = _map.Tilesets[0].Image.Width; //check for null expression
            if ( imageWidth != null ) TileSetSize = ( int ) imageWidth;

            Collide = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));

            ConvertLayers();
            Season = 0;

             
        }

  
  

        private void LoadTexture()
        {
          

     
            List<Texture> textureList = new List<Texture>();

            _texturesArray = new Texture[4];
             
            _texturesArray.SetValue(new Texture(_map.Tilesets[0].Image.Source), 0);


            if (_map.Tilesets[0].Image.Source == "..\\..\\..\\..\\Data\\map\\../SpriteSheet/mixed/Fall.png")
            {
                _texturesArray[1] = new Texture("..\\..\\..\\..\\Data\\map\\../SpriteSheet/mixed/Summer.png");
                _texturesArray[2] = new Texture("..\\..\\..\\..\\Data\\map\\../SpriteSheet/mixed/Winter.png");
                _texturesArray[3] = new Texture("..\\..\\..\\..\\Data\\map\\../SpriteSheet/mixed/Spring.png");
            }


        }


        public void ChangeSeason()
        {
            if (_map.Tilesets[0].Image.Source == "..\\..\\..\\..\\Data\\map\\../SpriteSheet/mixed/Fall.png")
            {

                if (Season < 3)
                {
                    Season++;
                }
                else
                {
                    Season = 0;
                }
            }

        }


        private void ConvertLayers()
        {

            int layerIdx=0;
            foreach (var layer in _map.Layers)
            {              
                VertexArray vertexArrayUnder = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));
                VertexArray vertexArrayOver = new VertexArray(PrimitiveType.Quads, 4 * (uint)(_map.Width * _map.Height));


                foreach ( TmxLayerTile tile in layer.Tiles )
                {
                    if (tile.Gid != 0)
                    {
                        if (layerIdx < 2)
                        {
                            Vector2i pos = new Vector2i(tile.X * TileSize, tile.Y * TileSize);
                            Add(pos, tile.Gid, vertexArrayUnder, Color);
                            
                        }else if (layerIdx >= 2 && layerIdx < _map.Layers.Count - 1)
                        {
                            Vector2i pos = new Vector2i(tile.X * TileSize, tile.Y * TileSize);
                            Add(pos, tile.Gid, vertexArrayOver, Color);
                        }

                        else
                        {
                            Vector pos = new Vector(tile.X * TileSize, tile.Y * TileSize);

                            ConvertCollide(pos);

                            //  Add(pos, layer.Tiles[index].Gid, _collide, _noColor);
                          

                        }
                    }
                }
                if (layerIdx < 2) UnderMap[layerIdx++] = vertexArrayUnder;
                else OverMap[(-2)+layerIdx++] = vertexArrayOver ;

            }
        
        }



        public void Dispose()
        {
            foreach (var item in UnderMap)
            {
                item?.Dispose();
                Disposed = true;
            }         
            
        }


        public void DrawOver(IRenderTarget target, in RenderStates states)
        {
            if (Disposed) throw new ObjectDisposedException(typeof(Vertex).Name);
            RenderStates state = new RenderStates(_texturesArray[Season]);

            foreach (var item in OverMap)
            {
                item.Draw(target, state);
            }
        }

        public void Draw( IRenderTarget target, in RenderStates states )
        {
            if ( Disposed ) throw new ObjectDisposedException( typeof( Vertex ).Name );
            RenderStates state = new RenderStates(_texturesArray[Season]);

            foreach (var item in UnderMap)
            {
                item.Draw(target, state);
            }
        
            
        }




        public void ConvertCollide(Vector pos)
        {
            GameCtx?.FarmUI.Farm.CollideCollection.AddObject(pos, 16, 16);
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
