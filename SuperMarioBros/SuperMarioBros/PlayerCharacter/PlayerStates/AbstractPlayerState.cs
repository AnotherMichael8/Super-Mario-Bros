using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public abstract class AbstractPlayerState : PowerUp, IPlayerState
    {
        //public enum PowerUps { NONE ,MUSHROOM, FIREFLOWER};
        public PowerUps currentPowerUp { get; private set; }
        protected static int AccelerationCap = 3 * 16;
        protected static int JumpingSpeed = 0;
        private double trueXPosition;
        private double trueYPosition;
        public static int Speed { get;  set; } = 0;
        protected Player player;

        public AbstractPlayerState(Player player)
        {
            this.player = player;
            trueXPosition = player.Position.X;
            trueYPosition = player.Position.Y;
            currentPowerUp = PowerUps.NONE;
        }
        public virtual void BecomeIdle() { }
        public virtual void Crouch() { }
        public virtual void Jump() { }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public virtual void StopJumping() { }
        public virtual void Fall() { }
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
            switch(currentPowerUp)
            {
                case (PowerUps.MUSHROOM):
                case (PowerUps.FIREFLOWER):
                    currentPowerUp = PowerUps.NONE;
                    break;
                default:
                    player.State = new DeathPlayerState(player);
                    break;
            }
        }
        public virtual void StopUpwardMovement() 
        {
            JumpingSpeed = 16;
        }
        public virtual void PowerUpMushroom()
        {
            currentPowerUp = PowerUps.MUSHROOM;
        }
        public virtual void PowerUpFlower()
        {
            currentPowerUp = PowerUps.FIREFLOWER;
        }
        public void PowerUpStar()
        {
            //currentPowerUp = PowerUps.STAR;
        }
        public void UseAbility()
        {

        }

        public virtual void Update()
        {
            UpdateMovement();
            trueXPosition = player.Position.X + (Speed / 16.0) * Globals.ScreenSizeMulti;
            trueYPosition = player.Position.Y - (JumpingSpeed / 16.0) * Globals.ScreenSizeMulti;
            player.Position = new Vector2((int)trueXPosition, (int)trueYPosition);
            player.Speed = Speed/16;
        }
        public virtual void UpdateMovement() {}
    }
}
