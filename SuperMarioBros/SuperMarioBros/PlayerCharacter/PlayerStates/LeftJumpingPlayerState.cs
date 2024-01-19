﻿using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class LeftJumpingPlayerState : AbstractPlayerState
    {
        private Player player;
        private int jumpingSpeed;
        private int accelerationCounter;
        private int jumpCnt;

        public LeftJumpingPlayerState(Player player)
        {
            this.player = player;
            player.Sprite = PlayerSpriteFactory.Instance.CreateLeftJumpingPlayerSprite();
            jumpingSpeed = 20;
            accelerationCounter = 0;
            jumpCnt = 0;
        }
        public override void BecomeIdle()
        {
            if(jumpCnt > 50)
                player.State = new LeftFallingPlayerState(player);
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
            if(accelerationCounter == 8)
            {
                jumpingSpeed--;
                accelerationCounter = 0;
            }
            else if(jumpingSpeed == 5)
            {
                BecomeIdle();
            }
            accelerationCounter++;
            jumpCnt++;
        }
    }
}
