using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftIdlePlayerState : IPlayerState
    {
        private Player player;

        public LeftIdlePlayerState(Player player)
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
            player.State = new LeftSprintingPlayerState(player);
        }

        public void Jump()
        {
            player.State = new LeftJumpingPlayerState(player);
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
