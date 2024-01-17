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
    public class LeftWalkingPlayerState : IPlayerState
    {
        private Player player;
        private int accelerationCounter;

        public LeftWalkingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
            accelerationCounter = 0;
            player.Speed = 1;
        }
        public void BecomeIdle()
        {
            player.State = new LeftIdlePlayerState(player);
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            player.State = new RightWalkingPlayerState(player);
        }

        public void Sprint()
        {
            player.State = new LeftSprintingPlayerState(player);
        }

        public void Jump()
        {
            //player.State = new LeftWalkJumpingPlayerState(player);
        }

        public void Crouch()
        {
            player.State = new LeftCrouchingPlayerState(player);
        }

        public void Update()
        {
            player.Position = new Vector2(player.Position.X - player.Speed, player.Position.Y);
            accelerationCounter++;
            if (accelerationCounter >= 8)
            {
                player.Speed++;
                accelerationCounter = 0;
            }
        }
    }
}
