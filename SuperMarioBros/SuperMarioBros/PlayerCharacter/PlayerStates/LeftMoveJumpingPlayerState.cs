using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMoveJumpingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        private bool noRight;
        public LeftMoveJumpingPlayerState(Player player, int jumpingSpeed = 300) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 3;
            player.OnGround = false;
            noRight = jumpingSpeed == 300 && Speed <= -48;
            if(Speed == 0)
            {
                Speed = -16;
            }
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
            //player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            player.State = new LeftFacingRightMoveJumpingPlayerState(player, JumpingSpeed, noRight);
        }
        public override void Jump()
        {
            if (player.OnGround)
            {
                JumpingSpeed = 200;
                player.OnGround = false;
            }
        }
        public override void StopJumping()
        {
            fallingSpeed = 8;
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (JumpingSpeed <= 160)
            {
                StopJumping();
            }
            if (player.OnGround)
            {
                player.State = new LeftMovingPlayerState(player, Speed);
            }
        }
    }
}
