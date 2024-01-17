﻿using SuperMarioBros.PlayerCharacter.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightJumpingPlayerState : IPlayerState
    {
        private Player player;

        public RightJumpingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightJumpingPlayerSprite();
        }
        public void BecomeIdle()
        {
            //player.State = new RightFallingPlayerState(player);
        }

        public void MoveLeft()
        {
           // player.State = new LeftWalkJumpingPlayerState(player);
        }

        public void MoveRight()
        {
            //player.State = new RightWalkJumpingPlayerState(player);
        }

        public void Sprint()
        {
        }

        public void Jump()
        {
        }

        public void Crouch()
        {
        }

        public void Update()
        {
        }
    }
}
