using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftWalkingPlayerState : IPlayerState
    {
        private Player player;

        public LeftWalkingPlayerState(Player player)
        {
            this.player = player;
        }
        public void BecomeIdle()
        {
            player.State = new LeftIdlePlayerState(player);
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Sprint()
        {
            player.State = new LeftSprintingPlayerState(player);
        }

        public void Jump()
        {
            player.State = new LeftWalkJumpingPlayerState(player);
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
