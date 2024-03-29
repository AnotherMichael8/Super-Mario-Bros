﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightSlidingPlayerState : AbstractPlayerState, IRightFacing
    {
        public RightSlidingPlayerState(Player player) : base(player) 
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightSlidingPlayerSprite();
            JumpingSpeed = 0;
        }
        private void FinishedSliding()
        {
            player.State = new RightIdlePlayerState(player);
        }
        public override void Fall()
        {
            player.State = new RightMoveFallingPlayerState(player);
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
            if (Speed < 0)
            {
                Speed += 4;
            }
            else if (Speed >= 0)
            {
                FinishedSliding();
            }
        }
    }
}
