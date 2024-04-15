using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates.WonderStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class InitialWonderRightMovingPlayerState : AbstractPlayerState, IRightFacing
    {
        private bool stop;

        public InitialWonderRightMovingPlayerState(Player player, double speed = 20) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            if (speed < 0)
                speed = 20;
            Speed = speed;
            stop = false;
            JumpingSpeed = 0;
        }
        public override void BecomeIdle()
        {
            if (Speed <= 0)
                player.State = new InitialWonderRightIdlePlayerState(player);
            else if (!stop)
                stop = true;
        }
        public override void MoveRight()
        {
            stop = false;
        }
        public override void MoveLeft()
        {
            player.State = new InitialWonderLeftMovingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new InitialWonderRightJumpingPlayerState(player);
        }
        public override void Fall()
        {
            player.State = new RightMoveFallingPlayerState(player);
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
            if(stop)
            {
                Speed -= 2;
            }
            else if (Speed < AccelerationCap)
            {
                Speed += 2;
            }
        }
    }
}
