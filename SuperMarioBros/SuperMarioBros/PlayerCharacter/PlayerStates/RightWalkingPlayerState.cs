using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightWalkingPlayerState : IPlayerState
    {
        private Player player;

        public RightWalkingPlayerState(Player player)
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
        }

        public void Sprint()
        {
            player.State = new RightSprintingPlayerState(player);
        }

        public void Jump()
        {
            player.State = new RightWalkJumpingPlayerState(player);
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
