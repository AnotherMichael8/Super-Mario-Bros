using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightJumpingPlayerState : AbstractPlayerState, IJumpingPlayerState
    {
        private int fallingSpeed;
        public RightJumpingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = 140;
            fallingSpeed = 3;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            player.State = new RightFacingLeftMoveJumpingPlayerState(player, JumpingSpeed);
        }

        public override void MoveRight()
        {
            player.State = new RightMoveJumpingPlayerState(player, JumpingSpeed);
        }
        public override void Jump()
        {
            if(player.OnGround)
            {
                JumpingSpeed = 200;
                player.OnGround = false;
            }
        }
        public override void StopJumping()
        {
            fallingSpeed = 8;
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if(JumpingSpeed <= 16)
            {
                player.State = new RightFallingPlayerState(player, JumpingSpeed);
            }
            if(player.OnGround)
            {
                player.State = new RightIdlePlayerState(player);
            }
        }
    }
}
