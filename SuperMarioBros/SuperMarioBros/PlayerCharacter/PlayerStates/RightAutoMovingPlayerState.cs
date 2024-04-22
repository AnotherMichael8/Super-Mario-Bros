using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightAutoMovingPlayerState : AbstractPlayerState
    {
        private bool stop;
        public RightAutoMovingPlayerState(Player player, double speed = 20) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            if (speed < 0)
                speed = 20;
            Speed = speed;
            stop = false;
            JumpingSpeed = 0;
        }
        public override void Sprint() {}
        public override void Fall()
        {
            player.State = new RightAutoMoveFallingPlayerState(player);
        }
        public override void UpdateMovement()
        {
            if (stop)
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
