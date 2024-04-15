using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision.CollisionHandlers
{
    public class EnemyEnemyHandler
    {
        public static void HandleEnemyEnemyCollision(IEnemy enemy1, IEnemy enemy2, ICollision side)
        {
            if (side is LeftCollision)
            {
                enemy1.MoveLeft();
            }
            else if (side is RightCollision)
            {
                enemy1.MoveRight();
            }
        }
    }
}
