using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightIdlePlayerState : IPlayerState
    {
        private Player player;

        public RightIdlePlayerState(Player player)
        {
            this.player = player;
        }
        public void BecomeIdle()
        {
        }

        public void MoveLeft()
        {
            player.State = new LeftWalkingPlayerState(player);
        }

        public void MoveRight()
        {
            player.State = new RightWalkingPlayerState(player);
        }

        public void Sprint()
        {
            player.State = new RightSprintingPlayerState(player);
        }

        public void Jump()
        {
            player.State = new RightJumpingPlayerState(player);
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
