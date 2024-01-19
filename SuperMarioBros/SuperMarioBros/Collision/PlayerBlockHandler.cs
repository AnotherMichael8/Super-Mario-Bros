using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision
{
    public class PlayerBlockHandler
    {
        public static void HandlePlayerBlockCollision(IPlayer player, IBlock block, ICollision side)
        {
            Rectangle blockHitBox = block.GetHitBox();
            if(side is TopCollision)
            {
                player.Position = new Vector2(player.Position.X, blockHitBox.Y - 32);
                player.OnGround = true;
            }
        }
    }
}
