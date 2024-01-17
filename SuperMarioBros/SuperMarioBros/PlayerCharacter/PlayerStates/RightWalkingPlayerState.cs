using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightWalkingPlayerState : IPlayerState
    {
        private Player player;
        private int accerlerationCounter;

        public RightWalkingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
            accerlerationCounter = 0;
            player.Speed = 6;
        }
        public void BecomeIdle()
        {
            player.State = new RightIdlePlayerState(player);
        }

        public void MoveLeft()
        {
            player.State = new LeftWalkingPlayerState(player);
        }

        public void MoveRight()
        {
        }

        public void Sprint()
        {
            player.State = new RightSprintingPlayerState(player);
        }

        public void Jump()
        {
            //player.State = new RightWalkJumpingPlayerState(player);
        }

        public void Crouch()
        {
            player.State = new RightCrouchingPlayerState(player);
        }

        public void Update()
        {
            player.Position = new Vector2(player.Position.X + player.Speed, player.Position.Y);
            accerlerationCounter++;
            if(accerlerationCounter >= 8)
            {
                //player.Speed++;
                accerlerationCounter = 0;
            }
        }
    }
}
