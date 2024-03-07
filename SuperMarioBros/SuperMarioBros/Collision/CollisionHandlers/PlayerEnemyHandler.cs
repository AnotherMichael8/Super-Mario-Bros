using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Enemies;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Enemies.Koopa;
using System.Numerics;

namespace SuperMarioBros.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandlePlayerEnemyCollision(IPlayer player, IEnemy enemy, ICollision side)
        {
            if (!enemy.IsDead)
            {
                if (side is TopCollision)
                {
                    enemy.Kill();
                    player.OnGround = true;
                    player.Hop();
                }
                else
                {
                    player.Kill();
                }
            }
        }
        public static void HandlePlayerKoopaCollision(IPlayer player, Koopa koopa, ICollision side)
        {
            if (side is TopCollision && !koopa.InShell)
            {
                koopa.Kill();
                player.OnGround = true;
                player.Hop();
            }
            else if (side is LeftCollision)
            {
                if(koopa.InShell)
                {
                    koopa.MoveRight();
                }
                else
                {
                    player.Kill();
                }
            }
            else if (side is RightCollision)
            {
                if (koopa.InShell)
                {
                    koopa.MoveLeft();
                }
                else
                {
                    player.Kill();
                }
            }
        }
    }
}
