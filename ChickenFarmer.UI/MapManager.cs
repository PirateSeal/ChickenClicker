namespace ChickenFarmer.UI
{
    public class MapManager
    {
        public MapManager(GameLoop ctxGame)
        {
            CtxGame = ctxGame;

            CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) MapTypes.World, out string[] value);
            CurrentMap = new TileMap(value?[0], CtxGame);
        }

        internal TileMap CurrentMap { get; set; }
        public GameLoop CtxGame { get; }

        public void LoadMap(MapTypes type, int lvl = 0)
        {
            CtxGame.FarmUI.Farm.CollideCollection.Clear();

            if ( type == MapTypes.InnerHenhouse )
            {
                CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) MapTypes.InnerHenhouse, out string[] file);
                CurrentMap = new TileMap(file?[0], CtxGame);
            }
            else
            {
                CtxGame.FarmUI.FarmOptionsUI.MapPath.TryGetValue(( int ) MapTypes.World, out string[] file);
                CurrentMap = new TileMap(file?[0], CtxGame);
            }
        }
    }
}