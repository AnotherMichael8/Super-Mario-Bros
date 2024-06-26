﻿using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates.WonderStates
{
    public class InitialWonderRightIdlePlayerState : AbstractPlayerState, IRightFacing
    {
        private int decelerationRate;
        public InitialWonderRightIdlePlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightIdlePlayerSprite();
            decelerationRate = 0;
            Speed = 0;
            JumpingSpeed = 0;
        }

        public override void MoveLeft()
        {
            player.State = new InitialWonderLeftMovingPlayerState(player);
        }

        public override void MoveRight()
        {
            player.State = new InitialWonderRightMovingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new InitialWonderRightJumpingPlayerState(player);
        }
        public override void Fall()
        {
            //player.State = new RightFallingPlayerState(player);
        }
        public override void Crouch()
        {
            //player.State = new RightCrouchingPlayerState(player);
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
        public override void UpdateMovement()
        {
            if (Speed > 0)
            {
                Speed--;
            }
        }
    }
}
