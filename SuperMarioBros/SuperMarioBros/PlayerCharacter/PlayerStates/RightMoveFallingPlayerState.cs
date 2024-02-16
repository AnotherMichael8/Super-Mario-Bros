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
            player.State = new LeftMoveFallingPlayerState(player, JumpingSpeed);
        }

        public override void MoveRight()
        {
            if (Speed < 2 * 16 * Globals.ScreenSizeMulti)
            {
                Speed += (int)(10 * Globals.ScreenSizeMulti);
            }
        }
        public override void UpdateMovement()
        {
            JumpingSpeed -= fallingSpeed;
            if (Speed == 0)
            {
                player.State = new RightFallingPlayerState(player, JumpingSpeed);
            }
            if (player.OnGround)
            {
                player.State = new RightMovingPlayerState(player, Speed);
            }
        }
    }
}