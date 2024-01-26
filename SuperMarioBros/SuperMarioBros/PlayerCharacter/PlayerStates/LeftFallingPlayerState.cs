using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        private int accelerationCounter;
        private const int HOP = 12;
        public LeftFallingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = 9;
            accelerationCounter = 0;
            player.OnGround = false;
            fallingSpeed = 2;
        }
        public override void BecomeIdle()
        {
            //player.State = new LeftIdlePlayerState(player);
        }

        public override void MoveLeft()
        {
            // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            //player.State = new RightWalkingPlayerState(player);
        }
        public override void Jump()
        {
            player.State = new LeftMoveJumpingPlayerState(player, HOP);
        }
        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X, player.Position.Y - JumpingSpeed);
            if (accelerationCounter == 8 && JumpingSpeed > 0)
            {
                JumpingSpeed -= fallingSpeed;
                accelerationCounter = 0;
                fallingSpeed++;
            }
            else if (player.OnGround)
            {
                player.State = new LeftIdlePlayerState(player);
            }
            accelerationCounter++;
        }
    }
}