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
        public LeftSlidingPlayerState(Player player) : base(player) 
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftSlidingPlayerSprite();
        }
        private void FinishedSliding()
        {
            player.State = new LeftIdlePlayerState(player);
        }
        public override void UpdateMovement()
        {
            if (Speed > 0)
            {
                Speed -= 4;
            }
            else if (Speed <= 0)
            {
                FinishedSliding();
            }
        }
    }
}
