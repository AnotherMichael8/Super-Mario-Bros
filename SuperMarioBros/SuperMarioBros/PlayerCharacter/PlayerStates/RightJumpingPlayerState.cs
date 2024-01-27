using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightJumpingPlayerState : AbstractPlayerState
    {
        private int accelerationCounter;
        private int jumpCnt;
        private bool stopJump;
        private int fallingSpeed;

        public RightJumpingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = 272;
            fallingSpeed = 2;
            stopJump = false;
            player.OnGround = false;
        }
        public override void BecomeIdle()
        {
        }

        public override void MoveLeft()
        {
            if (accelerationCounter == 8)
                Speed--;
        }

        public override void MoveRight()
        {
            player.State = new RightMoveJumpingPlayerState(player, JumpingSpeed);
        }
        public override void StopJumping()
        {
            //player.State = new RightFallingPlayerState(player);
            //stopJump = true;
            fallingSpeed = 8;
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if(JumpingSpeed <= 160)
            {
                StopJumping();
            }
            if(player.OnGround)
            {
                player.State = new RightIdlePlayerState(player);
            }
        }
    }
}
