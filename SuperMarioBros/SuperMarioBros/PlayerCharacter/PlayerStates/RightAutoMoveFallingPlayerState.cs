using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightAutoMoveFallingPlayerState : AbstractPlayerState
    {
        private int fallingSpeed;
        public RightAutoMoveFallingPlayerState(Player player, double jumpingSpeed = 16) : base(player)
        {
            JumpingSpeed = jumpingSpeed;
            fallingSpeed = 8;
            player.OnGround = false;
        }
        public override void UpdateMovement()
        {
            if (JumpingSpeed > -300)
                JumpingSpeed -= fallingSpeed;
            if (player.OnGround)
            {
                player.State = new RightAutoMovingPlayerState(player, Speed);
            }
        }
    }
}
