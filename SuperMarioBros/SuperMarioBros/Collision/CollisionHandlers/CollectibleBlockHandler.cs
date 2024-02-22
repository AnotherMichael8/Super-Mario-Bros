﻿using SuperMarioBros.Blocks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collision.SideCollisionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter;

namespace SuperMarioBros.Collision.CollisionHandlers
{
    internal class CollectibleBlockHandler
    {
        private static bool IsFalling;
        public static void HandleCollectibleBlockCollision(ICollectibles collectible, IBlock block, ICollision side)
        {
            if(side is TopCollision)
            {
                collectible.SetPosition(collectible.GetPosition().X, (int)(block.Position.Y - Globals.BlockSize));
                IsFalling = false;
            }
        }
        public static void SetFalling()
        {
            IsFalling = true;
        }
        public static void SendFallingData(ICollectibles collectible)
        {
            collectible.IsFalling = IsFalling;
        }
    }
}