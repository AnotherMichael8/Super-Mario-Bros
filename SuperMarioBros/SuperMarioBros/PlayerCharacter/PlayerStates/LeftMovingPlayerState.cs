using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMovingPlayerState : AbstractPlayerState
    {
        private int accelerationCounter;
        private bool stop;
        public LeftMovingPlayerState(Player player) : base(player) 
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
            accelerationCounter = 0;
            Speed = -1;
            stop = false;
        }
        public override void BecomeIdle()
        {
            if(Speed == 0)
                player.State = new LeftIdlePlayerState(player);
            else if (!stop)
                stop = true;
        }
        public override void MoveRight()
        {
            player.State = new RightSlidingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new LeftMoveJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }

        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X - Speed, player.Position.Y);
            accelerationCounter++;
            if (stop && accelerationCounter > 8)
            {
                Speed++;
                accelerationCounter = 0;
            }
            else if (accelerationCounter >= 10)
            {
                if (Speed > AccelerationCap * -1)
                {
                    Speed--;
                }
                else if (Speed < AccelerationCap * -1)
                {
                    Speed++;
                }
                accelerationCounter = 0;
            }
        }
    }
}
