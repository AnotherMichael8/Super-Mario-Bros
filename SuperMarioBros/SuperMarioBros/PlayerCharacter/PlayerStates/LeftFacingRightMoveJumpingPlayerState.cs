﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftFacingRightMoveJumpingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        private int rightBarrier;
        public LeftFacingRightMoveJumpingPlayerState(Player player, int jumpingSpeed, bool noRight = false) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 3;
            if (noRight)
                rightBarrier = 0;
            else
                rightBarrier = 48;
        }
        public override void MoveLeft()
        {
            Speed -= 4;
        }
        public override void MoveRight()
        {
            if (Speed < rightBarrier && !player.OnGround)
                Speed += 16;
            else if (player.OnGround)
                player.State = new RightMovingPlayerState(player, Speed);
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
            if (JumpingSpeed <= 16)
            {
                StopJumping();
            }
            if (player.OnGround)
            {
                player.State = new LeftSlidingPlayerState(player); ;
            }
        }
    }
}
