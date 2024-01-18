using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftMovingPlayerState : AbstractPlayerState
    {
        private Player player;
        private int accerlerationCounter;

        public LeftMovingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
            accerlerationCounter = 0;
            player.Speed = 1;
        }
        public override void BecomeIdle()
        {
            player.State = new LeftIdlePlayerState(player);
        }
        public override void MoveRight()
        {
            player.State = new RightSlidingPlayerState(player);
        }

        public override void Jump()
        {
            //player.State = new LeftWalkJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }

        public override void Update()
        {
            player.Position = new Vector2(player.Position.X - player.Speed, player.Position.Y);
            accerlerationCounter++;
            if (accerlerationCounter >= 10)
            {
                if (player.Speed < AccelerationCap)
                {
                    player.Speed++;
                }
                else if (player.Speed > AccelerationCap)
                {
                    player.Speed--;
                }
                accerlerationCounter = 0;
            }
        }
    }
}
