using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftFallingPlayerState : AbstractPlayerState
    {
        private Player player;
        private int jumpingSpeed;
        private int accelerationCounter;
        public LeftFallingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            jumpingSpeed = 4;
            accelerationCounter = 0;
            player.OnGround = false;
        }
        public override void BecomeIdle()
        {
            //player.State = new LeftIdlePlayerState(player);
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
            player.Position = new Vector2(player.Position.X, player.Position.Y - jumpingSpeed);
            if (accelerationCounter == 8 && jumpingSpeed > 0)
            {
                jumpingSpeed--;
                accelerationCounter = 0;
            }
            else if (player.OnGround)
            {
                player.State = new LeftIdlePlayerState(player);
            }
            accelerationCounter++;
        }
    }
}