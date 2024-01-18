using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightSlidingPlayerState : AbstractPlayerState
    {
        private Player player;
        private int accerlerationCounter;

        public RightSlidingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightSlidingPlayerSprite();
            accerlerationCounter = 0;
        }
        private void FinishedSliding()
        {
            player.State = new RightIdlePlayerState(player);
        }
        public override void Update()
        {
            player.Position = new Vector2(player.Position.X - player.Speed, player.Position.Y);
            accerlerationCounter++;
            if (accerlerationCounter >= 3 && player.Speed > 0)
            {
                player.Speed--;
                accerlerationCounter = 0;
            }
            else if(player.Speed == 0)
            {
                FinishedSliding();
            }
        }
    }
}
