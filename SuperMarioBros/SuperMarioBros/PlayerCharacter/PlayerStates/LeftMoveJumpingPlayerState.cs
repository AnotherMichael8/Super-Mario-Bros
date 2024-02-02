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
            JumpingSpeed = 164 + (24 / (Speed / 16));
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
            //player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            player.State = new LeftFacingRightMoveJumpingPlayerState(player, JumpingSpeed, noRight);
        }
        public override void Jump()
        {
            if (player.OnGround)
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
