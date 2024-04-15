using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMoveFallingPlayerState : AbstractPlayerState, IRightFacing
    {
        private int fallingSpeed;
        public RightMoveFallingPlayerState(Player player, double jumpingSpeed = 16) : base(player)
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
            if (Speed < 2 * 16 * Globals.ScreenSizeMulti)
            {
                Speed += (int)(10 * Globals.ScreenSizeMulti);
            }
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
            player.State = new RightMoveJumpingPlayerState(player, 40);
        }
        public override void UpdateMovement()
        {
            if(JumpingSpeed > -300)
                JumpingSpeed -= fallingSpeed;
            if (Speed == 0)
            {
                player.State = new RightFallingPlayerState(player, JumpingSpeed);
            }
            if (player.OnGround)
            {
                player.State = new RightMovingPlayerState(player, Speed);
            }
        }
    }
}