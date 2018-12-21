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

            _ctxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue((int)MapTypes.world,out var  value);
            _currentMap = new TileMap(value[0], _ctxGame);
        }

        internal TileMap CurrentMap { get => _currentMap; set => _currentMap = value; }

        public void LoadMap(MapTypes type, int lvl = 0)
        {
            _ctxGame.FarmUI.Farm.CollideCollection.Clear();

            if (type == MapTypes.InnerHenhouse)
            {
                _ctxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue((int)MapTypes.InnerHenhouse, out var file);
                _currentMap = new TileMap(file[0], _ctxGame);

            }
            else
            {
                _ctxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue((int)MapTypes.world, out var file);
                _currentMap = new TileMap(file[0], _ctxGame);
            }

        }

    }
}
