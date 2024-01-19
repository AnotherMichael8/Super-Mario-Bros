using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightMovingPlayerState : AbstractPlayerState
    {
        private Player player;
        private int accerlerationCounter;

        public RightMovingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            accerlerationCounter = 0;
            player.Speed = 1;
        }
        public override void BecomeIdle()
        {
            player.State = new RightIdlePlayerState(player);
        }

        public override void MoveLeft()
        {
            player.State = new LeftSlidingPlayerState(player);
        }

        public override void Jump()
        {
            //player.State = new RightWalkJumpingPlayerState(player);
        }

        public override void Crouch()
        {
            player.State = new RightCrouchingPlayerState(player);
        }

        public override void Update()
        {
            player.Position = new Vector2(player.Position.X + player.Speed, player.Position.Y);
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
