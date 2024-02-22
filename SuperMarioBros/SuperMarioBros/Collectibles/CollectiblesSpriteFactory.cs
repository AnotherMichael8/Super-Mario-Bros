﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collectibles.CollectiblesSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles
{
    public class CollectiblesSpriteFactory
    {
        private static Texture2D collectiblesTexture;
        private static CollectiblesSpriteFactory instance = new CollectiblesSpriteFactory();
        public static CollectiblesSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private CollectiblesSpriteFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            collectiblesTexture = content.Load<Texture2D>("Powerups");
        }

        public ICollectiblesSprite CreateMushroomSprite()
        {
            return new MushroomSprite(collectiblesTexture);
        }
        public ICollectiblesSprite CreateFlowerSprite()
        {
            return new FlowerSprite(collectiblesTexture);
        }
        public ICollectiblesSprite CreateCoinSprite()
        {
            return new CoinSprite(collectiblesTexture);
        }
    }
}