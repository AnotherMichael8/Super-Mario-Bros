using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Camera;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.Collision;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using SuperMarioBros.PlayerCharacter.PlayerStates.WonderStates;
using SuperMarioBros.PlayerCharacter.PowerUpAbilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public abstract class AbstractPlayerState : PowerUp, IPlayerState
    {
        //public enum PowerUps { NONE ,MUSHROOM, FIREFLOWER};
        public static PowerUps currentPowerUp { get; private set; } = PowerUps.NONE;
        protected static int AccelerationCap = 3 * 16;
        protected static double JumpingSpeed = 0;
        private double trueXPosition;
        private double trueYPosition;
        public static double Speed { get;  set; } = 0;
        protected Player player;
        private static int invincibleTimer = 0;
        protected static bool WonderTime = false;

        public AbstractPlayerState(Player player)
        {
            this.player = player;
            trueXPosition = player.Position.X;
            trueYPosition = player.Position.Y;
        }
        public virtual void BecomeIdle() { }
        public virtual void Crouch() { }
        public virtual void Jump() { }
        public virtual void Hop() { }
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
        public void GrabPole()
        {
            player.State = new GrabPolePlayerState(player);
        }
        public void EnterPipe(Pipe pipe)
        {
            player.State = new EnterPipePlayerState(player, pipe);
        }
        public virtual void TriggerWonderState(Vector2 wonderPosition)
        {
            player.State = new WonderOrbPlayerState(player, wonderPosition);
        }
        public virtual void Kill()
        {
            switch(currentPowerUp)
            {
                case (PowerUps.MUSHROOM):
                case (PowerUps.FIREFLOWER):
                    currentPowerUp = PowerUps.NONE;
                    player.Position = new Vector2(player.Position.X, (int)(player.Position.Y + Globals.BlockSize));
                    invincibleTimer = 120;
                    player.Invincible = true;
                    break;
                default:
                    if(invincibleTimer <= 0)
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
        public virtual void UseAbility()
        {
            if(currentPowerUp == PowerUps.FIREFLOWER)
            {
                Fireball fireball;
                if (this is ILeftFacing)
                    fireball = new Fireball(player, -1);
                else
                    fireball = new Fireball(player, 1);
            }
        }
        public virtual void Update()
        {
            UpdateMovement();
            trueXPosition = player.Position.X + (Speed / 16.0) * Globals.ScreenSizeMulti;
            trueYPosition = player.Position.Y - (JumpingSpeed / 16.0) * Globals.ScreenSizeMulti;
            player.Position = new Vector2((int)trueXPosition, (int)trueYPosition);
            player.Speed = (int)Speed/16;
            if (invincibleTimer > 0)
                invincibleTimer--;
            else
                player.Invincible = false;
        }
        public virtual void UpdateMovement() {}
    }
}
