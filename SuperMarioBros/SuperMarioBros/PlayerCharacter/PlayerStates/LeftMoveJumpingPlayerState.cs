using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMoveJumpingPlayerState : AbstractPlayerState
    {    
        private int accelerationCounter;
        private int jumpCnt;
        private bool stopJump;
        public LeftMoveJumpingPlayerState(Player player, int jumpingSpeed = 18) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            JumpingSpeed = jumpingSpeed;
            accelerationCounter = 0;
            jumpCnt = 0;
            stopJump = false;
            if(Speed == 0)
            {
                Speed = -1;
            }
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
            // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            //player.State = new RightMoveJumpingPlayerState(player);
        }
        public override void StopJumping()
        {
            if (jumpCnt > 3)
                player.State = new LeftFallingPlayerState(player);
            stopJump = true;
        }
        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X + Speed, player.Position.Y - JumpingSpeed);
            if (accelerationCounter == 8 && !stopJump)
            {
                JumpingSpeed -= 2;
                accelerationCounter = 0;
            }
            else if (JumpingSpeed == 10 || stopJump)
            {
                StopJumping();
            }
            accelerationCounter++;
            jumpCnt++;
        }
    }
}
