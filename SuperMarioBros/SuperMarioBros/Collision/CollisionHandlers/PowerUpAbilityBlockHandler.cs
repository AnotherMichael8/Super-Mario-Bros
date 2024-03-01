using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PowerUpAbilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision.CollisionHandlers
{
    public class PowerUpAbilityBlockHandler
    {
        public static void HandlePowerUpAbilityBlockCollision(IPowerUpAbility ability, IBlock block, ICollision side)
        {
            if (ability is Fireball fireball)
            {
                if (side is TopCollision)
                {
                    fireball.Bounce();
                }
                else
                {
                    fireball.Explode();
                }
            }
        }
    }
}
