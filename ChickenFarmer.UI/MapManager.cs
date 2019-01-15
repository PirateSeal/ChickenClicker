using SFML.System;

namespace ChickenFarmer.UI
{
    public class MapManager
    {
        public MapManager(GameLoop ctxGame)
        {
            CtxGame = ctxGame;

            CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) MapTypes.World, out string[] value);
            CurrentMap = new TileMap(value?[0], CtxGame);
            CurrentType = MapTypes.World;
        }

        internal TileMap CurrentMap { get; set; }
        public MapTypes CurrentType { get; private set; }
        public GameLoop CtxGame { get; }

        public void LoadMap(MapTypes type, int lvl = 0)
        {
            CtxGame.FarmUI.Farm.CollideCollection.Clear();

            if ( type != MapTypes.World )
            {
                CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) type, out string[] file);
                CurrentMap = new TileMap(file?[0], CtxGame);
                
         

                if(type == MapTypes.InnerHenhouse)
                {
                    Model.FarmOptions.SpawnPos.TryGetValue(typeof(Model.Henhouse), out var value1);
                    CtxGame.FarmUI.Farm.Player.Position = value1;
                }
                if (type == MapTypes.InnerBuilder)
                {
                    Model.FarmOptions.SpawnPos.TryGetValue(typeof(Model.Builder), out var value1);
                    CtxGame.FarmUI.Farm.Player.Position = value1;
                }


            }
            else
            {
                CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) MapTypes.World, out string[] file);
                CurrentMap = new TileMap(file?[0], CtxGame);
                CtxGame.FarmUI.Farm.Player.Position = new Model.Vector(CtxGame.FarmUI.PlayerUI.OldPos.X, CtxGame.FarmUI.PlayerUI.OldPos.Y);

            }
            CurrentType = type;
        }
    }
}