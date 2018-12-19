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

            HenhouseTexture = new[]
            {
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse2.png" ),
                new Texture( "../../../../Data/henhouse1.png" ),
                new Texture( "../../../../Data/henhouse1.png" )             
            };

            StorageTexture = new[]
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
                { typeof(Model.Henhouse), new string[] { "../../../../Data/map/henhouse1.tmx", "../../../../Data/map/henhouse2.tmx", "../../../../Data/ /henhouse3.tmx" } }
            };



        }


        public Dictionary<Type, string[]> MapPath1 { get; }

        public Texture[] HenhouseTexture { get; set; }

        public Texture[] StorageTexture { get; set; }
        

    }



}
