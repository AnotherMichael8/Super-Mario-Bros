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
        private bool stop;

        public RightMovingPlayerState(Player player, int speed = 16) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            Speed = speed;
            stop = false;
        }
        public override void BecomeIdle()
        {
            if (Speed == 0)
                player.State = new RightIdlePlayerState(player);
            else if (!stop)
                stop = true;
        }
        public override void MoveRight()
        {
            stop = false;
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
