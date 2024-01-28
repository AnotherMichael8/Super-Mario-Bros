using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMoveJumpingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        private bool noLeft;
        public RightMoveJumpingPlayerState(Player player, int jumpingSpeed = 300) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 3;
            player.OnGround = false;
            noLeft = jumpingSpeed == 300 && Speed >= 48;
            if (Speed == 0)
            {
                Speed = 16;
            }
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
            player.State = new RightFacingLeftMoveJumpingPlayerState(player, JumpingSpeed, noLeft);
        }
        public override void MoveRight()
        { 
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
                if (Speed != 0)
                    player.State = new RightMovingPlayerState(player, Speed);
                else
                    player.State = new RightIdlePlayerState(player);
            }
        }
    }
}
