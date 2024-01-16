using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftSprintingPlayerState : IPlayerState
    {
        private Player player;

        public LeftSprintingPlayerState(Player player)
        {
            this.player = player;
        }
        public void BecomeIdle()
        {
            player.State = new LeftIdlePlayerState(player);
        }
        public void MoveLeft()
        {
            player.State = new LeftWalkingPlayerState(player);
        }

        public void MoveRight()
        {
        }

        public void Sprint()
        {
        }

        public void Jump()
        {
            player.State = new LeftSprintJumpingPlayerState(player);
        }

        public void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }

        public void Update()
        {
        }
    }
}
