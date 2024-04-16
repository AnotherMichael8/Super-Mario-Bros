using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class InitialWonderLeftJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState, ILeftFacing
    {
        private int fallingSpeed;
        public InitialWonderLeftJumpingPlayerState(Player player, double jumpingSpeed = 800) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 3;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            //player.State = new RightFacingLeftMoveJumpingPlayerState(player, JumpingSpeed);
            //player.State = new LeftMoveJumpingPlayerState(player, JumpingSpeed);
        }

        public override void MoveRight()
        {
            //player.State = new RightMoveJumpingPlayerState(player, JumpingSpeed);
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
            if(JumpingSpeed <= 16)
            {
                player.State = new LeftFallingPlayerState(player, JumpingSpeed);
            }
            if(player.OnGround)
            {
                player.State = new LeftIdlePlayerState(player);
            }
        }
    }
}
