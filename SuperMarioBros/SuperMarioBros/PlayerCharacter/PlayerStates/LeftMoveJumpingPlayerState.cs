using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMoveJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState
    {
        private int fallingSpeed;
        private bool noRight;
        public LeftMoveJumpingPlayerState(Player player, int jumpingSpeed) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            Initialize();
        }
        public LeftMoveJumpingPlayerState(Player player) : base(player)
        {
            Initialize();
            int speed = Speed;
            if (speed > -16)
                speed = -16;
            JumpingSpeed = (int)(164 + (24 / (speed / 16.0)));
        }
        public void Initialize()
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            fallingSpeed = 3;
            player.OnGround = false;
            if (Speed <= 0 && Speed >= -15)
                Speed = -16;
            noRight = Speed >= 48;
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
            if (Speed > -2 * 16 * Globals.ScreenSizeMulti)
            {
                Speed -= (int)(10 * Globals.ScreenSizeMulti);
            }
        }

        public override void MoveRight()
        {
            player.State = new RightMoveJumpingPlayerState(player, JumpingSpeed);
        }
        public override void StopJumping()
        {
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
            if (Speed == 0)
            {
                player.State = new LeftJumpingPlayerState(player, JumpingSpeed);
            }
            if (JumpingSpeed <= 16)
            {
                player.State = new LeftMoveFallingPlayerState(player, JumpingSpeed);
            }
            if (player.OnGround)
            {
                player.State = new LeftMovingPlayerState(player, Speed);
            }
        }
    }
}
