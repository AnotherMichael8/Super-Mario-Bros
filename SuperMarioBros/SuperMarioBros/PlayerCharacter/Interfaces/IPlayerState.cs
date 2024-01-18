using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.Interfaces
{
    public interface IPlayerState
    {
        public void BecomeIdle();
        public void MoveLeft();
        public void MoveRight();
        public void Sprint();
        public void StopSprinting();
        public void Jump();
        public void Crouch();
        public void Update();

    }
}
