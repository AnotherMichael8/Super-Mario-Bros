using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState, ILeftFacing
    {
        private double fallingSpeed;
        public LeftJumpingPlayerState(Player player, double jumpingSpeed = 140) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            if (WonderTime)
                fallingSpeed = 1;
            else
                fallingSpeed = 3;
            player.OnGround = false;
            if (player.Position.Y < Globals.ScreenHeight - (int)(3 * Globals.BlockSize))
            {
            }
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
            player.State = new RightMoveJumpingPlayerState(player, JumpingSpeed);
        }
        public override void StopJumping()
        {
            if (WonderTime)
                fallingSpeed = 4;
            else
                fallingSpeed = 8;
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
            JumpingSpeed -= fallingSpeed;
            if (JumpingSpeed <= 16)
            {
                player.State = new LeftFallingPlayerState(player, JumpingSpeed);
            }
            if (player.OnGround)
            {
                player.State = new LeftIdlePlayerState(player);
            }
        }
    }
}
