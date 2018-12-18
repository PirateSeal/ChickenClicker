using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    public class FarmOptionsUI
    {
        public FarmUI CtxFarmUI { get; }

        public FarmOptionsUI(FarmUI ctxFarm)
        {

            CtxFarmUI = ctxFarm;

            TextureTable = new[]
            {
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse2.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" )             
            };

            TextureTableStorage = new[]
           {
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse2.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" )

            };



            MapPath1 = new Dictionary<Type, string[]>()
            {
                { typeof(TileMap), new string[] { "../../../../Data/map/3Layers.tmx" } }, 
                { typeof(Model.Henhouse), new string[] { "../../../../Data/map/henhouse1.tmx", "../../../../Data/map/henhouse2.tmx", "../../../../Data/map/henhouse3.tmx" } }
            };



        }


        public Dictionary<Type, string[]> MapPath1 { get; }

        public Texture[] TextureTable { get; set; }

        public Texture[] TextureTableStorage { get; set; }
        

    }



}
