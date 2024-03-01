using SuperMarioBros.Blocks;
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
                collectible.SetPosition(collectible.GetPositionX(), (int)(block.Position.Y - Globals.BlockSize));
                IsFalling = false;
            }
            else if (side is LeftCollision)
            {
                collectible.MoveLeft();
            }
            else if (side is RightCollision)
            {
                collectible.MoveRight();
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
