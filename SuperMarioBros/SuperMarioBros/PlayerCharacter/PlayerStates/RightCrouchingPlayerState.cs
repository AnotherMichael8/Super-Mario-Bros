using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    internal class RightCrouchingPlayerState : AbstractPlayerState
    {
        private Player player;

        public RightCrouchingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightCrouchingPlayerSprite();
        }
        public override void BecomeIdle()
        {
            player.State = new RightIdlePlayerState(player);
        }

        public override void MoveLeft()
        {
        }

        public override void MoveRight()
        {
        }

        public override void Update()
        {
        }
    }
}
