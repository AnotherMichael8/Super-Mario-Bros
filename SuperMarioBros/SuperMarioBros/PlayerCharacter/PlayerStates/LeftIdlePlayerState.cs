using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftIdlePlayerState : AbstractPlayerState
    {
        private Player player;

        public LeftIdlePlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftIdlePlayerSprite();
        }

        public override void MoveLeft()
        {
            player.State = new LeftMovingPlayerState(player);
        }

        public override void MoveRight()
        {
            player.State = new RightMovingPlayerState(player);
        }

        public override void Jump()
        {
            player.State = new LeftJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }

        public override void Update()
        {
        }
    }
}
