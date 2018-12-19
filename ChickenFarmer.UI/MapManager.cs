using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmer.UI
{
    public class MapManager
    {
        TileMap _currentMap;
        GameLoop _ctxGame;

        public MapManager(GameLoop ctxGame)
        {

            _ctxGame = ctxGame;

            _ctxGame.FarmUI.FarmOptionsUI.MapPath1.TryGetValue(typeof(TileMap), out var value);
            _currentMap = new TileMap(value[0], _ctxGame);
        }

        internal TileMap CurrentMap { get => _currentMap; set => _currentMap = value; }

        public void LoadMap(string file)
        {
            _ctxGame.FarmUI.Farm.CollideCollection.Clear();

            _currentMap = new TileMap(file, _ctxGame);

            
        }

    }
}
