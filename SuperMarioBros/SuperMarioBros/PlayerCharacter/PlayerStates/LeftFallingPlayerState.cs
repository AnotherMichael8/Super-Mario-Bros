﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        public LeftFallingPlayerState(Player player, int jumpingSpeed = 16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 8;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            player.State = new LeftFacingRightMoveJumpingPlayerState(player, JumpingSpeed, true);
        }

        public override void MoveRight()
        {
            //Speed = 16;
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (player.OnGround)
            {
                player.State = new LeftIdlePlayerState(player);
            }
        }
    }
}