using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftJumpingPlayerState : AbstractPlayerState
    {
        private Player player;

        public LeftJumpingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
        }
        public override void BecomeIdle()
        {
           // player.State = new LeftFallingPlayerState(player);
        }

        public override void MoveLeft()
        {
           // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void MoveRight()
        {
            //player.State = new RightWalkingPlayerState(player);
        }
        public override void Update()
        {
        }
    }
}
