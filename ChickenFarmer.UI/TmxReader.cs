using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

using SFML.System;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    class TmxReader
    {

        TmxMap map;

        public TmxReader(string file)
        {

            map = new TmxMap(file);
            var layers = new Dictionary<Vector2i, IntRect>();
            VertexMap[] _VertexMap;
           

            foreach (var item in map.Tilesets)
            {
                Texture texture = new Texture(item.Image.Source);
                Console.WriteLine(item.Image.Source);
            }


            foreach (var layer in map.Layers)
            {

                var tileHeight = map.TileHeight;
                var tileWidth = map.TileWidth;
                

                foreach (var tile in layer.Tiles)
                {
                    var tiled = new Vector2i(tile.X*16, tile.Y*16);
                    var VectorSize = new Vector2i(tileHeight,tileWidth);
                    var rect = new IntRect(tiled, VectorSize);


                    Console.WriteLine("gid:{0}  , posX:{1} , posY:{2}", tile.Gid, tile.X*16,tile.Y*16);

                }
               

            }
          

        }
        private void Map()
        {
            Dictionary<int, KeyValuePair<IntRect, Texture>> gidDict = ConvertGidDict(map.Tilesets);

        }



        private Dictionary<int, KeyValuePair<IntRect, Texture>> ConvertGidDict(IEnumerable<TmxTileset> tilesets)
        {
            var gidDict = new Dictionary<int, KeyValuePair<IntRect, Texture>>();

            foreach (var ts in tilesets)
            {
                var sheet = new Texture(ts.Image.Source);

                // Loop hoisting
                var wStart = ts.Margin;
                var wInc = ts.TileWidth + ts.Spacing;
                var wEnd = ts.Image.Width;

                var hStart = ts.Margin;
                var hInc = ts.TileHeight + ts.Spacing;
                var hEnd = ts.Image.Height;

                // Pre-compute tileset rectangles
                var id = ts.FirstGid;
                for (var h = hStart; h < hEnd; h += hInc)
                {
                    for (var w = wStart; w < wEnd; w += wInc)
                    {
                        var rect = new IntRect(w, h, ts.TileWidth, ts.TileHeight);
                        gidDict.Add(id, new KeyValuePair<IntRect, Texture>(rect, sheet));
                        id += 1;
                    }
                }
            }

            return gidDict;
        }

    }
}
