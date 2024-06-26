﻿using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMovingPlayerState : AbstractPlayerState, ILeftFacing
    {
        private bool stop;
        public LeftMovingPlayerState(Player player, double speed = -20) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
            if (speed > 0)
                speed = -20;
            Speed = speed;
            stop = false;
            JumpingSpeed = 0;
        }
        public override void BecomeIdle()
        {
            if (Speed >= 0)
                player.State = new LeftIdlePlayerState(player);
            else if (!stop)
                stop = true;
        }
        public override void MoveRight()
        {
            player.State = new RightSlidingPlayerState(player);
        }
        public override void MoveLeft()
        {
            stop = false;
        }
        public override void Jump()
        {
            player.State = new LeftMoveJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }
        public override void Fall()
        {
            player.State = new LeftMoveFallingPlayerState(player);
        }
        public override void PowerUpMushroom()
        {
            base.PowerUpMushroom();
            player.State = new LeftMushroomPowerUpAnimationState(player, this);
        }
        public override void PowerUpFlower()
        {
            base.PowerUpFlower();
            player.State = new LeftFlowerPowerUpAnimationState(player, this);
        }
        public override void UpdateMovement()
        {
            if (stop)
            {
                Speed += 2;
            }
            else if (Speed > AccelerationCap * -1)
            {
                Speed -= 2;
            }
        }
    }
}
