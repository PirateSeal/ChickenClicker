using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;
using SFML.System;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    internal class TmxReader
    {
        TmxMap _map;

        public TmxReader( string file )
        {
            _map = new TmxMap( file );
            Dictionary<Vector2i, IntRect> layers = new Dictionary<Vector2i, IntRect>();
            VertexMap[] vertexMap;

            foreach ( TmxTileset item in _map.Tilesets )
            {
                Texture texture = new Texture( item.Image.Source );
                Console.WriteLine( item.Image.Source );
            }

            foreach ( TmxLayer layer in _map.Layers )
            {
                int tileHeight = _map.TileHeight;
                int tileWidth = _map.TileWidth;

                foreach ( TmxLayerTile tile in layer.Tiles )
                {
                    Vector2i tiled = new Vector2i( tile.X * 16, tile.Y * 16 );
                    Vector2i vectorSize = new Vector2i( tileHeight, tileWidth );
                    IntRect rect = new IntRect( tiled, vectorSize );

                    Console.WriteLine( "gid:{0}  , posX:{1} , posY:{2}", tile.Gid, tile.X * 16,
                        tile.Y * 16 );
                }
            }
        }

        private void Map()
        {
            Dictionary<int, KeyValuePair<IntRect, Texture>> gidDict =
                ConvertGidDict( _map.Tilesets );
        }

        private Dictionary<int, KeyValuePair<IntRect, Texture>> ConvertGidDict(
            IEnumerable<TmxTileset> tilesets )
        {
            Dictionary<int, KeyValuePair<IntRect, Texture>> gidDict =
                new Dictionary<int, KeyValuePair<IntRect, Texture>>();

            foreach ( TmxTileset ts in tilesets )
            {
                Texture sheet = new Texture( ts.Image.Source );

                // Loop hoisting
                int wStart = ts.Margin;
                int wInc = ts.TileWidth + ts.Spacing;
                int? wEnd = ts.Image.Width;

                int hStart = ts.Margin;
                int hInc = ts.TileHeight + ts.Spacing;
                int? hEnd = ts.Image.Height;

                // Pre-compute tileset rectangles
                int id = ts.FirstGid;
                for (int h = hStart; h < hEnd; h += hInc)
                {
                    for (int w = wStart; w < wEnd; w += wInc)
                    {
                        IntRect rect = new IntRect( w, h, ts.TileWidth, ts.TileHeight );
                        gidDict.Add( id, new KeyValuePair<IntRect, Texture>( rect, sheet ) );
                        id += 1;
                    }
                }
            }

            return gidDict;
        }
    }
}
