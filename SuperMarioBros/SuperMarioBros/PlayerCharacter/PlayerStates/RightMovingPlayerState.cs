using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMovingPlayerState : AbstractPlayerState
    {
        private int accelerationCounter;
        private bool stop;

        public RightMovingPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            accelerationCounter = 0;
            Speed = 1;
            stop = false;
        }
        public override void BecomeIdle()
        {
            if (Speed == 0)
                player.State = new RightIdlePlayerState(player);
            else if (!stop)
                stop = true;
        }
        public override void MoveLeft()
        {
            player.State = new LeftSlidingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new RightMoveJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new RightCrouchingPlayerState(player);
        } 

        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X + Speed, player.Position.Y);
            accelerationCounter++;
            if(stop && accelerationCounter > 8)
            {
                Speed--;
                accelerationCounter = 0;
            }
            else if (accelerationCounter >= 10)
            {
                if (Speed < AccelerationCap)
                {
                    Speed++;
                }
                else if (Speed > AccelerationCap)
                {
                    Speed--;
                }
                accelerationCounter = 0;
            }
        }
    }
}
