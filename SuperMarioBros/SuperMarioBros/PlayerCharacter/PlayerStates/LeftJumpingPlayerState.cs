using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftJumpingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        public LeftJumpingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = 284;
            fallingSpeed = 3;
            player.OnGround = false;
        }
        public override void BecomeIdle()
        {
            
        }

        public override void MoveLeft()
        {
            player.State = new LeftMoveJumpingPlayerState(player, JumpingSpeed);
        }

        public override void MoveRight()
        {
            player.State = new LeftFacingRightMoveJumpingPlayerState(player, JumpingSpeed);
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
                player.State = new LeftIdlePlayerState(player);
            }
        }
    }
}
