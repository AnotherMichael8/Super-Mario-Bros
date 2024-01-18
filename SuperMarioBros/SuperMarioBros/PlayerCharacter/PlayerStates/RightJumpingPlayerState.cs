using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightJumpingPlayerState : AbstractPlayerState
    {
        private Player player;

        public RightJumpingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
        }
        public override void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
           // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            //player.State = new RightWalkJumpingPlayerState(player);
        }
        public override void Update()
        {
        }
    }
}
