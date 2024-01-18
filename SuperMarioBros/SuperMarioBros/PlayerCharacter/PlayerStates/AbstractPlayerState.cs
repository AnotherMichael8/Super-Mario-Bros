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
        protected static int AccelerationCap = 3;
        public virtual void BecomeIdle() { }
        public virtual void Crouch() { }
        public virtual void Jump() { }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public virtual void Sprint() 
        {
            AccelerationCap = 6;
        }
        public virtual void StopSprinting()
        {
            AccelerationCap = 3;
        }
        public abstract void Update();
    }
}
