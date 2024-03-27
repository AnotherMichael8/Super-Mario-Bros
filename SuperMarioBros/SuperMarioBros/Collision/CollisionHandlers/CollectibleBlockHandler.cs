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
using SuperMarioBros.Collectibles.Collectibles;

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
            else if (side is BottomCollision)
            {
                collectible.StopUpwardMovement();
            }
        }
        public static void SetFalling()
        {
            IsFalling = true;
        }
        public static void SendFallingData(ICollectibles collectible)
        {
            if(collectible is not WonderFlower)
                collectible.IsFalling = IsFalling;
        }
    }
}
