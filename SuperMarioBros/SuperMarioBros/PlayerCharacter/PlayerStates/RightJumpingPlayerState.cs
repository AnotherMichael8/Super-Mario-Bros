﻿using SuperMarioBros.PlayerCharacter.Interfaces;
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

        public RightJumpingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = 18;
            accelerationCounter = 0;
            jumpCnt = 0;
            stopJump = false;
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
            if(jumpCnt > 3)
                player.State = new RightFallingPlayerState(player);
            stopJump = true;
        }
        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X, player.Position.Y - JumpingSpeed);
            if (accelerationCounter == 8 && !stopJump)
            {
                JumpingSpeed -= 2;
                accelerationCounter = 0;
            }
            else if (JumpingSpeed == 10 || stopJump)
            {
                StopJumping();
            }
            accelerationCounter++;
            jumpCnt++;
        }
    }
}
