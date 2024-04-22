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
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandlePlayerEnemyCollision(IPlayer player, IEnemy enemy, ICollision side)
        {
            if (!enemy.IsDead && player is not StarMario)
            {
                if (side is TopCollision || (player.IsFalling && player.State is not IJumpingPlayerState))
                {
                    enemy.Kill();
                    player.OnGround = true;
                    player.Hop();
                    SoundFactory.PlaySound(SoundFactory.Instance.stomp);
                }
                else
                {
                    player.Kill();
                }
            }
            else if (player is StarMario)
            {
                enemy.FallingKill();
                if (side is LeftCollision)
                    enemy.MoveRight();
                else if(side is RightCollision)
                    enemy.MoveLeft();

            }
        }
        public static void HandlePlayerKoopaCollision(IPlayer player, Koopa koopa, ICollision side)
        {
            if (player is not StarMario)
            {
                if (side is TopCollision && !koopa.InShell)
                {
                    koopa.Kill();
                    player.OnGround = true;
                    player.Hop();
                }
                else if (side is LeftCollision)
                {
                    if (koopa.InShell)
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
            else
            {
                koopa.Kill();
            }
        }
    }
}
