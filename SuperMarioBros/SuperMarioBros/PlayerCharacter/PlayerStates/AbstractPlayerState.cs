using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
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
        protected static int Speed = 0;
        protected Player player;

        public AbstractPlayerState(Player player)
        {
            this.player = player;
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
        public void Update()
        {
            player.Position = new Vector2(player.Position.X + Speed/16, player.Position.Y - JumpingSpeed/16);
            player.Speed = Math.Abs(Speed);
            UpdateMovement();
        }
        public virtual void UpdateMovement() {}
    }
}
