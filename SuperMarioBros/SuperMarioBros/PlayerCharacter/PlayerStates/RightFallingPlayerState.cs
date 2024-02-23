using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        public RightFallingPlayerState(Player player, int jumpingSpeed = 16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 8;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            player.State = new LeftMoveFallingPlayerState(player, JumpingSpeed);
        }

        public override void MoveRight()
        {
            player.State = new RightMoveFallingPlayerState(player, JumpingSpeed);
        }
        public override void PowerUpMushroom()
        {
            base.PowerUpMushroom();
            player.State = new RightMushroomPowerUpAnimationState(player, this);
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (player.OnGround)
            {
                player.State = new RightIdlePlayerState(player);
            }
        }
    }
}