using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace ChickenFarmer.UI
{
    public class FarmOptionsUI
    {
        FarmUI _ctxFarmUI;

        public FarmOptionsUI(FarmUI ctxFarm)
        {

            _ctxFarmUI = ctxFarm;

            TextureDictionary = new Dictionary<Type, Texture[]>();
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

            MapPath = new[]
            {
                "../../../../Data/map/3Layers.tmx",
                "../../../../Data/map/henhouse.tmx"

            };


        }
        public Dictionary<Type, Texture[]> TextureDictionary { get; }

        public string[] MapPath { get; set; }


        public Texture[] TextureTable { get; set; }

        public Texture[] TextureTableStorage { get; set; }
        

    }



}
