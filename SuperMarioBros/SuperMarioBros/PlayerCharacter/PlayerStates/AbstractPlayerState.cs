﻿using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        protected static int AccelerationCap = 3 * 16;
        protected static int JumpingSpeed = 0;
        private double trueXPosition;
        private double trueYPosition;
        public static int Speed { get;  set; } = 0;
        protected Player player;
        private static bool dictionaryMade = false; 
        protected static Dictionary<Type, IPlayerState> PlayerSpriteStateDict = new Dictionary<Type, IPlayerState>();

        public AbstractPlayerState(Player player)
        {
            this.player = player;
            trueXPosition = player.Position.X;
            trueYPosition = player.Position.Y;
        }
        public virtual void BecomeIdle() { }
        public virtual void Crouch() { }
        public virtual void Jump() { }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public virtual void StopJumping() { }
        public virtual void Sprint() 
        {
            AccelerationCap = 6 * 16;
        }
        public virtual void StopSprinting()
        {
            AccelerationCap = 3 * 16;
        }
        public virtual void Kill()
        {
            player.State = new DeathPlayerState(player);
        }
        public virtual void StopUpwardMovement() 
        {
            JumpingSpeed = 16;
        }
        public virtual void Fall() 
        { 
        }

        public void Update()
        {
            //Speed = player.Speed;
            UpdateMovement();
            trueXPosition = player.Position.X + (Speed / 16.0) * Globals.ScreenSizeMulti;
            trueYPosition = player.Position.Y - (JumpingSpeed / 16.0) * Globals.ScreenSizeMulti;
            player.Position = new Vector2((int)trueXPosition, (int)trueYPosition);
            //player.Position = new Vector2((int)(player.Position.X + (Speed/16.0) * (Globals.BlockSize / 32)), (int)(player.Position.Y - (JumpingSpeed/16.0) * (Globals.BlockSize / 32)));
            player.Speed = Speed/16;
        }
        public virtual void UpdateMovement() {}
    }
}
