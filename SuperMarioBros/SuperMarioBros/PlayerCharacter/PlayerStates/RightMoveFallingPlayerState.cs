using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMoveFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        public RightMoveFallingPlayerState(Player player, int jumpingSpeed = 16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 8;
            player.OnGround = false;
        }
        public override void MoveLeft()
        {
            player.State = new RightFacingLeftMoveJumpingPlayerState(player, JumpingSpeed, true);
        }

        public override void MoveRight()
        {
            //Speed = 16;
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (player.OnGround)
            {
                player.State = new RightMovingPlayerState(player, Speed);
            }
        }
    }
}