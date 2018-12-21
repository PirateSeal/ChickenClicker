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


            MapPath = new Dictionary<int, string[]>()
            {
                {
                    (int)MapTypes.world,
                    new string[] { "../../../../Data/map/3Layers.tmx" }
                },
                {
                    (int)MapTypes.InnerHenhouse,
                    new string[] {
                        "../../../../Data/map/insideHenhouse.tmx",
                        "../../../../Data/map/insideHenhouse.tmx",
                        "../../../../Data/map/insideHenhouse.tmx"
                    }
                },
                {
                    (int)MapTypes.InnerMarket,
                    new string[] {
                        "../../../../Data/map/henhouse1.tmx",
                        "../../../../Data/map/henhouse2.tmx",
                        "../../../../Data/map/henhouse3.tmx"
                    }
                },
                {
                    (int)MapTypes.InnerBuilder,
                    new string[] {
                        "../../../../Data/map/henhouse1.tmx",
                        "../../../../Data/map/henhouse2.tmx",
                        "../../../../Data/map/henhouse3.tmx"
                    }
                },
            };

        }

        public Dictionary<int, string[]> MapPath { get; }

        public Texture[] HenhouseTexture { get; set; }

        public Texture[] StorageTexture { get; set; }
        

    }



}
