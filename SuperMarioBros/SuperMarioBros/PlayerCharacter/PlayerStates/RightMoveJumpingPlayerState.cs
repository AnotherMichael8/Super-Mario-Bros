using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMoveJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState, IRightFacing
    {
        private int fallingSpeed;
        private bool noLeft;
        public RightMoveJumpingPlayerState(Player player, double jumpingSpeed) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            Initialize();
        }
        public RightMoveJumpingPlayerState(Player player) : base(player)
        {
            Initialize();
            double speed = Speed;
            if (speed < 16)
                speed = 16;
            JumpingSpeed = 164 - (24/(speed/16));      
        }
        public void Initialize()
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            fallingSpeed = 3;
            player.OnGround = false;
            if (Speed >= 0 && Speed <= 15)
                Speed = 16;
            noLeft = Speed >= 48;
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
            //player.State = new RightFacingLeftMoveJumpingPlayerState(player, JumpingSpeed, noLeft);
            player.State = new LeftMoveJumpingPlayerState(player, JumpingSpeed);
        }
        public override void MoveRight()
        {
            if (Speed < 2 * 16 * Globals.ScreenSizeMulti)
            {
                Speed += (int)(10 * Globals.ScreenSizeMulti);
            }
        }
        public override void StopJumping()
        {
            fallingSpeed = 8;
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
            JumpingSpeed -= fallingSpeed;
            if (Speed == 0)
            {
                player.State = new RightJumpingPlayerState(player, JumpingSpeed);
            }
            if (JumpingSpeed <= 16)
            {
                player.State = new RightMoveFallingPlayerState(player, JumpingSpeed);
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
