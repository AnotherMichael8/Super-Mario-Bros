using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightSprintingPlayerState //: IPlayerState
    {
        private Player player;

        public RightSprintingPlayerState(Player player)
        {
            this.player = player;
        }
        public void BecomeIdle()
        {
            player.State = new RightIdlePlayerState(player);
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            player.State = new RightMovingPlayerState(player);
        }

        public void Sprint()
        {
        }

        public void Jump()
        {
            //player.State = new RightSprintJumpingPlayerState(player);
        }

        public void Crouch()
        {
            player.State = new RightCrouchingPlayerState(player);
        }

        public void Update()
        {
        }
    }
}
