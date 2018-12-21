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


            MapPath = new Dictionary<int, string[]>
            {
                {
                    (int)MapTypes.World,
                    new[] { "../../../../Data/map/3Layers.tmx" }
                },
                {
                    (int)MapTypes.InnerHenhouse,
                    new[] {
                        "../../../../Data/map/insideHenhouse.tmx",
                        "../../../../Data/map/insideHenhouse.tmx",
                        "../../../../Data/map/insideHenhouse.tmx"
                    }
                },
                {
                    (int)MapTypes.InnerMarket,
                    new[] {
                        "../../../../Data/map/henhouse1.tmx",
                        "../../../../Data/map/henhouse2.tmx",
                        "../../../../Data/map/henhouse3.tmx"
                    }
                },
                {
                    (int)MapTypes.InnerBuilder,
                    new[] {
                        "../../../../Data/map/henhouse1.tmx",
                        "../../../../Data/map/henhouse2.tmx",
                        "../../../../Data/map/henhouse3.tmx"
                    }
                }
            };

        }

        public Dictionary<int, string[]> MapPath { get; }

        public Texture[] HenhouseTexture { get; set; }

        public Texture[] StorageTexture { get; set; }
        

    }



}
