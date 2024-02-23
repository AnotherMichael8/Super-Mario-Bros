using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightFacingLeftMoveJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState
    {
        private int fallingSpeed;
        private int leftBarrier;
        public RightFacingLeftMoveJumpingPlayerState(Player player, int jumpingSpeed, bool noLeft = false) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 3;
            if(noLeft)
                leftBarrier = 0;
            else
                leftBarrier = -48;
        }
        public override void MoveLeft()
        {
            if (Speed > leftBarrier && !player.OnGround)
                Speed -= 16;
            else if(player.OnGround)
                player.State = new LeftMovingPlayerState(player, Speed);
        }
        public override void MoveRight()
        {
            Speed += 4;
        }
        public override void StopJumping()
        {
            fallingSpeed = 8;
        }
        public override void PowerUpMushroom()
        {
            base.PowerUpMushroom();
            player.State = new RightMushroomPowerUpAnimationState(player, this);
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (JumpingSpeed <= 16)
            {
                StopJumping();
            }
            if (player.OnGround)
            {
                player.State = new RightSlidingPlayerState(player); ;
            }
        }
    }
}
