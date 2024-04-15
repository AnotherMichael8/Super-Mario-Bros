using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates.WonderStates
{
    public class InitialWonderLeftIdlePlayerState: AbstractPlayerState, ILeftFacing
    {
        private int decelerationRate;
        public InitialWonderLeftIdlePlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftIdlePlayerSprite();
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
            player.State = new InitialWonderLeftJumpingPlayerState(player);
        }
        public override void Fall()
        {
            //player.State = new RightFallingPlayerState(player);
        }
        public override void Crouch()
        {
            //player.State = new LeftCrouchingPlayerState(player);
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
            if (Speed > 0)
            {
                Speed--;
            }
        }
    }
}