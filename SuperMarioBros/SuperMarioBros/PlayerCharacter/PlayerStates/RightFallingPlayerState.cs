using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightFallingPlayerState : AbstractPlayerState, IRightFacing
    {
        private int fallingSpeed;
        public RightFallingPlayerState(Player player, double jumpingSpeed = 16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            if (WonderTime)
                fallingSpeed = 4;
            else
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
        public override void PowerUpFlower()
        {
            base.PowerUpFlower();
            player.State = new RightFlowerPowerUpAnimationState(player, this);
        }
        public override void Hop()
        {
            player.State = new RightJumpingPlayerState(player, 40);
        }
        public override void UpdateMovement()
        {
            if (JumpingSpeed > -300)
                JumpingSpeed -= fallingSpeed;
            if (player.OnGround)
            {
                player.State = new RightIdlePlayerState(player);
            }
        }
    }
}