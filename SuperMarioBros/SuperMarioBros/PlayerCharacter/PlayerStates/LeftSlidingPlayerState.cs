using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftSlidingPlayerState : AbstractPlayerState
    {
        private int accerlerationCounter;

        public LeftSlidingPlayerState(Player player) : base(player) 
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftSlidingPlayerSprite();
            accerlerationCounter = 0;
        }
        private void FinishedSliding()
        {
            player.State = new LeftIdlePlayerState(player);
        }
        public override void UpdateMovement()
        {
            //player.Position = new Vector2(player.Position.X + Speed, player.Position.Y);
            accerlerationCounter++;
            if (accerlerationCounter >= 3 && Speed > 0)
            {
                Speed--;
                accerlerationCounter = 0;
            }
            else if (Speed == 0)
            {
                FinishedSliding();
            }
        }
    }
}
