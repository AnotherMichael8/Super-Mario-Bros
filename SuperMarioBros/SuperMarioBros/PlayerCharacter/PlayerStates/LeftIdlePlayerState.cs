using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftIdlePlayerState : AbstractPlayerState
    {
        public LeftIdlePlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftIdlePlayerSprite();
            Speed = 0;
            JumpingSpeed = 0;
        }

        public override void MoveLeft()
        {
            player.State = new LeftMovingPlayerState(player);
        }

        public override void MoveRight()
        {
            player.State = new RightMovingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new LeftJumpingPlayerState(player);
        }
        public override void Fall()
        {
            player.State = new LeftFallingPlayerState(player);
        }
        public override void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
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
            if (Speed < 0)
            {
                Speed++;
            }
        }
    }
}
