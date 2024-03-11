using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockType;

namespace SuperMarioBros.PlayerCharacter.Interfaces
{
    public interface IPlayerState
    {
        public static int Speed { get; set; }
        public void BecomeIdle();
        public void MoveLeft();
        public void MoveRight();
        public void Sprint();
        public void StopSprinting();
        public void GrabPole();
        public void EnterPipe(Pipe pipe);
        public void StopJumping();
        public void StopUpwardMovement();
        public void Kill();
        public void Fall();
        public void Jump();
        public void Hop();
        public void Crouch();
        public void PowerUpMushroom();
        public void PowerUpFlower();
        public void PowerUpStar();
        public void UseAbility();
        public void Update();

    }
}
