﻿using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace ChickenFarmer.UI
{
    public class FarmOptionsUI
    {
        public FarmUI CtxFarmUI { get; }
        public Vector2f[] spawnPos { get; private set; }

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

            BuilderTexture = new Texture("../../../../Data/SpriteSheet/buildings/Builder.png");


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

            MapTextures = new Dictionary<MapTypes, Texture[]>
            {

                {
                    MapTypes.World,
                    new Texture []
                    {
                        new Texture("../../../../Data/SpriteSheet/mixed/Fall.png"),
                        new Texture("../../../../Data/SpriteSheet/mixed/Summer.png"),
                        new Texture("../../../../Data/SpriteSheet/mixed/Winter.png"),
                        new Texture("../../../../Data/SpriteSheet/mixed/Spring.png"),
                    }
                },
                {
                    MapTypes.InnerHenhouse,
                    new Texture []
                    {
                        new Texture("../../../../Data/SpriteSheet/Interior/Interior2.png"),
                    }
                },



            };


        }

        public Dictionary<int, string[]> MapPath { get; }
        public Dictionary<MapTypes, Texture[]> MapTextures { get; private set; }
        public Texture[] HenhouseTexture { get; set; }

        public Texture[] StorageTexture { get; set; }
        public Texture BuilderTexture { get; internal set; }
    }



}
