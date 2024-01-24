using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        private int accelerationCounter;
        public RightFallingPlayerState(Player player) : base(player) 
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
            JumpingSpeed = 9;
            accelerationCounter = 0;
            fallingSpeed = 2;
            player.OnGround = false;
        }
        public override void BecomeIdle()
        {
            //player.State = new LeftIdlePlayerState(player);
        }

        public override void MoveLeft()
        {
            // player.State = new LeftMoveJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            //player.State = new RightMoveJumpingPlayerState(player);
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
                player.State = new RightIdlePlayerState(player);
            }
            accelerationCounter++;
        }
    }
}