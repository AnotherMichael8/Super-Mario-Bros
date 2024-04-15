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
        private static bool IsFalling;
        public static void HandleEnemyBlockCollision(IEnemy enemy, IBlock block, ICollision side)
        {
            Rectangle blockHitBox = block.GetHitBox();
           //Rectangle enemyHitBox = enemy.GetBlockHitBox();
            if (side is TopCollision)
            {
                enemy.Position = new Vector2(enemy.Position.X, blockHitBox.Y - enemy.GetHeight());
                IsFalling = false;
                if (block.Bumped)
                    enemy.Kill();
                /*
                if (block is GroundBlock && enemyHitBox.Right >= blockHitBox.Right)
                {
                    enemy.MoveLeft();
                }
                else if (block is GroundBlock && enemyHitBox.Left <= blockHitBox.Left)
                {
                    enemy.MoveRight();
                }
                */
            }
            else if (side is LeftCollision)
            {
                enemy.MoveLeft();
            }
            else if(side is RightCollision)
            {
                enemy.MoveRight();
            }

        }
        public static void SetFalling()
        {
            IsFalling = true;
        }
        public static void SendFallingData(IEnemy enemy)
        {
            enemy.IsFalling = IsFalling;
        }
    }
}
