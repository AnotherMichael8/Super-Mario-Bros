using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    internal class LeftMoveFallingPlayerState : AbstractPlayerState, ILeftFacing
    {
        private int fallingSpeed;
        public LeftMoveFallingPlayerState(Player player, double jumpingSpeed = -16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 8;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            if (Speed > -2 * 16 * Globals.ScreenSizeMulti)
            {
                Speed -= (int)(10 * Globals.ScreenSizeMulti);
            }
        }
        public override void PowerUpMushroom()
        {
            base.PowerUpMushroom();
            player.State = new LeftMushroomPowerUpAnimationState(player, this);
        }
        public override void MoveRight()
        {
            player.State = new RightMoveFallingPlayerState(player, JumpingSpeed);
        }
        public override void PowerUpFlower()
        {
            base.PowerUpFlower();
            player.State = new LeftFlowerPowerUpAnimationState(player, this);
        }
        public override void Hop()
        {
            player.State = new LeftMoveJumpingPlayerState(player, 40);
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (Speed == 0)
            {
                player.State = new LeftFallingPlayerState(player, JumpingSpeed);
            }
            if (player.OnGround)
            {
                player.State = new LeftMovingPlayerState(player, Speed);
            }
        }
    }
}