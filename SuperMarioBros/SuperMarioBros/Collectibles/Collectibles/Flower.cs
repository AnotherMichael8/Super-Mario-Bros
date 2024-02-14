﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Flower : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        public Flower(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateFlowerSprite();
            verticalMovementFactor = 8;
        }
        public override void SpawnCollectible(Vector2 orginalPosition)
        {
            if (trueYPosition <= orginalPosition.Y - SpawnDist * Globals.ScreenSizeMulti)
            {
                trueYPosition = orginalPosition.Y - Globals.BlockSize;
                spawnCollectible = false;
            }
            else
                trueYPosition += verticalMovementFactor / 16;
        }
    }
}
