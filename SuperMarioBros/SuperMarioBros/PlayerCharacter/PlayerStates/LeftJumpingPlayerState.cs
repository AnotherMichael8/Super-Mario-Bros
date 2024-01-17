using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftJumpingPlayerState : IPlayerState
    {
        private Player player;

        public LeftJumpingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
        }
        public void BecomeIdle()
        {
           // player.State = new LeftFallingPlayerState(player);
        }

        public void MoveLeft()
        {
           // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public void MoveRight()
        {
            //player.State = new RightWalkingPlayerState(player);
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
