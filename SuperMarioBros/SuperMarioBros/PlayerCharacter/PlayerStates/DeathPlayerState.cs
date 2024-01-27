using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class DeathPlayerState : AbstractPlayerState
    {
        private int moveTimer;
        private int moveSpeed;
        public DeathPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateDeathPlayerSprite();
            Speed = 0;
            JumpingSpeed = 0;
            moveTimer = 5;
            moveSpeed = 17;
        }
        public override void UpdateMovement()
        {
            player.Position = new Vector2(player.Position.X, player.Position.Y - moveSpeed);
            if(moveTimer == 5)
            {
                moveSpeed--;
                moveTimer = 0;
            }
            moveTimer++;
        }
    }
}
