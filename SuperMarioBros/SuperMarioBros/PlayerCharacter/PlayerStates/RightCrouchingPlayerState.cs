using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    internal class RightCrouchingPlayerState : IPlayerState
    {
        private Player player;

        public RightCrouchingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightCrouchingPlayerSprite();
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
        }

        public void Jump()
        {
        }

        public void Crouch()
        {
        }

        public void Update()
        {
        }
    }
}
