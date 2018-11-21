using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;
using SFML.Graphics;
using SFML.System;

namespace ChickenFarmer.UI
{
    class mapTest : IDrawable 
    {
        static readonly Vector2f[] Direction = { new Vector2f(0, 0), new Vector2f(16, 0), new Vector2f(16, 16), new Vector2f(0, 16) };

        TmxMap _map;
        VertexArray _vertexMap;
        VertexArray _vertexArray;

        Texture[] _texturesArray;
        GameLoop _gameCtx;
        private bool _disposed;
      //  Color color = new Color(255, 255, );
        int _tileSize;
        int _mapSize;
        int _tileSetSize;

        public mapTest(string file, GameLoop gameCtx)
        {
            _gameCtx = gameCtx;
            _map = new TmxMap(file);
            _vertexArray = new VertexArray(PrimitiveType.Quads, 4 *(uint)(_map.Width*_map.Height));
            _mapSize = _map.Height;
            _tileSize = _map.TileHeight;
            Console.WriteLine(file);   
            LoadTexture();
            _tileSetSize = (int)_map.Tilesets[0].Image.Width;
          
            ConvertLayer(_map.Layers[0]);
            Console.WriteLine();
         

        }

        public void LoadTexture()
        {
            _texturesArray = new Texture[_map.Tilesets.Count];
            for (int i = 0; i < _map.Tilesets.Count; i++)
            {
                _texturesArray[i] = new Texture(_map.Tilesets[i].Image.Source);

            }        

        }

        public void ConvertLayer(TmxLayer layer)
        {
            
         
                
                for (int index = 0; index < layer.Tiles.Count; index++)
                {

                        Console.WriteLine("i   {0}",index);

                    var gid = layer.Tiles[index].Gid;
                    if (gid != 0)
                    {

                        var pos = new Vector2i(layer.Tiles[index].X * 16, layer.Tiles[index].Y * 16);
                        Console.WriteLine("x:{0} , y:{1} gid:{2}  ", pos.X, pos.Y, gid);
                        Add(pos, gid);
                    }

                    


                }

        }


        public void Dispose()
        {
            _vertexArray?.Dispose();
            _disposed = true;
        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            
            if (_disposed) throw new ObjectDisposedException(typeof(VertexMap).Name);
            var state = new RenderStates(_texturesArray[0]);
           
            target.Draw(_vertexArray,state);
        }



        void Add( Vector2i vertexPos,int gid)
        {
            

            int tu = gid % (_tileSetSize / _tileSize)-1;
            int tv = gid / (_tileSetSize / _tileSize);
            if (tu < 0)
            {
                tu = _tileSetSize / _tileSize - 1;
                tv--;

            }


            _vertexArray.Append(
                new Vertex(Direction[0] + (Vector2f)vertexPos, new Vector2f(tu * _tileSize, tv * _tileSize))
                );

            _vertexArray.Append(
                new Vertex(Direction[1] + (Vector2f)vertexPos ,  new Vector2f((tu+1) * _tileSize, tv * _tileSize))
                );

            _vertexArray.Append(
                new Vertex(Direction[2] + (Vector2f)vertexPos ,  new Vector2f((tu+1) * _tileSize, (tv+1) * _tileSize))
                );

            _vertexArray.Append(
               new Vertex(Direction[3] + (Vector2f)vertexPos ,  new Vector2f(tu * _tileSize, (tv+1) * _tileSize))
               );
        }
    }
}
