using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Enemies;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PowerUpAbilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision.CollisionHandlers
{
    public class PowerUpAbilityHandler
    {
        public static void HandlePowerUpAbilityBlockCollision(IPowerUpAbility ability, IBlock block, ICollision side)
        {
            if (ability is Fireball fireball)
            {
                if (side is TopCollision || ((side is LeftCollision || side is RightCollision) && fireball.GetHitBox().Bottom > block.Position.Y - 6 * Globals.ScreenSizeMulti))
                {
                    fireball.Bounce();
                }
                else
                {
                    fireball.Explode();
                }
            }
        }
        public static void HandlePowerUpAbilityEnemyCollision(IPowerUpAbility ability, IEnemy enemy, ICollision side)
        {
            if (ability is Fireball fireball)
            {
                enemy.Kill();
                fireball.Explode();
            }
        }
    }
}
