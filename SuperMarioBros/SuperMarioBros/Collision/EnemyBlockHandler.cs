using SuperMarioBros.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Collision
{
    public class EnemyBlockHandler
    {
        public static void HandleEnemyBlockCollision(IEnemy enemy, IBlock block, ICollision side)
        {
            Rectangle blockHitBox = block.GetHitBox();
            if (side is TopCollision)
            {
                enemy.Position = new Vector2(enemy.Position.X, blockHitBox.Y - 32);
            }
        }
    }
}
